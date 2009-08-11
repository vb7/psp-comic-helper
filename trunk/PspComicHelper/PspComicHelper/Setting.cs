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
		/// 宽 实际设定
		/// </summary>
		public static int Width_Actual { get; set; }

		/// <summary>
		/// 是否限定宽度
		/// </summary>
		public static bool EnableWidth { get; set; }

		/// <summary>
		/// 宽
		/// </summary>
		public static int Width 
		{
			get { return EnableWidth ? Width_Actual : 0; }
			set { Width_Actual = value; }
		}

		/// <summary>
		/// 高 实际设定
		/// </summary>
		public static int Height_Actual { get; set; }

		/// <summary>
		/// 是否限定高度
		/// </summary>
		public static bool EnableHeight { get; set; }

		/// <summary>
		/// 高度
		/// </summary>
		public static int Height
		{
			get { return EnableHeight ? Height_Actual : 0; }
			set { Height_Actual = value; }
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
			EnableWidth = true;
			Width_Actual = 480;
			EnableHeight = false;
			Height_Actual = 0;
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
					EnableWidth = Convert.ToBoolean( reader.ReadLine() );
					Width_Actual = Convert.ToInt32( reader.ReadLine() );
					EnableHeight = Convert.ToBoolean( reader.ReadLine() );
					Height_Actual = Convert.ToInt32( reader.ReadLine() );
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
			writer.WriteLine( EnableWidth );
			writer.WriteLine( Width_Actual );
			writer.WriteLine( EnableHeight );
			writer.WriteLine( Height_Actual );
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
