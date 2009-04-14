using System;
using System.IO;
using System.Drawing;
using System.Collections.Generic;
using ICSharpCode.SharpZipLib.Zip;

namespace PspComicHelper
{
	/// <summary>
	/// 漫画文件处理类
	/// </summary>
	public class ComicHelper
	{
		private static readonly List<string> imageExts = new List<string>(){ ".jpg", ".jpeg", ".png", ".gif", ".bmp" };
		private static Microsoft.VisualBasic.Devices.Computer _computer = new Microsoft.VisualBasic.Devices.Computer();
		private const string UNZIP_TEMP_FOLDER = "unzip_temp";

		/// <summary>
		/// 处理图片路径
		/// </summary>
		/// <param name="path"></param>
		public static string ProgressComicPath( string path )
		{
			// 创建临时目录
			if ( Directory.Exists( ComicHelper.TempPath ) )
			{
				try
				{
					Directory.Delete( ComicHelper.TempPath, true );
				}
				catch ( IOException )
				{
					// 删除临时目录失败
				}
			}
			Directory.CreateDirectory( ComicHelper.TempPath );

			string result;

			if ( File.Exists( path ) )
			{
				// 如果是文件, 调用处理压缩文档的方法
				result = ProgressComicArchive( path );
			}
			else if ( Directory.Exists( path ) )
			{
				// 如果是目录, 调用处理目录的方法
				result = ProgressComicFolder( path );
			}
			else
			{
				result = "路径错误";
			}

			// 删除临时目录
			if ( Directory.Exists( ComicHelper.TempPath ) )
			{
				try
				{
					Directory.Delete( ComicHelper.TempPath, true );
				}
				catch ( IOException )
				{
					// 删除临时目录失败
				}
			}

			return result;

		}

		/// <summary>
		/// 处理图片路径 压缩文档
		/// </summary>
		/// <param name="path"></param>
		private static string ProgressComicArchive( string path )
		{

			string unzipTempPath = Path.Combine( TempPath, UNZIP_TEMP_FOLDER );
			unzipTempPath = Path.Combine( unzipTempPath, Path.GetFileNameWithoutExtension( path ) );
			string ext = Path.GetExtension( path ).ToLower();
			string result;
			if ( ext != ".zip" && ext != ".rar" )
			{
				return "不支持的压缩格式";
			}

			
			// 创建解压临时目录
			if ( Directory.Exists( unzipTempPath ) )
			{
				Directory.Delete( unzipTempPath );
			}
			Directory.CreateDirectory( unzipTempPath );

			if ( ext == ".zip" )
			{
				// 使用SharpZipLib解压缩zip
				FastZip fz = new FastZip();
				fz.CreateEmptyDirectories = true;
				fz.ExtractZip( path, unzipTempPath, "" );
				fz = null;
				result = ProgressComicFolder( unzipTempPath, true );
			}
			else if ( ext == ".rar" )
			{
				// 使用unrar.exe解压缩rar
				string args = string.Format( "x -o+ \"{0}\" \"{1}\\\"", path, unzipTempPath );
				using ( System.Diagnostics.Process rar = new System.Diagnostics.Process() )
				{
					rar.StartInfo.FileName = Path.Combine( AppPath, "rar.exe" );
					rar.StartInfo.Arguments = args;
					rar.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
					rar.Start();
					rar.WaitForExit();
					rar.Close();
				}
				result = ProgressComicFolder( unzipTempPath, true );
			}
			else
			{
				result = "不支持的压缩格式";
			}
			

			// 删除解压临时目录
			if ( Directory.Exists( unzipTempPath ) )
			{
				try
				{
					Directory.Delete( unzipTempPath, true );
				}
				catch( IOException )
				{
					// 删除临时目录失败
				}
			}

			return result;
		}

