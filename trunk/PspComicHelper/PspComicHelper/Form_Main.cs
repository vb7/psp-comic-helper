using System;
using System.Collections.Generic;
using System.Drawing;
using System.Resources;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Globalization;

namespace PspComicHelper
{
	/// <summary>
	/// 主窗体
	/// </summary>
	public partial class Form_Main : Form
	{
		// 定义漫画处理进度委托
		private delegate void ComicProgressCallback( int index, string status );

		// 完成委托
		private delegate void ComicCompleteCallback();

		// 处理进度回调
		private ComicProgressCallback _progressCallback;

		// 完成回调
		private ComicCompleteCallback _completeCallback;

		// 需要处理的总数
		private int _processCount;
		// 处理完成的总数
		private int _completeCount;

		// ListView列索引
		private const int SUBITEM_INDEX_PATH = 0;
		private const int SUBITEM_INDEX_STATUS = 1;

		/// <summary>
		/// 状态栏文字
		/// </summary>
		private List<string> _statusString;

		/// <summary>
		/// 经过时间
		/// </summary>
		private int _timePass = 0;
		
		// 预设宽度
		private List<ComboBoxItemInt> _widthDic;

		// 预设高度
		private List<ComboBoxItemInt> _heightDic;

		/// <summary>
		/// 预设可设置语言
		/// </summary>
		private List<ComboBoxItemString> _languageDic;

		// 从资源文件读出的字符串
		string _text_fileList_Ready;
		string _text_fileList_Processing;
		string _text_fileList_Complete;

		string _text_message_Complete;// = "完成, 耗时{0}秒。";
		string _text_message_Duplication;// = "请勿重复添加。";
		string _text_message_DeleteFail;// = "可能还残存一些临时文件，您可以手工删除程序文件夹下的temp目录。";
		string _text_message_languageChange; // = "语言修改将会在下次启动时生效";

		IDictionary<ComicProgressResult,string> _text_comicProgressResult_Dict;


		public Form_Main()
		{
			InitResourceText();
			InitSetting();
			SetCulture();
			InitializeComponent();
			_progressCallback = new ComicProgressCallback( UpdateStatus );
			_completeCallback = new ComicCompleteCallback( SetFormStatus_Complete );
			UpdateSettingUI();
			InitComboBox();
		}


		#region 漫画处理


		/// <summary>
		/// 漫画处理
		/// </summary>
		private void ComicProcess( object arg )
		{
			ComicProgressResult result;
			string resultStr;
			string[][] list = arg as string[][];

			for ( int i = 0; i < list.Length; i++ )
			{
				if ( list[i][SUBITEM_INDEX_STATUS] != _text_fileList_Ready )
				{
					continue;
				}

				this.Invoke( _progressCallback, new object[]{ i, _text_fileList_Processing } );
				result = ComicHelper.ProgressComicPath( list[i][0] );
				resultStr = GetComicProgressResultString( result );
				this.Invoke( _progressCallback, new object[]{ i, resultStr } );
			}
			this.Invoke( _completeCallback );
		}


		/// <summary>
		/// 开始漫画处理进程
		/// </summary>
		private void StartComicProcess()
		{
			_processCount = 0;
			_completeCount = 0;
			List<string[]> list = new List<string[]>();

			foreach ( ListViewItem item in listView_FileList.Items )
			{
				if ( item.SubItems[SUBITEM_INDEX_STATUS].Text == _text_fileList_Ready )
				{
					_processCount++;
					list.Add( new string[] { item.Text, item.SubItems[SUBITEM_INDEX_STATUS].Text } );
				}
				else
				{
					_completeCount++;
				}
			}
			ThreadPool.QueueUserWorkItem( new WaitCallback( ComicProcess ), list.ToArray() );
		}


		/// <summary>
		/// 添加路径
		/// </summary>
		/// <param name="path"></param>
		private bool AddPath( string path )
		{
			bool success = false;
			string ext;

			if ( File.Exists( path ) )
			{
				ext = Path.GetExtension( path ).ToLower();
				if ( ext == ".zip"
					|| ext == ".rar"
					|| ext == ".cbr"
					|| ext == ".cbz"
					)
				{
					success = true;
				}
			}
			else if ( Directory.Exists( path ) )
			{
				success = true;
			}

			if ( success )
			{
				foreach ( ListViewItem item in listView_FileList.Items )
				{
					if ( item.Text == path )
					{
						success = false;
						break;
					}
				}
			}

			if ( success )
			{
				//listView_FileList.Items.Add( new ListViewItem( new string[] {path, "准备"} ) );
				listView_FileList.Items.Add( new ListViewItem( new string[] { path, _text_fileList_Ready } ) );
			}

			return success;
		}


