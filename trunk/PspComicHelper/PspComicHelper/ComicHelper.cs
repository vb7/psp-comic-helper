using System;
using System.IO;
using System.Collections.Generic;

namespace PspComicHelper
{
	/// <summary>
	/// 图片操作类
	/// </summary>
	public class ComicHelper
	{
		private static readonly List<string> imageExts = new List<string>(){ ".jpg", ".jpeg", ".png", ".gif", ".bmp" };

		/// <summary>
		/// 处理图片路径
		/// </summary>
		/// <param name="path"></param>
		public static string ProgressComicPath( string path )
		{
			if ( File.Exists( path ) )
			{
				return ProgressComicArchive( path );
			}
			else if ( Directory.Exists( path ) )
			{
				return ProgressComicFolder( path );
			}
			else
			{
				return "路径错误";
			}
		}

		/// <summary>
		/// 处理图片路径 压缩文档
		/// </summary>
		/// <param name="path"></param>
		private static string ProgressComicArchive( string path )
		{
			return "完成";
		}

		/// <summary>
		/// 处理图片路径 文件夹
		/// </summary>
		/// <param name="path"></param>
		private static string ProgressComicFolder( string path )
		{
			// 取得文件夹中所有图片文件
			List<string> files = new List<string>( Directory.GetFiles( path ) );
			for ( int i = files.Count - 1; i >= 0; i-- )
			{
				if ( !imageExts.Contains( Path.GetExtension( files[i] ).ToLower() ) )
				{
					files.RemoveAt( i );
				}
			}

			// 输出文件夹
			string output = Path.Combine( OutputPath, Path.GetFileName( path ) );
			string originalOutput = output;
			for ( int i = 1; Directory.Exists( output ); i++ )
			{
				// 如果文件夹重名, 加上数字
				output = originalOutput + string.Format( "({0})", i );
			}
			Directory.CreateDirectory( output );
			
			// 拷贝文件
			for ( int i = 0; i < files.Count; i++ )
			{
				File.Copy( files[i], Path.Combine( output, Path.GetFileName( files[i] ) ) );
			}

			return "完成";
		}

		/// <summary>
		/// 输出目录
		/// </summary>
		public static string OutputPath { get; set; }
	}
}
