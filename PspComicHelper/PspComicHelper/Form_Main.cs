using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace PspComicHelper
{
	/// <summary>
	/// 主窗体
	/// </summary>
	public partial class Form_Main : Form
	{
		// 定义漫画处理进度委托
		private delegate void ComicProgressCallback( int index, string status );

		// 处理进度回调
		private ComicProgressCallback _callback;

		// 需要处理的总数
		private int _processCount;
		// 处理完成的总数
		private int _completeCount;
		
		// 预设宽度
		private List<ComboBoxItem> _widthDic = new List<ComboBoxItem>()
		{
			new ComboBoxItem() { Name = "请选择...", Value = 0 },
			new ComboBoxItem() { Name = "PSP (480px)", Value = 480 },
			new ComboBoxItem() { Name = "PSP*2 (960px)", Value = 960 },
			new ComboBoxItem() { Name = "魅族M8 (720px)", Value = 720 }
		};
		

		public Form_Main()
		{
			InitializeComponent();
			_callback = new ComicProgressCallback( UpdateStatus );
			ComicHelper.AppPath = Application.StartupPath;

			comboBox_setting_presetWidth.DataSource = _widthDic;
			comboBox_setting_presetWidth.DisplayMember = "Name";
			comboBox_setting_presetWidth.ValueMember = "Value";
		}

		/// <summary>
		/// 添加文件按钮点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_AddFile_Click( object sender, EventArgs e )
		{
			if ( openFileDialog_AddFile.ShowDialog() == DialogResult.OK )
			{
				foreach ( string file in openFileDialog_AddFile.FileNames )
				{
					listView_FileList.Items.Add( new ListViewItem( new string[] { file, "准备" } ) );
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
			if ( folderBrowserDialog_AddFolder.ShowDialog() == DialogResult.OK )
			{
				listView_FileList.Items.Add( new ListViewItem( new string[] { folderBrowserDialog_AddFolder.SelectedPath, "准备" } ) );
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

				this.Invoke( _callback, new object[]{ i, "处理中..." } );
				result = ComicHelper.ProgressComicPath( list[i][0] );
				this.Invoke( _callback, new object[]{ i, result } );
			}
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
		/// 开始按钮点击
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Start_Click( object sender, EventArgs e )
		{
			if ( string.IsNullOrEmpty( textBox_Output.Text.Trim() ) )
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

			ComicHelper.OutputPath = textBox_Output.Text.Trim();
			

			ComicHelper.Width = 480;
			ComicHelper.Archive = true;

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
			if ( Directory.Exists( ComicHelper.TempPath ) )
			{
				try
				{
					Directory.Delete( ComicHelper.TempPath, true );
				}
				catch ( IOException ioe )
				{
					// 删除临时目录失败
					MessageBox.Show( "删除临时目录失败，您可以手工删除程序文件夹下的temp目录。" );
				}
			}
		}



		private class ComboBoxItem
		{
			public string Name { get; set; }
			public int Value { get; set; }
		}

		

	}

	
}