		#endregion 漫画处理

		#region 设置


		/// <summary>
		/// 初始化设置
		/// </summary>
		private void InitSetting()
		{
			Setting.AppPath = Application.StartupPath;
			Setting.Load();

		}

		/// <summary>
		/// 更新设置UI
		/// </summary>
		private void UpdateSettingUI()
		{
			checkBox_setting_witth.Checked = Setting.EnableWidth;
			textBox_setting_width.Text = Setting.Width_Actual.ToString();
			checkBox_setting_height.Checked = Setting.EnableHeight;
			textBox_setting_height.Text = Setting.Height_Actual.ToString();
			textBox_setting_quality.Text = Setting.Quality.ToString();
			checkBox_setting_split.Checked = Setting.SplitTowPage;
			radioButton_setting_sequence_right.Checked = ( Setting.ReadOrder == ReadOrderEnum.RightToLeft );
			radioButton_setting_sequence_left.Checked = ( Setting.ReadOrder == ReadOrderEnum.LeftToRight );
			checkBox_setting_zip.Checked = Setting.OutputZip;
			checkBox_setting_cutMargin.Checked = Setting.AutoCutMargin;
			textBox_setting_threshold.Text = Setting.Threshold.ToString();
			radioButton_setting_resizeMode_scale.Checked = ( Setting.Mode == ImageHelper.ResizeMode.Scale );
			radioButton_setting_resizeMode_center.Checked = ( Setting.Mode == ImageHelper.ResizeMode.Center );
			radioButton_setting_resizeMode_stretch.Checked = ( Setting.Mode == ImageHelper.ResizeMode.Stretch );
			textBox_Output.Text = Setting.OutputPath;
			comboBox_setting_language.SelectedValue = Setting.Language;

		}

		/// <summary>
		/// 更新设置
		/// </summary>
		private void UpdateSetting()
		{
			Setting.EnableWidth = checkBox_setting_witth.Checked;
			if ( IsNumeric( textBox_setting_width.Text ) )
				Setting.Width_Actual = Convert.ToInt32( textBox_setting_width.Text );

			Setting.EnableHeight = checkBox_setting_height.Checked;
			if ( IsNumeric( textBox_setting_height.Text ) )
				Setting.Height_Actual = Convert.ToInt32( textBox_setting_height.Text );

			if ( IsNumeric( textBox_setting_quality.Text ) )
				Setting.Quality = Convert.ToInt32( textBox_setting_quality.Text );

			Setting.SplitTowPage = checkBox_setting_split.Checked;

			if ( radioButton_setting_sequence_right.Checked )
				Setting.ReadOrder = ReadOrderEnum.RightToLeft;
			else if ( radioButton_setting_sequence_left.Checked )
				Setting.ReadOrder = ReadOrderEnum.LeftToRight;

			Setting.OutputZip = checkBox_setting_zip.Checked;
			Setting.AutoCutMargin = checkBox_setting_cutMargin.Checked;
			Setting.Threshold = Convert.ToInt32( textBox_setting_threshold.Text );

			if ( radioButton_setting_resizeMode_scale.Checked )
				Setting.Mode = ImageHelper.ResizeMode.Scale;
			else if ( radioButton_setting_resizeMode_center.Checked )
				Setting.Mode = ImageHelper.ResizeMode.Center;
			else if ( radioButton_setting_resizeMode_stretch.Checked )
				Setting.Mode = ImageHelper.ResizeMode.Stretch;

			Setting.OutputPath = textBox_Output.Text;
			Setting.Language = comboBox_setting_language.SelectedValue.ToString();
		}

		/// <summary>
		/// 设置语言下拉框
		/// </summary>
		private void SetLanguageComboBox()
		{
			foreach ( var item in comboBox_setting_language.Items )
			{
				var cbi = item as ComboBoxItemString;
				if( cbi == null )
					continue;
				if ( cbi.Value == Setting.Language )
				{
					comboBox_setting_language.SelectedItem = item;
					break;
				}
			}
		}

		/// <summary>
		/// 设置语言
		/// </summary>
		private void SetCulture()
		{
			if ( !string.IsNullOrEmpty( Setting.Language ) )
			{
				Thread.CurrentThread.CurrentUICulture = new CultureInfo( Setting.Language );
			}
		}


		#endregion 设置

		#region 更新UI


