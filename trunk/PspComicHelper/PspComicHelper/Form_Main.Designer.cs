namespace PspComicHelper
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
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager( typeof( Form_Main ) );
			this.statusStrip_MainStatus = new System.Windows.Forms.StatusStrip();
			this.toolStripProgressBar_progress = new System.Windows.Forms.ToolStripProgressBar();
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
			this.button_deletePath = new System.Windows.Forms.Button();
			this.button_SetOutput = new System.Windows.Forms.Button();
			this.button_Start = new System.Windows.Forms.Button();
			this.button_AddFile = new System.Windows.Forms.Button();
			this.button_AddFolder = new System.Windows.Forms.Button();
			this.tabPage_Setting1 = new System.Windows.Forms.TabPage();
			this.panel_setting_resizeMode = new System.Windows.Forms.Panel();
			this.pictureBox_setting_resizeMode_scale = new System.Windows.Forms.PictureBox();
			this.radioButton_setting_resizeMode_stretch = new System.Windows.Forms.RadioButton();
			this.pictureBox_setting_resizeMode_stretch = new System.Windows.Forms.PictureBox();
			this.radioButton_setting_resizeMode_center = new System.Windows.Forms.RadioButton();
			this.pictureBox_setting_resizeMode_center = new System.Windows.Forms.PictureBox();
			this.radioButton_setting_resizeMode_scale = new System.Windows.Forms.RadioButton();
			this.label_setting_resizeMode = new System.Windows.Forms.Label();
			this.textBox_setting_threshold = new System.Windows.Forms.TextBox();
			this.label_setting_threshold = new System.Windows.Forms.Label();
			this.label_setting_cutMargin = new System.Windows.Forms.Label();
			this.checkBox_setting_cutMargin = new System.Windows.Forms.CheckBox();
			this.checkBox_setting_height = new System.Windows.Forms.CheckBox();
			this.comboBox_setting_presetHeight = new System.Windows.Forms.ComboBox();
			this.textBox_setting_height = new System.Windows.Forms.TextBox();
			this.label_setting_height = new System.Windows.Forms.Label();
			this.checkBox_setting_witth = new System.Windows.Forms.CheckBox();
			this.textBox_setting_quality = new System.Windows.Forms.TextBox();
			this.label_setting_quality = new System.Windows.Forms.Label();
			this.comboBox_setting_presetWidth = new System.Windows.Forms.ComboBox();
			this.textBox_setting_width = new System.Windows.Forms.TextBox();
			this.label_setting_width = new System.Windows.Forms.Label();
			this.tabPage_Setting2 = new System.Windows.Forms.TabPage();
			this.checkBox_setting_zip = new System.Windows.Forms.CheckBox();
			this.radioButton_setting_sequence_right = new System.Windows.Forms.RadioButton();
			this.radioButton_setting_sequence_left = new System.Windows.Forms.RadioButton();
			this.checkBox_setting_split = new System.Windows.Forms.CheckBox();
			this.label_setting_zip = new System.Windows.Forms.Label();
			this.label_setting_sequence = new System.Windows.Forms.Label();
			this.label_setting_split = new System.Windows.Forms.Label();
			this.label_setting_languagePrompt = new System.Windows.Forms.Label();
			this.comboBox_setting_language = new System.Windows.Forms.ComboBox();
			this.label_setting_language = new System.Windows.Forms.Label();
			this.openFileDialog_AddFile = new System.Windows.Forms.OpenFileDialog();
			this.folderBrowserDialog_AddFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.folderBrowserDialog_Output = new System.Windows.Forms.FolderBrowserDialog();
			this.timer_processing = new System.Windows.Forms.Timer( this.components );
			this.statusStrip_MainStatus.SuspendLayout();
			this.tabControl_Main.SuspendLayout();
			this.tabPage_App.SuspendLayout();
			this.panel_Left.SuspendLayout();
			this.panel_Left_Bottom.SuspendLayout();
			this.panel_right.SuspendLayout();
			this.tabPage_Setting1.SuspendLayout();
			this.panel_setting_resizeMode.SuspendLayout();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_scale ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_stretch ) ).BeginInit();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_center ) ).BeginInit();
			this.tabPage_Setting2.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusStrip_MainStatus
			// 
			this.statusStrip_MainStatus.AccessibleDescription = null;
			this.statusStrip_MainStatus.AccessibleName = null;
			resources.ApplyResources( this.statusStrip_MainStatus, "statusStrip_MainStatus" );
			this.statusStrip_MainStatus.BackgroundImage = null;
			this.statusStrip_MainStatus.Font = null;
			this.statusStrip_MainStatus.Items.AddRange( new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar_progress,
            this.toolStripStatusLabel_StatusLabel} );
			this.statusStrip_MainStatus.Name = "statusStrip_MainStatus";
			// 
			// toolStripProgressBar_progress
			// 
			this.toolStripProgressBar_progress.AccessibleDescription = null;
			this.toolStripProgressBar_progress.AccessibleName = null;
			resources.ApplyResources( this.toolStripProgressBar_progress, "toolStripProgressBar_progress" );
			this.toolStripProgressBar_progress.Name = "toolStripProgressBar_progress";
			// 
			// toolStripStatusLabel_StatusLabel
			// 
			this.toolStripStatusLabel_StatusLabel.AccessibleDescription = null;
			this.toolStripStatusLabel_StatusLabel.AccessibleName = null;
			resources.ApplyResources( this.toolStripStatusLabel_StatusLabel, "toolStripStatusLabel_StatusLabel" );
			this.toolStripStatusLabel_StatusLabel.BackgroundImage = null;
			this.toolStripStatusLabel_StatusLabel.Name = "toolStripStatusLabel_StatusLabel";
			// 
			// tabControl_Main
			// 
			this.tabControl_Main.AccessibleDescription = null;
			this.tabControl_Main.AccessibleName = null;
			resources.ApplyResources( this.tabControl_Main, "tabControl_Main" );
			this.tabControl_Main.BackgroundImage = null;
			this.tabControl_Main.Controls.Add( this.tabPage_App );
			this.tabControl_Main.Controls.Add( this.tabPage_Setting1 );
			this.tabControl_Main.Controls.Add( this.tabPage_Setting2 );
			this.tabControl_Main.Font = null;
			this.tabControl_Main.Name = "tabControl_Main";
			this.tabControl_Main.SelectedIndex = 0;
			// 
			// tabPage_App
			// 
			this.tabPage_App.AccessibleDescription = null;
			this.tabPage_App.AccessibleName = null;
			resources.ApplyResources( this.tabPage_App, "tabPage_App" );
			this.tabPage_App.BackgroundImage = null;
			this.tabPage_App.Controls.Add( this.panel_Left );
			this.tabPage_App.Controls.Add( this.panel_right );
			this.tabPage_App.Font = null;
			this.tabPage_App.Name = "tabPage_App";
			this.tabPage_App.UseVisualStyleBackColor = true;
			// 
			// panel_Left
			// 
			this.panel_Left.AccessibleDescription = null;
			this.panel_Left.AccessibleName = null;
			resources.ApplyResources( this.panel_Left, "panel_Left" );
			this.panel_Left.BackgroundImage = null;
			this.panel_Left.Controls.Add( this.listView_FileList );
			this.panel_Left.Controls.Add( this.panel_Left_Bottom );
			this.panel_Left.Font = null;
			this.panel_Left.Name = "panel_Left";
			// 
			// listView_FileList
			// 
			this.listView_FileList.AccessibleDescription = null;
			this.listView_FileList.AccessibleName = null;
			resources.ApplyResources( this.listView_FileList, "listView_FileList" );
			this.listView_FileList.BackgroundImage = null;
			this.listView_FileList.Columns.AddRange( new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader_Path,
            this.columnHeader_Status} );
			this.listView_FileList.Font = null;
			this.listView_FileList.Name = "listView_FileList";
			this.listView_FileList.UseCompatibleStateImageBehavior = false;
			this.listView_FileList.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader_Path
			// 
			resources.ApplyResources( this.columnHeader_Path, "columnHeader_Path" );
			// 
			// columnHeader_Status
			// 
			resources.ApplyResources( this.columnHeader_Status, "columnHeader_Status" );
			// 
			// panel_Left_Bottom
			// 
			this.panel_Left_Bottom.AccessibleDescription = null;
			this.panel_Left_Bottom.AccessibleName = null;
			resources.ApplyResources( this.panel_Left_Bottom, "panel_Left_Bottom" );
			this.panel_Left_Bottom.BackgroundImage = null;
			this.panel_Left_Bottom.Controls.Add( this.textBox_Output );
			this.panel_Left_Bottom.Controls.Add( this.label_Output );
			this.panel_Left_Bottom.Font = null;
			this.panel_Left_Bottom.Name = "panel_Left_Bottom";
			// 
			// textBox_Output
			// 
			this.textBox_Output.AccessibleDescription = null;
			this.textBox_Output.AccessibleName = null;
			resources.ApplyResources( this.textBox_Output, "textBox_Output" );
			this.textBox_Output.BackgroundImage = null;
			this.textBox_Output.Font = null;
			this.textBox_Output.Name = "textBox_Output";
			this.textBox_Output.DoubleClick += new System.EventHandler( this.textBox_Output_DoubleClick );
			// 
			// label_Output
			// 
			this.label_Output.AccessibleDescription = null;
			this.label_Output.AccessibleName = null;
			resources.ApplyResources( this.label_Output, "label_Output" );
			this.label_Output.Font = null;
			this.label_Output.Name = "label_Output";
			// 
			// panel_right
			// 
			this.panel_right.AccessibleDescription = null;
			this.panel_right.AccessibleName = null;
			resources.ApplyResources( this.panel_right, "panel_right" );
			this.panel_right.BackgroundImage = null;
			this.panel_right.Controls.Add( this.button_deletePath );
			this.panel_right.Controls.Add( this.button_SetOutput );
			this.panel_right.Controls.Add( this.button_Start );
			this.panel_right.Controls.Add( this.button_AddFile );
			this.panel_right.Controls.Add( this.button_AddFolder );
			this.panel_right.Font = null;
			this.panel_right.Name = "panel_right";
			// 
			// button_deletePath
			// 
			this.button_deletePath.AccessibleDescription = null;
			this.button_deletePath.AccessibleName = null;
			resources.ApplyResources( this.button_deletePath, "button_deletePath" );
			this.button_deletePath.BackgroundImage = null;
			this.button_deletePath.Font = null;
			this.button_deletePath.Name = "button_deletePath";
			this.button_deletePath.UseVisualStyleBackColor = true;
			this.button_deletePath.Click += new System.EventHandler( this.button_deletePath_Click );
			// 
			// button_SetOutput
			// 
			this.button_SetOutput.AccessibleDescription = null;
			this.button_SetOutput.AccessibleName = null;
			resources.ApplyResources( this.button_SetOutput, "button_SetOutput" );
			this.button_SetOutput.BackgroundImage = null;
			this.button_SetOutput.Font = null;
			this.button_SetOutput.Name = "button_SetOutput";
			this.button_SetOutput.UseVisualStyleBackColor = true;
			this.button_SetOutput.Click += new System.EventHandler( this.button_SetOutput_Click );
			// 
			// button_Start
			// 
			this.button_Start.AccessibleDescription = null;
			this.button_Start.AccessibleName = null;
			resources.ApplyResources( this.button_Start, "button_Start" );
			this.button_Start.BackgroundImage = null;
			this.button_Start.Font = null;
			this.button_Start.Name = "button_Start";
			this.button_Start.UseVisualStyleBackColor = true;
			this.button_Start.Click += new System.EventHandler( this.button_Start_Click );
			// 
			// button_AddFile
			// 
			this.button_AddFile.AccessibleDescription = null;
			this.button_AddFile.AccessibleName = null;
			resources.ApplyResources( this.button_AddFile, "button_AddFile" );
			this.button_AddFile.BackgroundImage = null;
			this.button_AddFile.Font = null;
			this.button_AddFile.Name = "button_AddFile";
			this.button_AddFile.UseVisualStyleBackColor = true;
			this.button_AddFile.Click += new System.EventHandler( this.button_AddFile_Click );
			// 
			// button_AddFolder
			// 
			this.button_AddFolder.AccessibleDescription = null;
			this.button_AddFolder.AccessibleName = null;
			resources.ApplyResources( this.button_AddFolder, "button_AddFolder" );
			this.button_AddFolder.BackgroundImage = null;
			this.button_AddFolder.Font = null;
			this.button_AddFolder.Name = "button_AddFolder";
			this.button_AddFolder.UseVisualStyleBackColor = true;
			this.button_AddFolder.Click += new System.EventHandler( this.button_AddDir_Click );
			// 
			// tabPage_Setting1
			// 
			this.tabPage_Setting1.AccessibleDescription = null;
			this.tabPage_Setting1.AccessibleName = null;
			resources.ApplyResources( this.tabPage_Setting1, "tabPage_Setting1" );
			this.tabPage_Setting1.BackgroundImage = null;
			this.tabPage_Setting1.Controls.Add( this.panel_setting_resizeMode );
			this.tabPage_Setting1.Controls.Add( this.label_setting_resizeMode );
			this.tabPage_Setting1.Controls.Add( this.textBox_setting_threshold );
			this.tabPage_Setting1.Controls.Add( this.label_setting_threshold );
			this.tabPage_Setting1.Controls.Add( this.label_setting_cutMargin );
			this.tabPage_Setting1.Controls.Add( this.checkBox_setting_cutMargin );
			this.tabPage_Setting1.Controls.Add( this.checkBox_setting_height );
			this.tabPage_Setting1.Controls.Add( this.comboBox_setting_presetHeight );
			this.tabPage_Setting1.Controls.Add( this.textBox_setting_height );
			this.tabPage_Setting1.Controls.Add( this.label_setting_height );
			this.tabPage_Setting1.Controls.Add( this.checkBox_setting_witth );
			this.tabPage_Setting1.Controls.Add( this.textBox_setting_quality );
			this.tabPage_Setting1.Controls.Add( this.label_setting_quality );
			this.tabPage_Setting1.Controls.Add( this.comboBox_setting_presetWidth );
			this.tabPage_Setting1.Controls.Add( this.textBox_setting_width );
			this.tabPage_Setting1.Controls.Add( this.label_setting_width );
			this.tabPage_Setting1.Font = null;
			this.tabPage_Setting1.Name = "tabPage_Setting1";
			this.tabPage_Setting1.UseVisualStyleBackColor = true;
			// 
			// panel_setting_resizeMode
			// 
			this.panel_setting_resizeMode.AccessibleDescription = null;
			this.panel_setting_resizeMode.AccessibleName = null;
			resources.ApplyResources( this.panel_setting_resizeMode, "panel_setting_resizeMode" );
			this.panel_setting_resizeMode.BackgroundImage = null;
			this.panel_setting_resizeMode.Controls.Add( this.pictureBox_setting_resizeMode_scale );
			this.panel_setting_resizeMode.Controls.Add( this.radioButton_setting_resizeMode_stretch );
			this.panel_setting_resizeMode.Controls.Add( this.pictureBox_setting_resizeMode_stretch );
			this.panel_setting_resizeMode.Controls.Add( this.radioButton_setting_resizeMode_center );
			this.panel_setting_resizeMode.Controls.Add( this.pictureBox_setting_resizeMode_center );
			this.panel_setting_resizeMode.Controls.Add( this.radioButton_setting_resizeMode_scale );
			this.panel_setting_resizeMode.Font = null;
			this.panel_setting_resizeMode.Name = "panel_setting_resizeMode";
			// 
			// pictureBox_setting_resizeMode_scale
			// 
			this.pictureBox_setting_resizeMode_scale.AccessibleDescription = null;
			this.pictureBox_setting_resizeMode_scale.AccessibleName = null;
			resources.ApplyResources( this.pictureBox_setting_resizeMode_scale, "pictureBox_setting_resizeMode_scale" );
			this.pictureBox_setting_resizeMode_scale.BackgroundImage = null;
			this.pictureBox_setting_resizeMode_scale.Font = null;
			this.pictureBox_setting_resizeMode_scale.Image = global::PspComicHelper.Properties.Resources.Scale;
			this.pictureBox_setting_resizeMode_scale.ImageLocation = null;
			this.pictureBox_setting_resizeMode_scale.InitialImage = null;
			this.pictureBox_setting_resizeMode_scale.Name = "pictureBox_setting_resizeMode_scale";
			this.pictureBox_setting_resizeMode_scale.TabStop = false;
			this.pictureBox_setting_resizeMode_scale.Click += new System.EventHandler( this.pictureBox_setting_resizeMode_scale_Click );
			// 
			// radioButton_setting_resizeMode_stretch
			// 
			this.radioButton_setting_resizeMode_stretch.AccessibleDescription = null;
			this.radioButton_setting_resizeMode_stretch.AccessibleName = null;
			resources.ApplyResources( this.radioButton_setting_resizeMode_stretch, "radioButton_setting_resizeMode_stretch" );
			this.radioButton_setting_resizeMode_stretch.BackgroundImage = null;
			this.radioButton_setting_resizeMode_stretch.Font = null;
			this.radioButton_setting_resizeMode_stretch.Name = "radioButton_setting_resizeMode_stretch";
			this.radioButton_setting_resizeMode_stretch.TabStop = true;
			this.radioButton_setting_resizeMode_stretch.UseVisualStyleBackColor = true;
			// 
			// pictureBox_setting_resizeMode_stretch
			// 
			this.pictureBox_setting_resizeMode_stretch.AccessibleDescription = null;
			this.pictureBox_setting_resizeMode_stretch.AccessibleName = null;
			resources.ApplyResources( this.pictureBox_setting_resizeMode_stretch, "pictureBox_setting_resizeMode_stretch" );
			this.pictureBox_setting_resizeMode_stretch.BackgroundImage = null;
			this.pictureBox_setting_resizeMode_stretch.Font = null;
			this.pictureBox_setting_resizeMode_stretch.Image = global::PspComicHelper.Properties.Resources.Stretch;
			this.pictureBox_setting_resizeMode_stretch.ImageLocation = null;
			this.pictureBox_setting_resizeMode_stretch.InitialImage = null;
			this.pictureBox_setting_resizeMode_stretch.Name = "pictureBox_setting_resizeMode_stretch";
			this.pictureBox_setting_resizeMode_stretch.TabStop = false;
			this.pictureBox_setting_resizeMode_stretch.Click += new System.EventHandler( this.pictureBox_setting_resizeMode_stretch_Click );
			// 
			// radioButton_setting_resizeMode_center
			// 
			this.radioButton_setting_resizeMode_center.AccessibleDescription = null;
			this.radioButton_setting_resizeMode_center.AccessibleName = null;
			resources.ApplyResources( this.radioButton_setting_resizeMode_center, "radioButton_setting_resizeMode_center" );
			this.radioButton_setting_resizeMode_center.BackgroundImage = null;
			this.radioButton_setting_resizeMode_center.Font = null;
			this.radioButton_setting_resizeMode_center.Name = "radioButton_setting_resizeMode_center";
			this.radioButton_setting_resizeMode_center.TabStop = true;
			this.radioButton_setting_resizeMode_center.UseVisualStyleBackColor = true;
			// 
			// pictureBox_setting_resizeMode_center
			// 
			this.pictureBox_setting_resizeMode_center.AccessibleDescription = null;
			this.pictureBox_setting_resizeMode_center.AccessibleName = null;
			resources.ApplyResources( this.pictureBox_setting_resizeMode_center, "pictureBox_setting_resizeMode_center" );
			this.pictureBox_setting_resizeMode_center.BackgroundImage = null;
			this.pictureBox_setting_resizeMode_center.Font = null;
			this.pictureBox_setting_resizeMode_center.Image = global::PspComicHelper.Properties.Resources.Center;
			this.pictureBox_setting_resizeMode_center.ImageLocation = null;
			this.pictureBox_setting_resizeMode_center.InitialImage = null;
			this.pictureBox_setting_resizeMode_center.Name = "pictureBox_setting_resizeMode_center";
			this.pictureBox_setting_resizeMode_center.TabStop = false;
			this.pictureBox_setting_resizeMode_center.Click += new System.EventHandler( this.pictureBox_setting_resizeMode_center_Click );
			// 
			// radioButton_setting_resizeMode_scale
			// 
			this.radioButton_setting_resizeMode_scale.AccessibleDescription = null;
			this.radioButton_setting_resizeMode_scale.AccessibleName = null;
			resources.ApplyResources( this.radioButton_setting_resizeMode_scale, "radioButton_setting_resizeMode_scale" );
			this.radioButton_setting_resizeMode_scale.BackgroundImage = null;
			this.radioButton_setting_resizeMode_scale.Font = null;
			this.radioButton_setting_resizeMode_scale.Name = "radioButton_setting_resizeMode_scale";
			this.radioButton_setting_resizeMode_scale.TabStop = true;
			this.radioButton_setting_resizeMode_scale.UseVisualStyleBackColor = true;
			// 
			// label_setting_resizeMode
			// 
			this.label_setting_resizeMode.AccessibleDescription = null;
			this.label_setting_resizeMode.AccessibleName = null;
			resources.ApplyResources( this.label_setting_resizeMode, "label_setting_resizeMode" );
			this.label_setting_resizeMode.Font = null;
			this.label_setting_resizeMode.Name = "label_setting_resizeMode";
			// 
			// textBox_setting_threshold
			// 
			this.textBox_setting_threshold.AccessibleDescription = null;
			this.textBox_setting_threshold.AccessibleName = null;
			resources.ApplyResources( this.textBox_setting_threshold, "textBox_setting_threshold" );
			this.textBox_setting_threshold.BackgroundImage = null;
			this.textBox_setting_threshold.Font = null;
			this.textBox_setting_threshold.Name = "textBox_setting_threshold";
			this.textBox_setting_threshold.KeyUp += new System.Windows.Forms.KeyEventHandler( this.textBox_setting_threshold_KeyUp );
			this.textBox_setting_threshold.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox_setting_threshold_KeyPress );
			// 
			// label_setting_threshold
			// 
			this.label_setting_threshold.AccessibleDescription = null;
			this.label_setting_threshold.AccessibleName = null;
			resources.ApplyResources( this.label_setting_threshold, "label_setting_threshold" );
			this.label_setting_threshold.Font = null;
			this.label_setting_threshold.Name = "label_setting_threshold";
			// 
			// label_setting_cutMargin
			// 
			this.label_setting_cutMargin.AccessibleDescription = null;
			this.label_setting_cutMargin.AccessibleName = null;
			resources.ApplyResources( this.label_setting_cutMargin, "label_setting_cutMargin" );
			this.label_setting_cutMargin.Font = null;
			this.label_setting_cutMargin.Name = "label_setting_cutMargin";
			// 
			// checkBox_setting_cutMargin
			// 
			this.checkBox_setting_cutMargin.AccessibleDescription = null;
			this.checkBox_setting_cutMargin.AccessibleName = null;
			resources.ApplyResources( this.checkBox_setting_cutMargin, "checkBox_setting_cutMargin" );
			this.checkBox_setting_cutMargin.BackgroundImage = null;
			this.checkBox_setting_cutMargin.Font = null;
			this.checkBox_setting_cutMargin.Name = "checkBox_setting_cutMargin";
			this.checkBox_setting_cutMargin.UseVisualStyleBackColor = true;
			// 
			// checkBox_setting_height
			// 
			this.checkBox_setting_height.AccessibleDescription = null;
			this.checkBox_setting_height.AccessibleName = null;
			resources.ApplyResources( this.checkBox_setting_height, "checkBox_setting_height" );
			this.checkBox_setting_height.BackgroundImage = null;
			this.checkBox_setting_height.Font = null;
			this.checkBox_setting_height.Name = "checkBox_setting_height";
			this.checkBox_setting_height.UseVisualStyleBackColor = true;
			// 
			// comboBox_setting_presetHeight
			// 
			this.comboBox_setting_presetHeight.AccessibleDescription = null;
			this.comboBox_setting_presetHeight.AccessibleName = null;
			resources.ApplyResources( this.comboBox_setting_presetHeight, "comboBox_setting_presetHeight" );
			this.comboBox_setting_presetHeight.BackgroundImage = null;
			this.comboBox_setting_presetHeight.Font = null;
			this.comboBox_setting_presetHeight.FormattingEnabled = true;
			this.comboBox_setting_presetHeight.Name = "comboBox_setting_presetHeight";
			this.comboBox_setting_presetHeight.SelectedIndexChanged += new System.EventHandler( this.comboBox_setting_presetHeight_SelectedIndexChanged );
			// 
			// textBox_setting_height
			// 
			this.textBox_setting_height.AccessibleDescription = null;
			this.textBox_setting_height.AccessibleName = null;
			resources.ApplyResources( this.textBox_setting_height, "textBox_setting_height" );
			this.textBox_setting_height.BackgroundImage = null;
			this.textBox_setting_height.Font = null;
			this.textBox_setting_height.Name = "textBox_setting_height";
			this.textBox_setting_height.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox_setting_width_KeyPress );
			// 
			// label_setting_height
			// 
			this.label_setting_height.AccessibleDescription = null;
			this.label_setting_height.AccessibleName = null;
			resources.ApplyResources( this.label_setting_height, "label_setting_height" );
			this.label_setting_height.Font = null;
			this.label_setting_height.Name = "label_setting_height";
			// 
			// checkBox_setting_witth
			// 
			this.checkBox_setting_witth.AccessibleDescription = null;
			this.checkBox_setting_witth.AccessibleName = null;
			resources.ApplyResources( this.checkBox_setting_witth, "checkBox_setting_witth" );
			this.checkBox_setting_witth.BackgroundImage = null;
			this.checkBox_setting_witth.Font = null;
			this.checkBox_setting_witth.Name = "checkBox_setting_witth";
			this.checkBox_setting_witth.UseVisualStyleBackColor = true;
			// 
			// textBox_setting_quality
			// 
			this.textBox_setting_quality.AccessibleDescription = null;
			this.textBox_setting_quality.AccessibleName = null;
			resources.ApplyResources( this.textBox_setting_quality, "textBox_setting_quality" );
			this.textBox_setting_quality.BackgroundImage = null;
			this.textBox_setting_quality.Font = null;
			this.textBox_setting_quality.Name = "textBox_setting_quality";
			this.textBox_setting_quality.KeyUp += new System.Windows.Forms.KeyEventHandler( this.textBox_setting_quality_KeyUp );
			this.textBox_setting_quality.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox_setting_quality_KeyPress );
			// 
			// label_setting_quality
			// 
			this.label_setting_quality.AccessibleDescription = null;
			this.label_setting_quality.AccessibleName = null;
			resources.ApplyResources( this.label_setting_quality, "label_setting_quality" );
			this.label_setting_quality.Font = null;
			this.label_setting_quality.Name = "label_setting_quality";
			// 
			// comboBox_setting_presetWidth
			// 
			this.comboBox_setting_presetWidth.AccessibleDescription = null;
			this.comboBox_setting_presetWidth.AccessibleName = null;
			resources.ApplyResources( this.comboBox_setting_presetWidth, "comboBox_setting_presetWidth" );
			this.comboBox_setting_presetWidth.BackgroundImage = null;
			this.comboBox_setting_presetWidth.Font = null;
			this.comboBox_setting_presetWidth.FormattingEnabled = true;
			this.comboBox_setting_presetWidth.Name = "comboBox_setting_presetWidth";
			this.comboBox_setting_presetWidth.SelectedIndexChanged += new System.EventHandler( this.comboBox_setting_presetWidth_SelectedIndexChanged );
			// 
			// textBox_setting_width
			// 
			this.textBox_setting_width.AccessibleDescription = null;
			this.textBox_setting_width.AccessibleName = null;
			resources.ApplyResources( this.textBox_setting_width, "textBox_setting_width" );
			this.textBox_setting_width.BackgroundImage = null;
			this.textBox_setting_width.Font = null;
			this.textBox_setting_width.Name = "textBox_setting_width";
			this.textBox_setting_width.KeyPress += new System.Windows.Forms.KeyPressEventHandler( this.textBox_setting_width_KeyPress );
			// 
			// label_setting_width
			// 
			this.label_setting_width.AccessibleDescription = null;
			this.label_setting_width.AccessibleName = null;
			resources.ApplyResources( this.label_setting_width, "label_setting_width" );
			this.label_setting_width.Font = null;
			this.label_setting_width.Name = "label_setting_width";
			// 
			// tabPage_Setting2
			// 
			this.tabPage_Setting2.AccessibleDescription = null;
			this.tabPage_Setting2.AccessibleName = null;
			resources.ApplyResources( this.tabPage_Setting2, "tabPage_Setting2" );
			this.tabPage_Setting2.BackgroundImage = null;
			this.tabPage_Setting2.Controls.Add( this.checkBox_setting_zip );
			this.tabPage_Setting2.Controls.Add( this.radioButton_setting_sequence_right );
			this.tabPage_Setting2.Controls.Add( this.radioButton_setting_sequence_left );
			this.tabPage_Setting2.Controls.Add( this.checkBox_setting_split );
			this.tabPage_Setting2.Controls.Add( this.label_setting_zip );
			this.tabPage_Setting2.Controls.Add( this.label_setting_sequence );
			this.tabPage_Setting2.Controls.Add( this.label_setting_split );
			this.tabPage_Setting2.Controls.Add( this.label_setting_languagePrompt );
			this.tabPage_Setting2.Controls.Add( this.comboBox_setting_language );
			this.tabPage_Setting2.Controls.Add( this.label_setting_language );
			this.tabPage_Setting2.Font = null;
			this.tabPage_Setting2.Name = "tabPage_Setting2";
			this.tabPage_Setting2.UseVisualStyleBackColor = true;
			// 
			// checkBox_setting_zip
			// 
			this.checkBox_setting_zip.AccessibleDescription = null;
			this.checkBox_setting_zip.AccessibleName = null;
			resources.ApplyResources( this.checkBox_setting_zip, "checkBox_setting_zip" );
			this.checkBox_setting_zip.BackgroundImage = null;
			this.checkBox_setting_zip.Font = null;
			this.checkBox_setting_zip.Name = "checkBox_setting_zip";
			this.checkBox_setting_zip.UseVisualStyleBackColor = true;
			// 
			// radioButton_setting_sequence_right
			// 
			this.radioButton_setting_sequence_right.AccessibleDescription = null;
			this.radioButton_setting_sequence_right.AccessibleName = null;
			resources.ApplyResources( this.radioButton_setting_sequence_right, "radioButton_setting_sequence_right" );
			this.radioButton_setting_sequence_right.BackgroundImage = null;
			this.radioButton_setting_sequence_right.Font = null;
			this.radioButton_setting_sequence_right.Name = "radioButton_setting_sequence_right";
			this.radioButton_setting_sequence_right.TabStop = true;
			this.radioButton_setting_sequence_right.UseVisualStyleBackColor = true;
			// 
			// radioButton_setting_sequence_left
			// 
			this.radioButton_setting_sequence_left.AccessibleDescription = null;
			this.radioButton_setting_sequence_left.AccessibleName = null;
			resources.ApplyResources( this.radioButton_setting_sequence_left, "radioButton_setting_sequence_left" );
			this.radioButton_setting_sequence_left.BackgroundImage = null;
			this.radioButton_setting_sequence_left.Font = null;
			this.radioButton_setting_sequence_left.Name = "radioButton_setting_sequence_left";
			this.radioButton_setting_sequence_left.TabStop = true;
			this.radioButton_setting_sequence_left.UseVisualStyleBackColor = true;
			// 
			// checkBox_setting_split
			// 
			this.checkBox_setting_split.AccessibleDescription = null;
			this.checkBox_setting_split.AccessibleName = null;
			resources.ApplyResources( this.checkBox_setting_split, "checkBox_setting_split" );
			this.checkBox_setting_split.BackgroundImage = null;
			this.checkBox_setting_split.Font = null;
			this.checkBox_setting_split.Name = "checkBox_setting_split";
			this.checkBox_setting_split.UseVisualStyleBackColor = true;
			// 
			// label_setting_zip
			// 
			this.label_setting_zip.AccessibleDescription = null;
			this.label_setting_zip.AccessibleName = null;
			resources.ApplyResources( this.label_setting_zip, "label_setting_zip" );
			this.label_setting_zip.Font = null;
			this.label_setting_zip.Name = "label_setting_zip";
			// 
			// label_setting_sequence
			// 
			this.label_setting_sequence.AccessibleDescription = null;
			this.label_setting_sequence.AccessibleName = null;
			resources.ApplyResources( this.label_setting_sequence, "label_setting_sequence" );
			this.label_setting_sequence.Font = null;
			this.label_setting_sequence.Name = "label_setting_sequence";
			// 
			// label_setting_split
			// 
			this.label_setting_split.AccessibleDescription = null;
			this.label_setting_split.AccessibleName = null;
			resources.ApplyResources( this.label_setting_split, "label_setting_split" );
			this.label_setting_split.Font = null;
			this.label_setting_split.Name = "label_setting_split";
			// 
			// label_setting_languagePrompt
			// 
			this.label_setting_languagePrompt.AccessibleDescription = null;
			this.label_setting_languagePrompt.AccessibleName = null;
			resources.ApplyResources( this.label_setting_languagePrompt, "label_setting_languagePrompt" );
			this.label_setting_languagePrompt.Font = null;
			this.label_setting_languagePrompt.Name = "label_setting_languagePrompt";
			// 
			// comboBox_setting_language
			// 
			this.comboBox_setting_language.AccessibleDescription = null;
			this.comboBox_setting_language.AccessibleName = null;
			resources.ApplyResources( this.comboBox_setting_language, "comboBox_setting_language" );
			this.comboBox_setting_language.BackgroundImage = null;
			this.comboBox_setting_language.Font = null;
			this.comboBox_setting_language.FormattingEnabled = true;
			this.comboBox_setting_language.Name = "comboBox_setting_language";
			// 
			// label_setting_language
			// 
			this.label_setting_language.AccessibleDescription = null;
			this.label_setting_language.AccessibleName = null;
			resources.ApplyResources( this.label_setting_language, "label_setting_language" );
			this.label_setting_language.Font = null;
			this.label_setting_language.Name = "label_setting_language";
			// 
			// openFileDialog_AddFile
			// 
			resources.ApplyResources( this.openFileDialog_AddFile, "openFileDialog_AddFile" );
			this.openFileDialog_AddFile.Multiselect = true;
			// 
			// folderBrowserDialog_AddFolder
			// 
			resources.ApplyResources( this.folderBrowserDialog_AddFolder, "folderBrowserDialog_AddFolder" );
			// 
			// folderBrowserDialog_Output
			// 
			resources.ApplyResources( this.folderBrowserDialog_Output, "folderBrowserDialog_Output" );
			// 
			// timer_processing
			// 
			this.timer_processing.Interval = 1000;
			this.timer_processing.Tick += new System.EventHandler( this.timer_processing_Tick );
			// 
			// Form_Main
			// 
			this.AccessibleDescription = null;
			this.AccessibleName = null;
			this.AllowDrop = true;
			resources.ApplyResources( this, "$this" );
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = null;
			this.Controls.Add( this.tabControl_Main );
			this.Controls.Add( this.statusStrip_MainStatus );
			this.Font = null;
			this.Name = "Form_Main";
			this.Shown += new System.EventHandler( this.Form_Main_Shown );
			this.DragDrop += new System.Windows.Forms.DragEventHandler( this.Form_Main_DragDrop );
			this.DragEnter += new System.Windows.Forms.DragEventHandler( this.Form_Main_DragEnter );
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler( this.Form_Main_FormClosing );
			this.statusStrip_MainStatus.ResumeLayout( false );
			this.statusStrip_MainStatus.PerformLayout();
			this.tabControl_Main.ResumeLayout( false );
			this.tabPage_App.ResumeLayout( false );
			this.panel_Left.ResumeLayout( false );
			this.panel_Left_Bottom.ResumeLayout( false );
			this.panel_Left_Bottom.PerformLayout();
			this.panel_right.ResumeLayout( false );
			this.tabPage_Setting1.ResumeLayout( false );
			this.tabPage_Setting1.PerformLayout();
			this.panel_setting_resizeMode.ResumeLayout( false );
			this.panel_setting_resizeMode.PerformLayout();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_scale ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_stretch ) ).EndInit();
			( (System.ComponentModel.ISupportInitialize)( this.pictureBox_setting_resizeMode_center ) ).EndInit();
			this.tabPage_Setting2.ResumeLayout( false );
			this.tabPage_Setting2.PerformLayout();
			this.ResumeLayout( false );
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.StatusStrip statusStrip_MainStatus;
		private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_StatusLabel;
		private System.Windows.Forms.TabControl tabControl_Main;
		private System.Windows.Forms.TabPage tabPage_App;
		private System.Windows.Forms.ListView listView_FileList;
		private System.Windows.Forms.TabPage tabPage_Setting1;
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
		private System.Windows.Forms.TextBox textBox_setting_width;
		private System.Windows.Forms.ComboBox comboBox_setting_presetWidth;
		private System.Windows.Forms.Label label_setting_quality;
		private System.Windows.Forms.TextBox textBox_setting_quality;
		private System.Windows.Forms.Button button_deletePath;
		private System.Windows.Forms.Timer timer_processing;
		private System.Windows.Forms.CheckBox checkBox_setting_height;
		private System.Windows.Forms.ComboBox comboBox_setting_presetHeight;
		private System.Windows.Forms.TextBox textBox_setting_height;
		private System.Windows.Forms.Label label_setting_height;
		private System.Windows.Forms.CheckBox checkBox_setting_witth;
		private System.Windows.Forms.CheckBox checkBox_setting_cutMargin;
		private System.Windows.Forms.Label label_setting_cutMargin;
		private System.Windows.Forms.TextBox textBox_setting_threshold;
		private System.Windows.Forms.Label label_setting_threshold;
		private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar_progress;
		private System.Windows.Forms.Label label_setting_resizeMode;
		private System.Windows.Forms.Panel panel_setting_resizeMode;
		private System.Windows.Forms.PictureBox pictureBox_setting_resizeMode_scale;
		private System.Windows.Forms.RadioButton radioButton_setting_resizeMode_stretch;
		private System.Windows.Forms.PictureBox pictureBox_setting_resizeMode_stretch;
		private System.Windows.Forms.RadioButton radioButton_setting_resizeMode_center;
		private System.Windows.Forms.PictureBox pictureBox_setting_resizeMode_center;
		private System.Windows.Forms.RadioButton radioButton_setting_resizeMode_scale;
		private System.Windows.Forms.TabPage tabPage_Setting2;
		private System.Windows.Forms.Label label_setting_width;
		private System.Windows.Forms.Label label_setting_language;
		private System.Windows.Forms.ComboBox comboBox_setting_language;
		private System.Windows.Forms.Label label_setting_languagePrompt;
		private System.Windows.Forms.CheckBox checkBox_setting_zip;
		private System.Windows.Forms.RadioButton radioButton_setting_sequence_right;
		private System.Windows.Forms.RadioButton radioButton_setting_sequence_left;
		private System.Windows.Forms.CheckBox checkBox_setting_split;
		private System.Windows.Forms.Label label_setting_zip;
		private System.Windows.Forms.Label label_setting_sequence;
		private System.Windows.Forms.Label label_setting_split;

	}
}

