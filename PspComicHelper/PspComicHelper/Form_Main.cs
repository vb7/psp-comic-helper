using System;
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
		private ComicProgressCallback callback;

		// 需要处理的总数
		private int processCount;
		// 处理完成的总数
		private int completeCount;
		
		//private Queue<UpdateStatusArg> updateQueue = new Queue<UpdateStatusArg>();
		

		public Form_Main()
		{
			InitializeComponent();
			callback = new ComicProgressCallback( UpdateStatus );
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

				this.Invoke( callback, new object[]{ i, "处理中..." } );
				result = ComicHelper.ProgressComicPath( list[i][0] );
				this.Invoke( callback, new object[]{ i, result } );
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
			processCount = 0;
			completeCount = 0;
			List<string[]> list = new List<string[]>();

			foreach ( ListViewItem item in listView_FileList.Items )
			{
				if ( item.SubItems[1].Text == "准备" )
				{
					processCount++;
					list.Add( new string[] { item.Text, item.SubItems[1].Text } );
				}
				else
				{
					completeCount++;
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
			ComicHelper.AppPath = Application.StartupPath;

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

		/// <summary>
		/// 更新状态参数对象
		/// </summary>
		private class UpdateStatusArg
		{
			internal int Index { get; set; }

			internal string Status { get; set; }
		}
	}

	
}
