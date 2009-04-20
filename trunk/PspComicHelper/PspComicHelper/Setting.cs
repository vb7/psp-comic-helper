using System;
using System.IO;

namespace PspComicHelper
{
	/// <summary>
	/// 用户设置
	/// </summary>
	public static class Setting
	{
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

		/// <summary>
		/// 打开文件对话框初始目录
		/// </summary>
		public static string OpenInitialDirectory { get; set; }

		/// <summary>
		/// 宽
		/// </summary>
		public static int Width { get; set; }


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
		/// 是否切割双页漫画
		/// </summary>
		public static bool SplitTowPage { get; set; }

		/// <summary>
		/// 阅读顺序
		/// </summary>
		public static ReadOrderEnum ReadOrder { get; set; }

		/// <summary>
		/// 输出压缩包
		/// </summary>
		public static bool OutputZip { get; set; }


		private const string SETTING_FILE = "setting.ini";

		public static void Init()
		{
			OutputPath = "";
			Width = 480;
			Quality = 80;
			SplitTowPage = true;
			ReadOrder = ReadOrderEnum.RightToLeft;
			OutputZip = true;
		}

		/// <summary>
		/// 读取设置
		/// </summary>
		public static void Load()
		{
			if ( File.Exists( SETTING_FILE ) )
			{
				StreamReader reader = new StreamReader( Path.Combine( AppPath, SETTING_FILE ), System.Text.Encoding.Default );
				try
				{
					OutputPath = reader.ReadLine();
					OpenInitialDirectory = reader.ReadLine();
					Width = Convert.ToInt32( reader.ReadLine() );
					Quality = Convert.ToInt32( reader.ReadLine() );
					SplitTowPage = Convert.ToBoolean( reader.ReadLine() );
					ReadOrder = (ReadOrderEnum)Convert.ToInt32( reader.ReadLine() );
					OutputZip = Convert.ToBoolean( reader.ReadLine() );
				}
				catch
				{
					Init();
				}
				finally
				{
					reader.Close();
					reader.Dispose();
				}
			}
			else
			{
				Init();
			}
			
		}

		/// <summary>
		/// 保存设置
		/// </summary>
		public static void Save()
		{
			StreamWriter writer = new StreamWriter( Path.Combine( AppPath, SETTING_FILE ), false, System.Text.Encoding.Default );
			writer.WriteLine( OutputPath );
			writer.WriteLine( OpenInitialDirectory );
			writer.WriteLine( Width );
			writer.WriteLine( Quality );
			writer.WriteLine( SplitTowPage );
			writer.WriteLine( (int)ReadOrder );
			writer.WriteLine( OutputZip );
			writer.Flush();
			writer.Close();
			writer.Dispose();
		}


	}

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
