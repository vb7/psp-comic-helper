﻿namespace PspComicHelper
{
	partial class Form_Main
	{
		/// <summary>
		/// 必需的设计器变量。
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// 清理所有正在使用的资源。
		/// </summary>
		/// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
		protected override void Dispose( bool disposing )
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose( disposing );
		}

		#region Windows 窗体设计器生成的代码

		/// <summary>
		/// 设计器支持所需的方法 - 不要
		/// 使用代码编辑器修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_Main ) );
			this.statusStrip_MainStatus = new System.Windows.Forms.StatusStrip();
			this.toolStripStatusLabel_StatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
			this.tabControl_Main = new System.Windows.Forms.TabControl();
			this.tabPage_App = new System.Windows.Forms.TabPage();
			this.panel_Left = new System.Windows.Forms.Panel();
			this.listView_FileList = new System.Windows.Forms.ListView();
			this.columnHeader_Path = new System.Windows.Forms.ColumnHeader();
			this.columnHeader_Status = new System.Windows.Forms.ColumnHeader();
			this.panel_Left_Bottom = new System.Windows.Forms.Panel();
			this.textBox_Output = new System.Windows.Forms.TextBox();
			this.label_Output = new System.Windows.Forms.Label();
			this.panel_right = new System.Windows.Forms.Panel();
			this.button_SetOutput = new System.Windows.Forms.Button();
			this.button_Start = new System.Windows.Forms.Button();
			this.button_AddFile = new System.Windows.Forms.Button();
			this.button_AddFolder = new System.Windows.Forms.Button();
			this.tabPage_Setting = new System.Windows.Forms.TabPage();
			this.openFileDialog_AddFile = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog_AddFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.folderBrowserDialog_Output = new System.Windows.Forms.FolderBrowserDialog();
			this.statusStrip_MainStatus.SuspendLayout();
			this.tabControl_Main.SuspendLayout();
			this.tabPage_App.SuspendLayout();
			this.panel_Left.SuspendLayout();
			this.panel_Left_Bottom.SuspendLayout();
			this.panel_right.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip_MainStatus
			// 
			this.statusStrip_MainStatus.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel_StatusLabel} );
			this.statusStrip_MainStatus.Location = new System.Drawing.Point( 0, 311 );
			this.statusStrip_MainStatus.Name = "statusStrip_MainStatus";
			this.statusStrip_MainStatus.Size = new System.Drawing.Size( 472, 22 );
			this.statusStrip_MainStatus.TabIndex = 0;
			// 
			// toolStripStatusLabel_StatusLabel
			// 
			this.toolStripStatusLabel_StatusLabel.Name = "toolStripStatusLabel_StatusLabel";
			this.toolStripStatusLabel_StatusLabel.Size = new System.Drawing.Size( 29, 17 );
			this.toolStripStatusLabel_StatusLabel.Text = "状态";
			// 
			// tabControl_Main
			// 
			this.tabControl_Main.Controls.Add( this.tabPage_App );
			this.tabControl_Main.Controls.Add( this.tabPage_Setting );
			this.tabControl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl_Main.Location = new System.Drawing.Point( 0, 0 );
			this.tabControl_Main.Name = "tabControl_Main";
			this.tabControl_Main.SelectedIndex = 0;
			this.tabControl_Main.Size = new System.Drawing.Size( 472, 311 );
			this.tabControl_Main.TabIndex = 1;
			// 
			// tabPage_App
			// 
			this.tabPage_App.Controls.Add( this.panel_Left );
			this.tabPage_App.Controls.Add( this.panel_right );
			this.tabPage_App.Location = new System.Drawing.Point( 4, 21 );
			this.tabPage_App.Name = "tabPage_App";
			this.tabPage_App.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage_App.Size = new System.Drawing.Size( 464, 286 );
			this.tabPage_App.TabIndex = 0;
			this.tabPage_App.Text = "操作";
			this.tabPage_App.UseVisualStyleBackColor = true;
			// 
			// panel_Left
			// 
			this.panel_Left.Controls.Add( this.listView_FileList );
			this.panel_Left.Controls.Add( this.panel_Left_Bottom );
			this.panel_Left.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel_Left.Location = new System.Drawing.Point( 3, 3 );
			this.panel_Left.Name = "panel_Left";
			this.panel_Left.Size = new System.Drawing.Size( 370, 280 );
			this.panel_Left.TabIndex = 4;
			// 
			// listView_FileList
			// 
			this.listView_FileList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Path,
            this.columnHeader_Status} );
			this.listView_FileList.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView_FileList.Location = new System.Drawing.Point( 0, 0 );
			this.listView_FileList.Name = "listView_FileList";
			this.listView_FileList.Size = new System.Drawing.Size( 370, 246 );
			this.listView_FileList.TabIndex = 0;
			this.listView_FileList.UseCompatibleStateImageBehavior = false;
			this.listView_FileList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader_Path
			// 
			this.columnHeader_Path.Text = "路径";
			this.columnHeader_Path.Width = 300;
			// 
			// columnHeader_Status
			// 
			this.columnHeader_Status.Text = "状态";
			this.columnHeader_Status.Width = 66;
			// 
			// panel_Left_Bottom
			// 
			this.panel_Left_Bottom.Controls.Add( this.textBox_Output );
			this.panel_Left_Bottom.Controls.Add( this.label_Output );
			this.panel_Left_Bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panel_Left_Bottom.Location = new System.Drawing.Point( 0, 246 );
			this.panel_Left_Bottom.Name = "panel_Left_Bottom";
			this.panel_Left_Bottom.Size = new System.Drawing.Size( 370, 34 );
			this.panel_Left_Bottom.TabIndex = 1;
			// 
			// textBox_Output
			// 
			this.textBox_Output.Location = new System.Drawing.Point( 64, 8 );
			this.textBox_Output.Name = "textBox_Output";
			this.textBox_Output.Size = new System.Drawing.Size( 301, 21 );
			this.textBox_Output.TabIndex = 1;
			this.textBox_Output.DoubleClick += new System.EventHandler( this.textBox_Output_DoubleClick );
			// 
			// label_Output
			// 
			this.label_Output.AutoSize = true;
			this.label_Output.Location = new System.Drawing.Point( 5, 11 );
			this.label_Output.Name = "label_Output";
			this.label_Output.Size = new System.Drawing.Size( 53, 12 );
			this.label_Output.TabIndex = 0;
			this.label_Output.Text = "输出路径";
			// 
			// panel_right
			// 
			this.panel_right.Controls.Add( this.button_SetOutput );
			this.panel_right.Controls.Add( this.button_Start );
			this.panel_right.Controls.Add( this.button_AddFile );
			this.panel_right.Controls.Add( this.button_AddFolder );
			this.panel_right.Dock = System.Windows.Forms.DockStyle.Right;
			this.panel_right.Location = new System.Drawing.Point( 373, 3 );
			this.panel_right.Name = "panel_right";
			this.panel_right.Size = new System.Drawing.Size( 88, 280 );
			this.panel_right.TabIndex = 3;
			// 
			// button_SetOutput
			// 
			this.button_SetOutput.Location = new System.Drawing.Point( 3, 61 );
			this.button_SetOutput.Name = "button_SetOutput";
			this.button_SetOutput.Size = new System.Drawing.Size( 85, 23 );
			this.button_SetOutput.TabIndex = 4;
			this.button_SetOutput.Text = "输出路径";
			this.button_SetOutput.UseVisualStyleBackColor = true;
			this.button_SetOutput.Click += new System.EventHandler( this.button_SetOutput_Click );
			// 
			// button_Start
			// 
			this.button_Start.Location = new System.Drawing.Point( 3, 90 );
			this.button_Start.Name = "button_Start";
			this.button_Start.Size = new System.Drawing.Size( 85, 23 );
			this.button_Start.TabIndex = 3;
			this.button_Start.Text = "开始";
			this.button_Start.UseVisualStyleBackColor = true;
			this.button_Start.Click += new System.EventHandler( this.button_Start_Click );
			// 
			// button_AddFile
			// 
			this.button_AddFile.Location = new System.Drawing.Point( 3, 3 );
			this.button_AddFile.Name = "button_AddFile";
			this.button_AddFile.Size = new System.Drawing.Size( 85, 23 );
			this.button_AddFile.TabIndex = 1;
			this.button_AddFile.Text = "添加压缩文档";
			this.button_AddFile.UseVisualStyleBackColor = true;
			this.button_AddFile.Click += new System.EventHandler( this.button_AddFile_Click );
			// 
			// button_AddFolder
			// 
			this.button_AddFolder.Location = new System.Drawing.Point( 3, 32 );
			this.button_AddFolder.Name = "button_AddFolder";
			this.button_AddFolder.Size = new System.Drawing.Size( 85, 23 );
			this.button_AddFolder.TabIndex = 2;
			this.button_AddFolder.Text = "添加目录";
			this.button_AddFolder.UseVisualStyleBackColor = true;
			this.button_AddFolder.Click += new System.EventHandler( this.button_AddDir_Click );
			// 
			// tabPage_Setting
			// 
			this.tabPage_Setting.Location = new System.Drawing.Point( 4, 21 );
			this.tabPage_Setting.Name = "tabPage_Setting";
			this.tabPage_Setting.Padding = new System.Windows.Forms.Padding( 3 );
			this.tabPage_Setting.Size = new System.Drawing.Size( 464, 286 );
			this.tabPage_Setting.TabIndex = 1;
			this.tabPage_Setting.Text = "设置";
			this.tabPage_Setting.UseVisualStyleBackColor = true;
			// 
			// openFileDialog_AddFile
			// 
			this.openFileDialog_AddFile.Filter = "压缩文档(*.zip;*.rar)|*.zip;*.rar";
			this.openFileDialog_AddFile.Multiselect = true;
			// 
			// Form_Main
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF( 6F, 12F );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size( 472, 333 );
			this.Controls.Add( this.tabControl_Main );
			this.Controls.Add( this.statusStrip_MainStatus );
			this.Icon = ( (System.Drawing.Icon)( resources.GetObject( "$this.Icon" ) ) );
			this.MinimumSize = new System.Drawing.Size( 480, 360 );
			this.Name = "Form_Main";
			this.Text = "PSP Comic Helper";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.Form_Main_FormClosing );
			this.statusStrip_MainStatus.ResumeLayout( false );
			this.statusStrip_MainStatus.PerformLayout();
			this.tabControl_Main.ResumeLayout( false );
			this.tabPage_App.ResumeLayout( false );
			this.panel_Left.ResumeLayout( false );
			this.panel_Left_Bottom.ResumeLayout( false );
			this.panel_Left_Bottom.PerformLayout();
			this.panel_right.ResumeLayout( false );
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip_MainStatus;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_StatusLabel;
		private System.Windows.Forms.TabControl tabControl_Main;
		private System.Windows.Forms.TabPage tabPage_App;
		private System.Windows.Forms.ListView listView_FileList;
		private System.Windows.Forms.TabPage tabPage_Setting;
		private System.Windows.Forms.Button button_AddFolder;
		private System.Windows.Forms.Button button_AddFile;
		private System.Windows.Forms.OpenFileDialog openFileDialog_AddFile;
		private System.Windows.Forms.ColumnHeader columnHeader_Path;
		private System.Windows.Forms.Panel panel_right;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_AddFolder;
		private System.Windows.Forms.Button button_Start;
		private System.Windows.Forms.ColumnHeader columnHeader_Status;
		private System.Windows.Forms.Panel panel_Left;
		private System.Windows.Forms.Panel panel_Left_Bottom;
		private System.Windows.Forms.Label label_Output;
		private System.Windows.Forms.TextBox textBox_Output;
		private System.Windows.Forms.Button button_SetOutput;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog_Output;

	}
}