		/// <summary>
		/// 更新UI
		/// </summary>
		/// <param name="index"></param>
		/// <param name="status"></param>
		private void UpdateStatus( int index, string status )
		{
			listView_FileList.Items[index].SubItems[SUBITEM_INDEX_STATUS].Text = status;
			for ( int i = 0; i < listView_FileList.Items.Count; i++ )
			{
				if ( i == index && status != _text_fileList_Complete )
				{
					listView_FileList.Items[i].BackColor = Color.Pink;
				}
				else
				{
					listView_FileList.Items[i].BackColor = Color.White;
				}

			}
		}




		/// <summary>
		/// 设置窗体状态 开始
		/// </summary>
		private void SetFormStatus_Started()
		{
			button_AddFile.Enabled = false;
			button_AddFolder.Enabled = false;
			button_deletePath.Enabled = false;
			button_SetOutput.Enabled = false;
			button_Start.Enabled = false;
			//toolStripStatusLabel_StatusLabel.Text = "处理中...";
			_timePass = 0;
			toolStripProgressBar_progress.Visible = true;
			timer_processing.Start();
		}

		/// <summary>
		/// 设置窗体状态 完成
		/// </summary>
		private void SetFormStatus_Complete()
		{
			button_AddFile.Enabled = true;
			button_AddFolder.Enabled = true;
			button_deletePath.Enabled = true;
			button_SetOutput.Enabled = true;
			button_Start.Enabled = true;
			timer_processing.Stop();
			toolStripStatusLabel_StatusLabel.Text = string.Format( _text_message_Complete, _timePass );
			toolStripProgressBar_progress.Visible = false;
			MinimizeMemory();
		}



		#endregion

		#region 通用方法

		/// <summary>
		/// 判断是否数字
		/// </summary>
		/// <param name="text"></param>
		/// <returns></returns>
		private bool IsNumeric( string text )
		{
			return System.Text.RegularExpressions.Regex.IsMatch( text, "^\\d+$" );
		}




		/// <summary>
		/// 释放内存
		/// </summary>
		private void MinimizeMemory()
		{
			System.Diagnostics.Process.GetCurrentProcess().MaxWorkingSet = new IntPtr( 750000 );
		}


		#endregion 通用方法

		#region 控件事件响应

		/// <summary>
		/// 添加文件按钮点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_AddFile_Click( object sender, EventArgs e )
		{
			openFileDialog_AddFile.InitialDirectory = Setting.OpenInitialDirectory;

			if ( openFileDialog_AddFile.ShowDialog() == DialogResult.OK )
			{
				Setting.OpenInitialDirectory = Path.GetDirectoryName( openFileDialog_AddFile.FileName );

				int addCount = 0;

				foreach ( string file in openFileDialog_AddFile.FileNames )
				{
					if( AddPath( file ) )
						addCount++;
				}

				if ( addCount == 0 )
				{
					MessageBox.Show( _text_message_Duplication );
				}
			}
		}

		/// <summary>
		/// 添加目录文件夹点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_AddDir_Click( object sender, EventArgs e )
		{
			folderBrowserDialog_AddFolder.SelectedPath = Setting.OpenInitialDirectory;

			if ( folderBrowserDialog_AddFolder.ShowDialog() == DialogResult.OK )
			{
				Setting.OpenInitialDirectory = folderBrowserDialog_AddFolder.SelectedPath;

				if ( !AddPath( folderBrowserDialog_AddFolder.SelectedPath ) )
				{
					MessageBox.Show( _text_message_Duplication );
				}
			}
		}

		/// <summary>
		/// 删除选中项
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_deletePath_Click( object sender, EventArgs e )
		{
			foreach ( ListViewItem item in listView_FileList.SelectedItems )
			{
				listView_FileList.Items.Remove( item );
			}
		}


		/// <summary>
		/// 设置输出路径按钮点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_SetOutput_Click( object sender, EventArgs e )
		{
			if ( folderBrowserDialog_Output.ShowDialog() == DialogResult.OK )
			{
				textBox_Output.Text = folderBrowserDialog_Output.SelectedPath;
			}
		}

		/// <summary>
		/// 双击输出路径文本框
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_Output_DoubleClick( object sender, EventArgs e )
		{
			if ( folderBrowserDialog_Output.ShowDialog() == DialogResult.OK )
			{
				textBox_Output.Text = folderBrowserDialog_Output.SelectedPath;
			}
		}




		/// <summary>
		/// 开始按钮点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Start_Click( object sender, EventArgs e )
		{
			if( string.IsNullOrEmpty( textBox_Output.Text.Trim() ) )
			{
				if ( folderBrowserDialog_Output.ShowDialog() == DialogResult.OK )
				{
					textBox_Output.Text = folderBrowserDialog_Output.SelectedPath;
				}
				else
				{
					return;
				}
			}

			UpdateSetting();
			SetFormStatus_Started();
			StartComicProcess();
		}