		/// <summary>
		/// 处理图片路径 文件夹
		/// </summary>
		/// <param name="path"></param>
		private static string ProgressComicFolder( string path, bool includeSubdirectory )
		{
			// 取得文件夹中所有图片文件
			List<string> files = new List<string>(
				Directory.GetFiles( path, "*.*", includeSubdirectory ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly )
			);
			for ( int i = files.Count - 1; i >= 0; i-- )
			{
				if ( !imageExts.Contains( Path.GetExtension( files[i] ).ToLower() ) )
				{
					files.RemoveAt( i );
				}
			}

			if ( files.Count == 0 )
			{
				return "目录内无图片";
			}

			// 输出文件夹
			string tempOutput = Path.Combine( TempPath, Path.GetFileName( path ) );
			string originalOutput = tempOutput;
			for ( int i = 1; Directory.Exists( tempOutput ); i++ )
			{
				// 如果文件夹重名, 加上数字
				tempOutput = originalOutput + string.Format( "({0})", i );
			}
			Directory.CreateDirectory( tempOutput );

			// 把图片缩放并存放到临时目录
			for ( int i = 0; i < files.Count; i++ )
			{
				ProgressComicFile( files[i], Path.Combine( tempOutput, i.ToString( "d6" ) + Path.GetExtension( files[i] ) ) );
				//File.Copy( files[i], Path.Combine( output, Path.GetFileName( files[i] ) ) );
			}

			ProgressComicToOutput( tempOutput );

			return "完成";
		}

		private static string ProgressComicFolder( string path )
		{
			return ProgressComicFolder( path, false );
		}

		/// <summary>
		/// 将临时目录中的漫画处理到输出目录
		/// </summary>
		private static void ProgressComicToOutput( string temp )
		{
			if ( Archive )
			{
				// 使用 SharpZipLib 生成压缩文档
				FastZip fz = new FastZip();
				fz.CreateEmptyDirectories = true;
				
				string zipfilePath = Path.Combine( OutputPath, Path.GetFileName( temp ) );
				string originalZipFilePath = zipfilePath;
				for ( int i = 1; File.Exists( zipfilePath + ".zip" ); i++ )
				{
					zipfilePath = originalZipFilePath + string.Format( "({0})", i );
				}
				zipfilePath = zipfilePath + ".zip";
				fz.CreateZip( zipfilePath, temp, false, "" );
				fz = null;
			}
			else
			{
				string outputPath = Path.Combine( OutputPath, Path.GetFileName( temp ) );
				string originalOutput = outputPath;
				for ( int i = 1; Directory.Exists( outputPath ); i++ )
				{
					outputPath = originalOutput + string.Format( "({0})", i );
				}
				_computer.FileSystem.CopyDirectory( temp, outputPath );
			}

		}

		/// <summary>
		/// 处理单张图片
		/// </summary>
		/// <param name="p"></param>
		/// <param name="p_2"></param>
		private static void ProgressComicFile( string source, string dest )
		{
			Bitmap bitmap = new Bitmap( source );
			if ( Width > 0 )
			{
				bitmap = ImageHelper.Resize( bitmap, Width, 0, ImageHelper.ResizeMode.Scale );
				ImageHelper.SaveAsJpeg( bitmap, dest, 80 );
				bitmap.Dispose();
			}
			else
			{
				File.Copy( source, dest );
			}
		}

		/// <summary>
		/// 输出目录
		/// </summary>
		public static string OutputPath { get; set; }

		/// <summary>
		/// 程序目录
		/// </summary>
		public static string AppPath { get; set; }

		/// <summary>
		/// 临时目录
		/// </summary>
		public static string TempPath
		{
			get
			{
				return Path.Combine( AppPath, "temp" );
			}
		}

		public static int _quality = 89;
		/// <summary>
		/// 质量
		/// </summary>
		public static int Quality
		{
			get
			{
				if ( _quality <= 0 || _quality > 100 )
				{
					return 89;
				}
				else
				{
					return _quality;
				}
			}
			set
			{
				_quality = value;
			}
		}

		/// <summary>
		/// 是否输出成压缩文件
		/// </summary>
		public static bool Archive { get; set; }

		/// <summary>
		/// 缩放宽度, 0为保持原大
		/// </summary>
		public static int Width { get; set; }

		/// <summary>
		/// 是否切割双页漫画
		/// </summary>
		public static bool SplitTowPage { get; set; }

		/// <summary>
		/// 阅读顺序
		/// </summary>
		public static ReadOrderEnum ReadOrder { get; set; }

		/// <summary>
		/// 阅读顺序枚举
		/// </summary>
		public enum ReadOrderEnum
		{
			/// <summary>
			/// 从右到左(日本漫画)
			/// </summary>
			RightToLeft,

			/// <summary>
			/// 从左到右(美漫,港漫)
			/// </summary>
			LeftToRight
		}
	}
}
