using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;

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

		/// <summary>
		/// 状态栏文字
		/// </summary>
		private List<string> _statusString = new List<string>()
		{
			"处理中... -",
			"处理中... \\",
			"处理中... |",
			"处理中... /"
		};

		/// <summary>
		/// 经过时间
		/// </summary>
		private int _timePass = 0;
		
		// 预设宽度
		private List<ComboBoxItem> _widthDic = new List<ComboBoxItem>()
		{
			new ComboBoxItem() { Name = "PSP (480px)", Value = 480 },
			new ComboBoxItem() { Name = "PSP*2 (960px)", Value = 960 },
			new ComboBoxItem() { Name = "魅族M8 (720px)", Value = 720 }
		};
		

		public Form_Main()
		{
			InitializeComponent();
			_progressCallback = new ComicProgressCallback( UpdateStatus );
			_completeCallback = new ComicCompleteCallback( SetFormStatus_Complete );
			InitSetting();

			comboBox_setting_presetWidth.DataSource = _widthDic;
			comboBox_setting_presetWidth.DisplayMember = "Name";
			comboBox_setting_presetWidth.ValueMember = "Value";
		}


		/// <summary>
		/// 漫画处理
		/// </summary>
		private void ComicProcess( object arg )
		{
			string result;
			string[][] list = arg as string[][];

			for ( int i = 0; i < list.Length; i++ )
			{
				if ( list[i][1] != "准备" )
				{
					continue;
				}

				this.Invoke( _progressCallback, new object[]{ i, "处理中..." } );
				result = ComicHelper.ProgressComicPath( list[i][0] );
				this.Invoke( _progressCallback, new object[]{ i, result } );
			}
			this.Invoke( _completeCallback );
		}

		/// <summary>
		/// 更新UI
		/// </summary>
		/// <param name="index"></param>
		/// <param name="status"></param>
		private void UpdateStatus( int index, string status )
		{
			listView_FileList.Items[index].SubItems[1].Text = status;
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
				if ( item.SubItems[1].Text == "准备" )
				{
					_processCount++;
					list.Add( new string[] { item.Text, item.SubItems[1].Text } );
				}
				else
				{
					_completeCount++;
				}
			}
			ThreadPool.QueueUserWorkItem( new WaitCallback( ComicProcess ), list.ToArray() );
		}


		/// <summary>
		/// 初始化设置
		/// </summary>
		private void InitSetting()
		{
			Setting.AppPath = Application.StartupPath;
			Setting.Load();

			textBox_setting_width.Text = Setting.Width.ToString();
			textBox_setting_quality.Text = Setting.Quality.ToString();
			checkBox_setting_split.Checked = Setting.SplitTowPage;
			radioButton_setting_sequence_right.Checked = ( Setting.ReadOrder == ReadOrderEnum.RightToLeft );
			radioButton_setting_sequence_left.Checked = ( Setting.ReadOrder == ReadOrderEnum.LeftToRight );
			checkBox_setting_zip.Checked = Setting.OutputZip;
			textBox_Output.Text = Setting.OutputPath;
		}

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
		/// 更新设置
		/// </summary>
		private void UpdateSetting()
		{
			if( IsNumeric( textBox_setting_width.Text ) )
				Setting.Width = Convert.ToInt32( textBox_setting_width.Text );

			if( IsNumeric( textBox_setting_quality.Text ) )
				Setting.Quality = Convert.ToInt32( textBox_setting_quality.Text );

			Setting.SplitTowPage = checkBox_setting_split.Checked;

			if( radioButton_setting_sequence_right.Checked )
				Setting.ReadOrder = ReadOrderEnum.RightToLeft;
			else if( radioButton_setting_sequence_left.Checked )
				Setting.ReadOrder = ReadOrderEnum.LeftToRight;

			Setting.OutputZip = checkBox_setting_zip.Checked;
			Setting.OutputPath = textBox_Output.Text;
		}

		/// <summary>
		/// 设置窗体状态 开始
		/// </summary>
		private void SetFormStatus_Started()
		{
			button_AddFile.Enabled = false;
			button_AddFolder.Enabled = false;
			button_deletePath.Enabled = false;
			button_SetOutput.Enabled =false;
			button_Start.Enabled = false;
			//toolStripStatusLabel_StatusLabel.Text = "处理中...";
			_timePass = 0;
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
			toolStripStatusLabel_StatusLabel.Text = string.Format( "完成, 耗时{0}秒", _timePass );
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
				if ( ext == ".zip" || ext == ".rar" )
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

			if( success )
				listView_FileList.Items.Add( new ListViewItem( new string[] { path, "准备" } ) );

			return success;
		}

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
				bool duplicate = false;

				foreach ( string file in openFileDialog_AddFile.FileNames )
				{
					if( AddPath( file ) )
						addCount++;
				}

				if ( addCount == 0 )
				{
					MessageBox.Show( "请勿重复添加" );
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
					MessageBox.Show( "请勿重复添加" );
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
			if ( Directory.Exists( Setting.TempPath ) )
			{
				try
				{
					Directory.Delete( Setting.TempPath, true );
				}
				catch ( IOException ioe )
				{
					// 删除临时目录失败
					MessageBox.Show( "删除临时目录失败，您可以手工删除程序文件夹下的temp目录。" );
				}
			}
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
		/// 定时器 更新状态栏文字
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void timer_processing_Tick( object sender, EventArgs e )
		{
			_timePass++;
			toolStripStatusLabel_StatusLabel.Text = _statusString[ _timePass % _statusString.Count ];
		}

		/// <summary>
		/// 下拉列表变更
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void comboBox_setting_presetWidth_SelectedIndexChanged( object sender, EventArgs e )
		{
			textBox_setting_width.Text = ( comboBox_setting_presetWidth.SelectedItem as ComboBoxItem ).Value.ToString();
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
		/// ComboBox选项
		/// </summary>
		private class ComboBoxItem
		{
			public string Name { get; set; }
			public int Value { get; set; }
		}
		

	}

	
}