		/// <summary>
		/// 管理窗口执行操作
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Main_FormClosing( object sender, FormClosingEventArgs e )
		{
			// 删除临时目录
			if( !ComicHelper.DeleteDirectory( Setting.TempPath ) )
			{
				MessageBox.Show( _text_message_DeleteFail );
			}
			UpdateSetting();
			Setting.Save();
		}




		/// <summary>
		/// 控制宽度只能是数字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_setting_width_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar > 57 || ( e.KeyChar > 8 && e.KeyChar < 47 ) || e.KeyChar < 8 )
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// 控制质量只能是数字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_setting_quality_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar > 57 || ( e.KeyChar > 8 && e.KeyChar < 47 ) || e.KeyChar < 8 )
			{
				e.Handled = true;
			}

		}

		/// <summary>
		/// 控制质量不能大于100
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_setting_quality_KeyUp( object sender, KeyEventArgs e )
		{
			TextBox textbox = sender as TextBox;
			if ( ( textbox.Text.Length > 2 ) && ( Convert.ToInt32( textbox.Text ) > 100 ) )
			{
				textbox.Text = "100";
			}
		}

		/// <summary>
		/// 控制边界值只能是数字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_setting_threshold_KeyPress( object sender, KeyPressEventArgs e )
		{
			if ( e.KeyChar > 57 || ( e.KeyChar > 8 && e.KeyChar < 47 ) || e.KeyChar < 8 )
			{
				e.Handled = true;
			}
		}

		/// <summary>
		/// 控制边界值不能大于255
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void textBox_setting_threshold_KeyUp( object sender, KeyEventArgs e )
		{
			TextBox textbox = sender as TextBox;
			if ( ( textbox.Text.Length > 3 ) && ( Convert.ToInt32( textbox.Text ) > 255 ) )
			{
				textbox.Text = "255";
			}
		}
		/// <summary>
		/// 定时器 更新状态栏文字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_processing_Tick( object sender, EventArgs e )
		{
			_timePass++;
			toolStripStatusLabel_StatusLabel.Text = _statusString[ _timePass % _statusString.Count ];
			toolStripProgressBar_progress.Value = ComicHelper.RateOfProgress;
		}

		/// <summary>
		/// 宽度预设下拉列表变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_setting_presetWidth_SelectedIndexChanged( object sender, EventArgs e )
		{
			if ( ( comboBox_setting_presetWidth.SelectedItem as ComboBoxItemInt ).Value > 0 )
			{
				textBox_setting_width.Text = ( comboBox_setting_presetWidth.SelectedItem as ComboBoxItemInt ).Value.ToString();
			}
		}

		/// <summary>
		/// 高度预设下拉列表变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_setting_presetHeight_SelectedIndexChanged( object sender, EventArgs e )
		{
			if ( ( comboBox_setting_presetHeight.SelectedItem as ComboBoxItemInt ).Value > 0 )
			{
				textBox_setting_height.Text = ( comboBox_setting_presetHeight.SelectedItem as ComboBoxItemInt ).Value.ToString();
			}
		}


		/// <summary>
		/// 文件拖拽
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Main_DragDrop( object sender, DragEventArgs e )
		{
			//string path = ( (System.Array)e.Data.GetData( DataFormats.FileDrop ) ).GetValue( 0 ).ToString();
			//MessageBox.Show( path );
			string path;
			for( int i = 0; i < ( (System.Array)e.Data.GetData( DataFormats.FileDrop ) ).Length; i++ )
			{
				path = ( (System.Array)e.Data.GetData( DataFormats.FileDrop ) ).GetValue( i ).ToString();
				AddPath( path );
			}
		}

		/// <summary>
		/// 文件拖拽
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Main_DragEnter( object sender, DragEventArgs e )
		{
			if ( e.Data.GetDataPresent( DataFormats.FileDrop ) )
				e.Effect = DragDropEffects.Link;
			else e.Effect = DragDropEffects.None;
		}

		/// <summary>
		/// 窗体第一次显示
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form_Main_Shown( object sender, EventArgs e )
		{
			MinimizeMemory();
		}


		/// <summary>
		/// 缩放模式图片点击 适应
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox_setting_resizeMode_scale_Click( object sender, EventArgs e )
		{
			radioButton_setting_resizeMode_scale.Checked = true;
		}

		/// <summary>
		/// 缩放模式图片点击 填充
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox_setting_resizeMode_center_Click( object sender, EventArgs e )
		{
			radioButton_setting_resizeMode_center.Checked = true;
		}

