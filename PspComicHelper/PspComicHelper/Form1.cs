using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace PspComicHelper
{
	/// <summary>
	/// 主窗体
	/// </summary>
	public partial class Form_Main : Form
	{
		public Form_Main()
		{
			InitializeComponent();
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
					listView_FileList.Items.Add( new ListViewItem( new string[] { file, "0", "准备" } ) );
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
				listView_FileList.Items.Add( new ListViewItem( new string[] { folderBrowserDialog_AddFolder.SelectedPath, "0", "准备" } ) );
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
			ComicHelper.OutputPath = textBox_Output.Text;
			foreach ( ListViewItem item in listView_FileList.Items )
			{
				item.SubItems[2].Text = "处理中...";
				ComicHelper.ProgressComicPath( item.SubItems[0].Text );
				item.SubItems[2].Text = "完成";
			}
		}



	}
}