		/// <summary>
		/// 缩放模式图片点击 拉伸
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void pictureBox_setting_resizeMode_stretch_Click( object sender, EventArgs e )
		{
			radioButton_setting_resizeMode_stretch.Checked = true;
		}


		#endregion 控件事件响应

		#region 初始化 资源 多语言

		/// <summary>
		/// 初始化下拉选单
		/// </summary>
		private void InitComboBox()
		{
			comboBox_setting_presetWidth.DataSource		= _widthDic;
			comboBox_setting_presetWidth.DisplayMember	= "Name";
			comboBox_setting_presetWidth.ValueMember	= "Value";

			comboBox_setting_presetHeight.DataSource	= _heightDic;
			comboBox_setting_presetHeight.DisplayMember = "Name";
			comboBox_setting_presetHeight.ValueMember	= "Value";

			comboBox_setting_language.DataSource		= _languageDic;
			comboBox_setting_language.DisplayMember		= "Name";
			comboBox_setting_language.ValueMember		= "Value";
		}


		/// <summary>
		/// 初始化资源字符串
		/// </summary>
		private void InitResourceText()
		{
			ResourceManager rm = new ResourceManager( typeof( TextResource ) );

			_text_fileList_Ready		= rm.GetString( "Text_FileList_Ready" );
			_text_fileList_Processing	= rm.GetString( "Text_FileList_Processing" );
			_text_fileList_Complete		= rm.GetString( "Text_FileList_Complete" );

			_text_message_Complete		= rm.GetString( "Text_Message_Complete" );
			_text_message_Duplication	= rm.GetString( "Text_Message_Duplication" );
			_text_message_DeleteFail	= rm.GetString( "Text_Message_DeleteFail" );

			_statusString = new List<string>
			{
				rm.GetString( "Text_StatusBar_Processing_1" ),
				rm.GetString( "Text_StatusBar_Processing_2" ),
				rm.GetString( "Text_StatusBar_Processing_3" ),
				rm.GetString( "Text_StatusBar_Processing_4" ),
			};

			_widthDic = new List<ComboBoxItemInt>()
			{
				new ComboBoxItemInt { Name = rm.GetString( "Text_ComboBox_Select" ), Value = 0 },
				new ComboBoxItemInt { Name = "PSP (480px)", Value = 480 },
				new ComboBoxItemInt { Name = "PSP*2 (960px)", Value = 960 },
				new ComboBoxItemInt { Name = "Meizu M8 (720px)", Value = 720 },
				new ComboBoxItemInt { Name = "iPhone (480px)", Value = 480 }
			};

			_heightDic = new List<ComboBoxItemInt>()
			{
				new ComboBoxItemInt { Name = rm.GetString( "Text_ComboBox_Select" ), Value = 0 },
				new ComboBoxItemInt { Name = "Sony Reader ?", Value = 754 }
			};

			_languageDic = new List<ComboBoxItemString>
			{
				new ComboBoxItemString { Name = "Auto", Value = "" },
				new ComboBoxItemString { Name = "English", Value = "en" },
				new ComboBoxItemString { Name = "简体中文", Value = "zh-CHS" }
			};

			_text_comicProgressResult_Dict = new Dictionary<ComicProgressResult,string> {
				{ ComicProgressResult.Complete,				rm.GetString( "Text_ProgressResult_Complete" ) },
				{ ComicProgressResult.PathError,			rm.GetString( "Text_ProgressResult_PathError" ) },
				{ ComicProgressResult.UnsupportedArchive,	rm.GetString( "Text_ProgressResult_UnsupportedArchive" ) },
				{ ComicProgressResult.NoneImageInFolder,	rm.GetString( "Text_ProgressResult_NoneImageInFolder" ) }
			};

		}

		/// <summary>
		/// 取得漫画处理结果的字符串
		/// </summary>
		/// <param name="result"></param>
		/// <returns></returns>
		public string GetComicProgressResultString( ComicProgressResult result )
		{
			if ( _text_comicProgressResult_Dict.Keys.Contains( result ) )
				return _text_comicProgressResult_Dict[result];
			else
				return "";
		}

		#endregion 初始化 资源 多语言


		#region ComboBox选项内部类

		/// <summary>
		/// ComboBox选项 数字
		/// </summary>
		private class ComboBoxItemInt
		{
			public string Name { get; set; }
			public int Value { get; set; }
		}

		/// <summary>
		/// ComboBox选项 字符串
		/// </summary>
		private class ComboBoxItemString
		{
			public string Name { get; set; }
			public string Value { get; set; }
		}

		#endregion

	}

	
}
