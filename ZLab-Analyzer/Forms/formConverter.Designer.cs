namespace ZLab_Analyzer.Forms
{
    partial class form_converter
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(form_converter));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.ListViewGroup listViewGroup2 = new System.Windows.Forms.ListViewGroup("ListViewGroup", System.Windows.Forms.HorizontalAlignment.Left);
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title4 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend5 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title5 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend6 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Title title6 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.label_softwarename = new System.Windows.Forms.Label();
            this.lblInfo = new System.Windows.Forms.Label();
            this.btnExit = new System.Windows.Forms.Button();
            this.checkAutostart = new System.Windows.Forms.CheckBox();
            this.tabcontrol = new System.Windows.Forms.TabControl();
            this.tab_import = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.list_ImportStatus = new System.Windows.Forms.ListView();
            this.column_import_check = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_filename = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_problems = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_imagesfound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_animals = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_lines = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_duplicates = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_secpertrack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.column_import_duration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.button_import_next = new System.Windows.Forms.Button();
            this.button_cancel_files = new System.Windows.Forms.Button();
            this.tab_basic = new System.Windows.Forms.TabPage();
            this.button_basics_back = new System.Windows.Forms.Button();
            this.panel4 = new System.Windows.Forms.Panel();
            this.text_howto_basics = new System.Windows.Forms.TextBox();
            this.button_basic_next = new System.Windows.Forms.Button();
            this.check_clean_duplicates = new System.Windows.Forms.CheckBox();
            this.check_clean_invalidsum = new System.Windows.Forms.CheckBox();
            this.tab_thresholds = new System.Windows.Forms.TabPage();
            this.text_animal_threshold_max = new System.Windows.Forms.TextBox();
            this.label_thresholds_fish_lines = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.text_howto_thresholds = new System.Windows.Forms.TextBox();
            this.text_animal_threshold_min = new System.Windows.Forms.TextBox();
            this.label_thresholds_header_lines = new System.Windows.Forms.Label();
            this.button_thresholds_back = new System.Windows.Forms.Button();
            this.button_thresholds_next = new System.Windows.Forms.Button();
            this.label_thresholds_header_max = new System.Windows.Forms.Label();
            this.label_thresholds_header_min = new System.Windows.Forms.Label();
            this.label_thresholds_header_empty = new System.Windows.Forms.Label();
            this.label_thresholds_header_inactive = new System.Windows.Forms.Label();
            this.text_track_empty_max = new System.Windows.Forms.TextBox();
            this.text_track_inactive_max = new System.Windows.Forms.TextBox();
            this.label_thresholds_fish_empty = new System.Windows.Forms.Label();
            this.label_thresholds_fish_inactive = new System.Windows.Forms.Label();
            this.text_track_empty_min = new System.Windows.Forms.TextBox();
            this.text_track_inactive_min = new System.Windows.Forms.TextBox();
            this.label_thresholds_fish_fast = new System.Windows.Forms.Label();
            this.label_thresholds_fish_slow = new System.Windows.Forms.Label();
            this.label_thresholds_header_fast = new System.Windows.Forms.Label();
            this.label_thresholds_header_slow = new System.Windows.Forms.Label();
            this.text_track_slow_max = new System.Windows.Forms.TextBox();
            this.text_track_fast_max = new System.Windows.Forms.TextBox();
            this.text_track_fast_min = new System.Windows.Forms.TextBox();
            this.text_track_slow_min = new System.Windows.Forms.TextBox();
            this.tab_grouping = new System.Windows.Forms.TabPage();
            this.panel_grouping_groupnaming = new System.Windows.Forms.Panel();
            this.button_groupnaming_done = new System.Windows.Forms.Button();
            this.text_groupnaming_group9 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group9 = new System.Windows.Forms.Label();
            this.text_groupnaming_group8 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group8 = new System.Windows.Forms.Label();
            this.text_groupnaming_group7 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group7 = new System.Windows.Forms.Label();
            this.text_groupnaming_group6 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group6 = new System.Windows.Forms.Label();
            this.text_groupnaming_group5 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group5 = new System.Windows.Forms.Label();
            this.text_groupnaming_group4 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group4 = new System.Windows.Forms.Label();
            this.text_groupnaming_group3 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group3 = new System.Windows.Forms.Label();
            this.text_groupnaming_group2 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group2 = new System.Windows.Forms.Label();
            this.text_groupnaming_group1 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group1 = new System.Windows.Forms.Label();
            this.text_groupnaming_group0 = new System.Windows.Forms.TextBox();
            this.label_groupnaming_group0 = new System.Windows.Forms.Label();
            this.label_groupnaming_header = new System.Windows.Forms.Label();
            this.button_grouping_next = new System.Windows.Forms.Button();
            this.button_grouping_back = new System.Windows.Forms.Button();
            this.panel_grouping_multifiles = new System.Windows.Forms.Panel();
            this.txtGrouping_MultifileSelector = new System.Windows.Forms.ComboBox();
            this.label_grouping_multifiles_info = new System.Windows.Forms.Label();
            this.panel_Grouping_Tutorial = new System.Windows.Forms.Panel();
            this.text_howto_grouping = new System.Windows.Forms.TextBox();
            this.grid_grouping = new System.Windows.Forms.DataGridView();
            this.tab_results = new System.Windows.Forms.TabPage();
            this.list_Animals = new System.Windows.Forms.ListView();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel6 = new System.Windows.Forms.Panel();
            this.text_howto_results = new System.Windows.Forms.TextBox();
            this.button_results_next = new System.Windows.Forms.Button();
            this.check_chart_upscaling = new System.Windows.Forms.CheckBox();
            this.button_results_back = new System.Windows.Forms.Button();
            this.tab_2circletracks = new System.Windows.Forms.TabPage();
            this.tab_destination = new System.Windows.Forms.TabPage();
            this.panel8 = new System.Windows.Forms.Panel();
            this.check_imagemerger_enabled = new System.Windows.Forms.CheckBox();
            this.label_imagemerger_header = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.check_chartoptions_ownfolder = new System.Windows.Forms.CheckBox();
            this.check_chartoptions_savecharts = new System.Windows.Forms.CheckBox();
            this.check_chartoptions_xaxis_animalname = new System.Windows.Forms.CheckBox();
            this.label_chartoptions_header = new System.Windows.Forms.Label();
            this.button_destination_createfiles = new System.Windows.Forms.Button();
            this.panel_destination_2circle = new System.Windows.Forms.Panel();
            this.check_2circle_chart_combined = new System.Windows.Forms.CheckBox();
            this.check_2circle_merge = new System.Windows.Forms.CheckBox();
            this.check_2circle_chart_outer = new System.Windows.Forms.CheckBox();
            this.label_2circle_header = new System.Windows.Forms.Label();
            this.check_2circle_chart_inner = new System.Windows.Forms.CheckBox();
            this.button_destination_back = new System.Windows.Forms.Button();
            this.panel_destination_options = new System.Windows.Forms.Panel();
            this.check_dataoptions_reordercounting = new System.Windows.Forms.CheckBox();
            this.check_dataoptions_addgroupcolumns = new System.Windows.Forms.CheckBox();
            this.check_dataoptions_addsumcolumns = new System.Windows.Forms.CheckBox();
            this.label_dataoptions_header = new System.Windows.Forms.Label();
            this.panel_destination_filetype = new System.Windows.Forms.Panel();
            this.radio_filetype_xlsx = new System.Windows.Forms.RadioButton();
            this.check_filetype_xlsx_includefilters = new System.Windows.Forms.CheckBox();
            this.check_filetype_xlsx_multisheet = new System.Windows.Forms.CheckBox();
            this.label_filetype_header = new System.Windows.Forms.Label();
            this.radio_filetype_xls = new System.Windows.Forms.RadioButton();
            this.panel_destination_location = new System.Windows.Forms.Panel();
            this.check_destination_subfolders = new System.Windows.Forms.CheckBox();
            this.check_destination_overwritefiles = new System.Windows.Forms.CheckBox();
            this.radio_destination_importfolder = new System.Windows.Forms.RadioButton();
            this.label_destination_header = new System.Windows.Forms.Label();
            this.radio_destination_custom = new System.Windows.Forms.RadioButton();
            this.panel7 = new System.Windows.Forms.Panel();
            this.text_howto_destination = new System.Windows.Forms.TextBox();
            this.chart_thresholds = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chart_importeddata = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.chart_result = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.menu_file = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_settings = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_file_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_filehandling = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_filehandling_entryup = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_filehandling_entrydown = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_filehandling_removeentry = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites_load1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites_load2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites_load3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_favorites_save1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites_save2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_favorites_save3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_grouping = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_grouping_by2 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_grouping_by3 = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_grouping_by4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.menu_grouping_renameutility = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_helpandsupport = new System.Windows.Forms.ToolStripMenuItem();
            this.menu_help_about = new System.Windows.Forms.ToolStripMenuItem();
            this.tabcontrol.SuspendLayout();
            this.tab_import.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tab_basic.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tab_thresholds.SuspendLayout();
            this.panel5.SuspendLayout();
            this.tab_grouping.SuspendLayout();
            this.panel_grouping_groupnaming.SuspendLayout();
            this.panel_grouping_multifiles.SuspendLayout();
            this.panel_Grouping_Tutorial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_grouping)).BeginInit();
            this.tab_results.SuspendLayout();
            this.panel6.SuspendLayout();
            this.tab_destination.SuspendLayout();
            this.panel8.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel_destination_2circle.SuspendLayout();
            this.panel_destination_options.SuspendLayout();
            this.panel_destination_filetype.SuspendLayout();
            this.panel_destination_location.SuspendLayout();
            this.panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_thresholds)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_importeddata)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_result)).BeginInit();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_softwarename
            // 
            this.label_softwarename.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_softwarename.Location = new System.Drawing.Point(12, 34);
            this.label_softwarename.Name = "label_softwarename";
            this.label_softwarename.Size = new System.Drawing.Size(576, 47);
            this.label_softwarename.TabIndex = 1;
            this.label_softwarename.Text = "label_softwarename";
            this.label_softwarename.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblInfo
            // 
            this.lblInfo.Location = new System.Drawing.Point(14, 84);
            this.lblInfo.Name = "lblInfo";
            this.lblInfo.Size = new System.Drawing.Size(574, 280);
            this.lblInfo.TabIndex = 4;
            this.lblInfo.Text = resources.GetString("lblInfo.Text");
            // 
            // btnExit
            // 
            this.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(454, 325);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(134, 32);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "&Exit application";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // checkAutostart
            // 
            this.checkAutostart.AutoSize = true;
            this.checkAutostart.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkAutostart.Location = new System.Drawing.Point(17, 332);
            this.checkAutostart.Name = "checkAutostart";
            this.checkAutostart.Size = new System.Drawing.Size(256, 21);
            this.checkAutostart.TabIndex = 1;
            this.checkAutostart.Text = "Automatic processing with last settings.";
            this.checkAutostart.UseVisualStyleBackColor = true;
            this.checkAutostart.Visible = false;
            this.checkAutostart.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // tabcontrol
            // 
            this.tabcontrol.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabcontrol.Controls.Add(this.tab_import);
            this.tabcontrol.Controls.Add(this.tab_basic);
            this.tabcontrol.Controls.Add(this.tab_thresholds);
            this.tabcontrol.Controls.Add(this.tab_grouping);
            this.tabcontrol.Controls.Add(this.tab_results);
            this.tabcontrol.Controls.Add(this.tab_2circletracks);
            this.tabcontrol.Controls.Add(this.tab_destination);
            this.tabcontrol.Location = new System.Drawing.Point(14, 84);
            this.tabcontrol.Multiline = true;
            this.tabcontrol.Name = "tabcontrol";
            this.tabcontrol.SelectedIndex = 0;
            this.tabcontrol.Size = new System.Drawing.Size(1238, 280);
            this.tabcontrol.TabIndex = 4;
            this.tabcontrol.Visible = false;
            this.tabcontrol.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            this.tabcontrol.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            this.tabcontrol.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // tab_import
            // 
            this.tab_import.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_import.Controls.Add(this.panel1);
            this.tab_import.Controls.Add(this.button_import_next);
            this.tab_import.Controls.Add(this.button_cancel_files);
            this.tab_import.Location = new System.Drawing.Point(4, 26);
            this.tab_import.Name = "tab_import";
            this.tab_import.Size = new System.Drawing.Size(1230, 250);
            this.tab_import.TabIndex = 8;
            this.tab_import.Text = "tab_import";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.list_ImportStatus);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1230, 213);
            this.panel1.TabIndex = 8;
            // 
            // list_ImportStatus
            // 
            this.list_ImportStatus.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.list_ImportStatus.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_ImportStatus.CheckBoxes = true;
            this.list_ImportStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.column_import_check,
            this.column_import_filename,
            this.column_import_problems,
            this.column_import_imagesfound,
            this.column_import_animals,
            this.column_import_lines,
            this.column_import_duplicates,
            this.column_import_secpertrack,
            this.column_import_duration});
            this.list_ImportStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.list_ImportStatus.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.list_ImportStatus.FullRowSelect = true;
            this.list_ImportStatus.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_ImportStatus.HoverSelection = true;
            this.list_ImportStatus.Location = new System.Drawing.Point(0, 0);
            this.list_ImportStatus.MultiSelect = false;
            this.list_ImportStatus.Name = "list_ImportStatus";
            this.list_ImportStatus.ShowGroups = false;
            this.list_ImportStatus.Size = new System.Drawing.Size(1230, 213);
            this.list_ImportStatus.TabIndex = 0;
            this.list_ImportStatus.UseCompatibleStateImageBehavior = false;
            this.list_ImportStatus.View = System.Windows.Forms.View.Details;
            this.list_ImportStatus.SelectedIndexChanged += new System.EventHandler(this.list_ImportStatus_SelectedIndexChanged);
            // 
            // column_import_check
            // 
            this.column_import_check.Text = "column_import_check";
            this.column_import_check.Width = 50;
            // 
            // column_import_filename
            // 
            this.column_import_filename.Text = "column_import_filename";
            this.column_import_filename.Width = 380;
            // 
            // column_import_problems
            // 
            this.column_import_problems.Text = "column_import_problems";
            this.column_import_problems.Width = 280;
            // 
            // column_import_imagesfound
            // 
            this.column_import_imagesfound.Text = "column_import_imagesfound";
            this.column_import_imagesfound.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // column_import_animals
            // 
            this.column_import_animals.Text = "column_import_animals";
            this.column_import_animals.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_import_lines
            // 
            this.column_import_lines.Text = "column_import_lines";
            this.column_import_lines.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // column_import_duplicates
            // 
            this.column_import_duplicates.Text = "column_import_duplicates";
            this.column_import_duplicates.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_import_duplicates.Width = 80;
            // 
            // column_import_secpertrack
            // 
            this.column_import_secpertrack.Text = "column_import_secpertrack";
            this.column_import_secpertrack.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_import_secpertrack.Width = 100;
            // 
            // column_import_duration
            // 
            this.column_import_duration.Text = "column_import_duration";
            this.column_import_duration.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.column_import_duration.Width = 130;
            // 
            // button_import_next
            // 
            this.button_import_next.AllowDrop = true;
            this.button_import_next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_import_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_import_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_import_next.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_import_next.Location = new System.Drawing.Point(529, 219);
            this.button_import_next.Name = "button_import_next";
            this.button_import_next.Size = new System.Drawing.Size(100, 28);
            this.button_import_next.TabIndex = 7;
            this.button_import_next.Text = "button_import_next";
            this.button_import_next.UseVisualStyleBackColor = true;
            this.button_import_next.Click += new System.EventHandler(this.OnButtonNext_Click);
            // 
            // button_cancel_files
            // 
            this.button_cancel_files.AllowDrop = true;
            this.button_cancel_files.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_cancel_files.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_cancel_files.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_cancel_files.Location = new System.Drawing.Point(3, 215);
            this.button_cancel_files.Name = "button_cancel_files";
            this.button_cancel_files.Size = new System.Drawing.Size(134, 32);
            this.button_cancel_files.TabIndex = 3;
            this.button_cancel_files.Text = "button_cancel_files";
            this.button_cancel_files.UseVisualStyleBackColor = true;
            this.button_cancel_files.Visible = false;
            this.button_cancel_files.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // tab_basic
            // 
            this.tab_basic.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_basic.Controls.Add(this.button_basics_back);
            this.tab_basic.Controls.Add(this.panel4);
            this.tab_basic.Controls.Add(this.button_basic_next);
            this.tab_basic.Controls.Add(this.check_clean_duplicates);
            this.tab_basic.Controls.Add(this.check_clean_invalidsum);
            this.tab_basic.Location = new System.Drawing.Point(4, 26);
            this.tab_basic.Name = "tab_basic";
            this.tab_basic.Padding = new System.Windows.Forms.Padding(3);
            this.tab_basic.Size = new System.Drawing.Size(1230, 250);
            this.tab_basic.TabIndex = 1;
            this.tab_basic.Text = "tab_basic";
            // 
            // button_basics_back
            // 
            this.button_basics_back.AllowDrop = true;
            this.button_basics_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_basics_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_basics_back.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_basics_back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_basics_back.Location = new System.Drawing.Point(3, 219);
            this.button_basics_back.Name = "button_basics_back";
            this.button_basics_back.Size = new System.Drawing.Size(100, 28);
            this.button_basics_back.TabIndex = 44;
            this.button_basics_back.TabStop = false;
            this.button_basics_back.Text = "button_basics_back";
            this.button_basics_back.UseVisualStyleBackColor = true;
            this.button_basics_back.Click += new System.EventHandler(this.OnButtonBack_Click);
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.Controls.Add(this.text_howto_basics);
            this.panel4.Location = new System.Drawing.Point(635, 6);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(589, 238);
            this.panel4.TabIndex = 7;
            // 
            // text_howto_basics
            // 
            this.text_howto_basics.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_howto_basics.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_howto_basics.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_howto_basics.Location = new System.Drawing.Point(0, 0);
            this.text_howto_basics.Multiline = true;
            this.text_howto_basics.Name = "text_howto_basics";
            this.text_howto_basics.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_howto_basics.Size = new System.Drawing.Size(589, 238);
            this.text_howto_basics.TabIndex = 0;
            this.text_howto_basics.TabStop = false;
            this.text_howto_basics.Text = "text_howto_basics";
            // 
            // button_basic_next
            // 
            this.button_basic_next.AllowDrop = true;
            this.button_basic_next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_basic_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_basic_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_basic_next.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_basic_next.Location = new System.Drawing.Point(529, 219);
            this.button_basic_next.Name = "button_basic_next";
            this.button_basic_next.Size = new System.Drawing.Size(100, 28);
            this.button_basic_next.TabIndex = 6;
            this.button_basic_next.Text = "button_basic_next";
            this.button_basic_next.UseVisualStyleBackColor = true;
            this.button_basic_next.Click += new System.EventHandler(this.OnButtonNext_Click);
            // 
            // check_clean_duplicates
            // 
            this.check_clean_duplicates.AutoSize = true;
            this.check_clean_duplicates.Checked = true;
            this.check_clean_duplicates.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_clean_duplicates.Location = new System.Drawing.Point(9, 39);
            this.check_clean_duplicates.Name = "check_clean_duplicates";
            this.check_clean_duplicates.Size = new System.Drawing.Size(158, 21);
            this.check_clean_duplicates.TabIndex = 2;
            this.check_clean_duplicates.Text = "check_clean_duplicates";
            this.check_clean_duplicates.UseVisualStyleBackColor = true;
            this.check_clean_duplicates.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_clean_invalidsum
            // 
            this.check_clean_invalidsum.AutoSize = true;
            this.check_clean_invalidsum.Checked = true;
            this.check_clean_invalidsum.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_clean_invalidsum.Location = new System.Drawing.Point(9, 66);
            this.check_clean_invalidsum.Name = "check_clean_invalidsum";
            this.check_clean_invalidsum.Size = new System.Drawing.Size(160, 21);
            this.check_clean_invalidsum.TabIndex = 1;
            this.check_clean_invalidsum.Text = "check_clean_invalidsum";
            this.check_clean_invalidsum.UseVisualStyleBackColor = true;
            this.check_clean_invalidsum.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // tab_thresholds
            // 
            this.tab_thresholds.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_thresholds.Controls.Add(this.text_animal_threshold_max);
            this.tab_thresholds.Controls.Add(this.label_thresholds_fish_lines);
            this.tab_thresholds.Controls.Add(this.panel5);
            this.tab_thresholds.Controls.Add(this.text_animal_threshold_min);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_lines);
            this.tab_thresholds.Controls.Add(this.button_thresholds_back);
            this.tab_thresholds.Controls.Add(this.button_thresholds_next);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_max);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_min);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_empty);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_inactive);
            this.tab_thresholds.Controls.Add(this.text_track_empty_max);
            this.tab_thresholds.Controls.Add(this.text_track_inactive_max);
            this.tab_thresholds.Controls.Add(this.label_thresholds_fish_empty);
            this.tab_thresholds.Controls.Add(this.label_thresholds_fish_inactive);
            this.tab_thresholds.Controls.Add(this.text_track_empty_min);
            this.tab_thresholds.Controls.Add(this.text_track_inactive_min);
            this.tab_thresholds.Controls.Add(this.label_thresholds_fish_fast);
            this.tab_thresholds.Controls.Add(this.label_thresholds_fish_slow);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_fast);
            this.tab_thresholds.Controls.Add(this.label_thresholds_header_slow);
            this.tab_thresholds.Controls.Add(this.text_track_slow_max);
            this.tab_thresholds.Controls.Add(this.text_track_fast_max);
            this.tab_thresholds.Controls.Add(this.text_track_fast_min);
            this.tab_thresholds.Controls.Add(this.text_track_slow_min);
            this.tab_thresholds.Location = new System.Drawing.Point(4, 26);
            this.tab_thresholds.Name = "tab_thresholds";
            this.tab_thresholds.Size = new System.Drawing.Size(1230, 250);
            this.tab_thresholds.TabIndex = 3;
            this.tab_thresholds.Text = "tab_thresholds";
            // 
            // text_animal_threshold_max
            // 
            this.text_animal_threshold_max.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_animal_threshold_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_animal_threshold_max.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_animal_threshold_max.Location = new System.Drawing.Point(318, 178);
            this.text_animal_threshold_max.Name = "text_animal_threshold_max";
            this.text_animal_threshold_max.ReadOnly = true;
            this.text_animal_threshold_max.Size = new System.Drawing.Size(50, 23);
            this.text_animal_threshold_max.TabIndex = 46;
            this.text_animal_threshold_max.TabStop = false;
            this.text_animal_threshold_max.Text = "100.0";
            this.text_animal_threshold_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label_thresholds_fish_lines
            // 
            this.label_thresholds_fish_lines.AutoSize = true;
            this.label_thresholds_fish_lines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_fish_lines.Location = new System.Drawing.Point(264, 181);
            this.label_thresholds_fish_lines.Name = "label_thresholds_fish_lines";
            this.label_thresholds_fish_lines.Size = new System.Drawing.Size(145, 15);
            this.label_thresholds_fish_lines.TabIndex = 46;
            this.label_thresholds_fish_lines.Text = "label_thresholds_fish_lines";
            this.label_thresholds_fish_lines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel5
            // 
            this.panel5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel5.Controls.Add(this.text_howto_thresholds);
            this.panel5.Location = new System.Drawing.Point(635, 6);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(589, 241);
            this.panel5.TabIndex = 46;
            // 
            // text_howto_thresholds
            // 
            this.text_howto_thresholds.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_howto_thresholds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_howto_thresholds.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_howto_thresholds.Location = new System.Drawing.Point(0, 0);
            this.text_howto_thresholds.Multiline = true;
            this.text_howto_thresholds.Name = "text_howto_thresholds";
            this.text_howto_thresholds.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_howto_thresholds.Size = new System.Drawing.Size(589, 241);
            this.text_howto_thresholds.TabIndex = 1;
            this.text_howto_thresholds.TabStop = false;
            this.text_howto_thresholds.Text = "text_howto_thresholds";
            // 
            // text_animal_threshold_min
            // 
            this.text_animal_threshold_min.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_animal_threshold_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_animal_threshold_min.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_animal_threshold_min.Location = new System.Drawing.Point(208, 178);
            this.text_animal_threshold_min.Name = "text_animal_threshold_min";
            this.text_animal_threshold_min.Size = new System.Drawing.Size(50, 23);
            this.text_animal_threshold_min.TabIndex = 8;
            this.text_animal_threshold_min.Text = "0.0";
            this.text_animal_threshold_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_animal_threshold_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_animal_threshold_min.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_animal_threshold_min_KeyUp);
            this.text_animal_threshold_min.Leave += new System.EventHandler(this.text_animal_threshold_min_Leave);
            // 
            // label_thresholds_header_lines
            // 
            this.label_thresholds_header_lines.AutoSize = true;
            this.label_thresholds_header_lines.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_lines.Location = new System.Drawing.Point(8, 181);
            this.label_thresholds_header_lines.Name = "label_thresholds_header_lines";
            this.label_thresholds_header_lines.Size = new System.Drawing.Size(170, 15);
            this.label_thresholds_header_lines.TabIndex = 46;
            this.label_thresholds_header_lines.Text = "label_thresholds_header_lines";
            this.label_thresholds_header_lines.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // button_thresholds_back
            // 
            this.button_thresholds_back.AllowDrop = true;
            this.button_thresholds_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_thresholds_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_thresholds_back.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thresholds_back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_thresholds_back.Location = new System.Drawing.Point(3, 219);
            this.button_thresholds_back.Name = "button_thresholds_back";
            this.button_thresholds_back.Size = new System.Drawing.Size(100, 28);
            this.button_thresholds_back.TabIndex = 43;
            this.button_thresholds_back.TabStop = false;
            this.button_thresholds_back.Text = "button_thresholds_back";
            this.button_thresholds_back.UseVisualStyleBackColor = true;
            this.button_thresholds_back.Click += new System.EventHandler(this.OnButtonBack_Click);
            // 
            // button_thresholds_next
            // 
            this.button_thresholds_next.AllowDrop = true;
            this.button_thresholds_next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_thresholds_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_thresholds_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_thresholds_next.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_thresholds_next.Location = new System.Drawing.Point(529, 219);
            this.button_thresholds_next.Name = "button_thresholds_next";
            this.button_thresholds_next.Size = new System.Drawing.Size(100, 28);
            this.button_thresholds_next.TabIndex = 10;
            this.button_thresholds_next.Text = "button_thresholds_next";
            this.button_thresholds_next.UseVisualStyleBackColor = true;
            this.button_thresholds_next.Click += new System.EventHandler(this.OnButtonNext_Click);
            // 
            // label_thresholds_header_max
            // 
            this.label_thresholds_header_max.AutoSize = true;
            this.label_thresholds_header_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_max.Location = new System.Drawing.Point(339, 11);
            this.label_thresholds_header_max.Name = "label_thresholds_header_max";
            this.label_thresholds_header_max.Size = new System.Drawing.Size(160, 15);
            this.label_thresholds_header_max.TabIndex = 41;
            this.label_thresholds_header_max.Text = "label_thresholds_header_max";
            this.label_thresholds_header_max.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_header_min
            // 
            this.label_thresholds_header_min.AutoSize = true;
            this.label_thresholds_header_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_min.Location = new System.Drawing.Point(230, 11);
            this.label_thresholds_header_min.Name = "label_thresholds_header_min";
            this.label_thresholds_header_min.Size = new System.Drawing.Size(159, 15);
            this.label_thresholds_header_min.TabIndex = 40;
            this.label_thresholds_header_min.Text = "label_thresholds_header_min";
            this.label_thresholds_header_min.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_header_empty
            // 
            this.label_thresholds_header_empty.AutoSize = true;
            this.label_thresholds_header_empty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_empty.Location = new System.Drawing.Point(7, 119);
            this.label_thresholds_header_empty.Name = "label_thresholds_header_empty";
            this.label_thresholds_header_empty.Size = new System.Drawing.Size(181, 15);
            this.label_thresholds_header_empty.TabIndex = 39;
            this.label_thresholds_header_empty.Text = "label_thresholds_header_empty";
            this.label_thresholds_header_empty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_header_inactive
            // 
            this.label_thresholds_header_inactive.AutoSize = true;
            this.label_thresholds_header_inactive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_inactive.Location = new System.Drawing.Point(7, 90);
            this.label_thresholds_header_inactive.Name = "label_thresholds_header_inactive";
            this.label_thresholds_header_inactive.Size = new System.Drawing.Size(179, 15);
            this.label_thresholds_header_inactive.TabIndex = 38;
            this.label_thresholds_header_inactive.Text = "label_thresholds_header_inactive";
            this.label_thresholds_header_inactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_track_empty_max
            // 
            this.text_track_empty_max.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_empty_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_empty_max.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_empty_max.Location = new System.Drawing.Point(318, 116);
            this.text_track_empty_max.Name = "text_track_empty_max";
            this.text_track_empty_max.Size = new System.Drawing.Size(50, 23);
            this.text_track_empty_max.TabIndex = 7;
            this.text_track_empty_max.Text = "100.0";
            this.text_track_empty_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_empty_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_empty_max.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_empty_max_KeyUp);
            this.text_track_empty_max.Leave += new System.EventHandler(this.text_track_empty_max_Leave);
            // 
            // text_track_inactive_max
            // 
            this.text_track_inactive_max.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_inactive_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_inactive_max.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_inactive_max.Location = new System.Drawing.Point(318, 87);
            this.text_track_inactive_max.Name = "text_track_inactive_max";
            this.text_track_inactive_max.Size = new System.Drawing.Size(50, 23);
            this.text_track_inactive_max.TabIndex = 6;
            this.text_track_inactive_max.Text = "100.0";
            this.text_track_inactive_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_inactive_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_inactive_max.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_inactive_max_KeyUp);
            this.text_track_inactive_max.Leave += new System.EventHandler(this.text_track_inactive_max_Leave);
            // 
            // label_thresholds_fish_empty
            // 
            this.label_thresholds_fish_empty.AutoSize = true;
            this.label_thresholds_fish_empty.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_fish_empty.Location = new System.Drawing.Point(264, 119);
            this.label_thresholds_fish_empty.Name = "label_thresholds_fish_empty";
            this.label_thresholds_fish_empty.Size = new System.Drawing.Size(155, 15);
            this.label_thresholds_fish_empty.TabIndex = 35;
            this.label_thresholds_fish_empty.Text = "label_thresholds_fish_empty";
            this.label_thresholds_fish_empty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_fish_inactive
            // 
            this.label_thresholds_fish_inactive.AutoSize = true;
            this.label_thresholds_fish_inactive.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_fish_inactive.Location = new System.Drawing.Point(264, 90);
            this.label_thresholds_fish_inactive.Name = "label_thresholds_fish_inactive";
            this.label_thresholds_fish_inactive.Size = new System.Drawing.Size(162, 15);
            this.label_thresholds_fish_inactive.TabIndex = 34;
            this.label_thresholds_fish_inactive.Text = "label_thresholds_fish_inactive";
            this.label_thresholds_fish_inactive.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_track_empty_min
            // 
            this.text_track_empty_min.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_empty_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_empty_min.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_empty_min.Location = new System.Drawing.Point(208, 116);
            this.text_track_empty_min.Name = "text_track_empty_min";
            this.text_track_empty_min.ReadOnly = true;
            this.text_track_empty_min.Size = new System.Drawing.Size(50, 23);
            this.text_track_empty_min.TabIndex = 33;
            this.text_track_empty_min.TabStop = false;
            this.text_track_empty_min.Text = "0.0";
            this.text_track_empty_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // text_track_inactive_min
            // 
            this.text_track_inactive_min.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_inactive_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_inactive_min.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_inactive_min.Location = new System.Drawing.Point(208, 87);
            this.text_track_inactive_min.Name = "text_track_inactive_min";
            this.text_track_inactive_min.Size = new System.Drawing.Size(50, 23);
            this.text_track_inactive_min.TabIndex = 5;
            this.text_track_inactive_min.Text = "0.0";
            this.text_track_inactive_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_inactive_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_inactive_min.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_inactive_min_KeyUp);
            this.text_track_inactive_min.Leave += new System.EventHandler(this.text_track_inactive_min_Leave);
            // 
            // label_thresholds_fish_fast
            // 
            this.label_thresholds_fish_fast.AutoSize = true;
            this.label_thresholds_fish_fast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_fish_fast.Location = new System.Drawing.Point(264, 61);
            this.label_thresholds_fish_fast.Name = "label_thresholds_fish_fast";
            this.label_thresholds_fish_fast.Size = new System.Drawing.Size(140, 15);
            this.label_thresholds_fish_fast.TabIndex = 31;
            this.label_thresholds_fish_fast.Text = "label_thresholds_fish_fast";
            this.label_thresholds_fish_fast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_fish_slow
            // 
            this.label_thresholds_fish_slow.AutoSize = true;
            this.label_thresholds_fish_slow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_fish_slow.Location = new System.Drawing.Point(264, 32);
            this.label_thresholds_fish_slow.Name = "label_thresholds_fish_slow";
            this.label_thresholds_fish_slow.Size = new System.Drawing.Size(145, 15);
            this.label_thresholds_fish_slow.TabIndex = 30;
            this.label_thresholds_fish_slow.Text = "label_thresholds_fish_slow";
            this.label_thresholds_fish_slow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_header_fast
            // 
            this.label_thresholds_header_fast.AutoSize = true;
            this.label_thresholds_header_fast.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_fast.Location = new System.Drawing.Point(7, 61);
            this.label_thresholds_header_fast.Name = "label_thresholds_header_fast";
            this.label_thresholds_header_fast.Size = new System.Drawing.Size(157, 15);
            this.label_thresholds_header_fast.TabIndex = 29;
            this.label_thresholds_header_fast.Text = "label_thresholds_header_fast";
            this.label_thresholds_header_fast.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_thresholds_header_slow
            // 
            this.label_thresholds_header_slow.AutoSize = true;
            this.label_thresholds_header_slow.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_thresholds_header_slow.Location = new System.Drawing.Point(7, 32);
            this.label_thresholds_header_slow.Name = "label_thresholds_header_slow";
            this.label_thresholds_header_slow.Size = new System.Drawing.Size(162, 15);
            this.label_thresholds_header_slow.TabIndex = 28;
            this.label_thresholds_header_slow.Text = "label_thresholds_header_slow";
            this.label_thresholds_header_slow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // text_track_slow_max
            // 
            this.text_track_slow_max.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_slow_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_slow_max.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_slow_max.Location = new System.Drawing.Point(318, 29);
            this.text_track_slow_max.Name = "text_track_slow_max";
            this.text_track_slow_max.Size = new System.Drawing.Size(50, 23);
            this.text_track_slow_max.TabIndex = 2;
            this.text_track_slow_max.Text = "100.0";
            this.text_track_slow_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_slow_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_slow_max.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_slow_max_KeyUp);
            this.text_track_slow_max.Leave += new System.EventHandler(this.text_track_slow_max_Leave);
            // 
            // text_track_fast_max
            // 
            this.text_track_fast_max.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_fast_max.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_fast_max.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_fast_max.Location = new System.Drawing.Point(318, 58);
            this.text_track_fast_max.Name = "text_track_fast_max";
            this.text_track_fast_max.Size = new System.Drawing.Size(50, 23);
            this.text_track_fast_max.TabIndex = 4;
            this.text_track_fast_max.Text = "100.0";
            this.text_track_fast_max.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_fast_max.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_fast_max.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_fast_max_KeyUp);
            this.text_track_fast_max.Leave += new System.EventHandler(this.text_track_fast_max_Leave);
            // 
            // text_track_fast_min
            // 
            this.text_track_fast_min.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_fast_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_fast_min.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_fast_min.Location = new System.Drawing.Point(208, 58);
            this.text_track_fast_min.Name = "text_track_fast_min";
            this.text_track_fast_min.Size = new System.Drawing.Size(50, 23);
            this.text_track_fast_min.TabIndex = 3;
            this.text_track_fast_min.Text = "0.0";
            this.text_track_fast_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_fast_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_fast_min.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_fast_min_KeyUp);
            this.text_track_fast_min.Leave += new System.EventHandler(this.text_track_fast_min_Leave);
            // 
            // text_track_slow_min
            // 
            this.text_track_slow_min.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_track_slow_min.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.text_track_slow_min.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_track_slow_min.Location = new System.Drawing.Point(208, 29);
            this.text_track_slow_min.Name = "text_track_slow_min";
            this.text_track_slow_min.Size = new System.Drawing.Size(50, 23);
            this.text_track_slow_min.TabIndex = 1;
            this.text_track_slow_min.Text = "0.0";
            this.text_track_slow_min.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.text_track_slow_min.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnKeyDown_Threshold);
            this.text_track_slow_min.KeyUp += new System.Windows.Forms.KeyEventHandler(this.text_track_slow_min_KeyUp);
            this.text_track_slow_min.Leave += new System.EventHandler(this.text_track_slow_min_Leave);
            // 
            // tab_grouping
            // 
            this.tab_grouping.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_grouping.Controls.Add(this.panel_grouping_groupnaming);
            this.tab_grouping.Controls.Add(this.button_grouping_next);
            this.tab_grouping.Controls.Add(this.button_grouping_back);
            this.tab_grouping.Controls.Add(this.panel_grouping_multifiles);
            this.tab_grouping.Controls.Add(this.panel_Grouping_Tutorial);
            this.tab_grouping.Controls.Add(this.grid_grouping);
            this.tab_grouping.Location = new System.Drawing.Point(4, 26);
            this.tab_grouping.Name = "tab_grouping";
            this.tab_grouping.Size = new System.Drawing.Size(1230, 250);
            this.tab_grouping.TabIndex = 6;
            this.tab_grouping.Text = "tab_grouping";
            // 
            // panel_grouping_groupnaming
            // 
            this.panel_grouping_groupnaming.Controls.Add(this.button_groupnaming_done);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group9);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group9);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group8);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group8);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group7);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group7);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group6);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group6);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group5);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group5);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group4);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group4);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group3);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group3);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group2);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group2);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group1);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group1);
            this.panel_grouping_groupnaming.Controls.Add(this.text_groupnaming_group0);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_group0);
            this.panel_grouping_groupnaming.Controls.Add(this.label_groupnaming_header);
            this.panel_grouping_groupnaming.Location = new System.Drawing.Point(532, 3);
            this.panel_grouping_groupnaming.Name = "panel_grouping_groupnaming";
            this.panel_grouping_groupnaming.Size = new System.Drawing.Size(300, 430);
            this.panel_grouping_groupnaming.TabIndex = 46;
            this.panel_grouping_groupnaming.Visible = false;
            // 
            // button_groupnaming_done
            // 
            this.button_groupnaming_done.AllowDrop = true;
            this.button_groupnaming_done.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_groupnaming_done.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_groupnaming_done.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_groupnaming_done.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_groupnaming_done.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_groupnaming_done.Location = new System.Drawing.Point(191, 393);
            this.button_groupnaming_done.Name = "button_groupnaming_done";
            this.button_groupnaming_done.Size = new System.Drawing.Size(100, 28);
            this.button_groupnaming_done.TabIndex = 47;
            this.button_groupnaming_done.Text = "button_groupnaming_done";
            this.button_groupnaming_done.UseVisualStyleBackColor = true;
            this.button_groupnaming_done.Click += new System.EventHandler(this.menugroupingrenameutilityToolStripMenuItem_Click);
            // 
            // text_groupnaming_group9
            // 
            this.text_groupnaming_group9.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group9.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group9.Location = new System.Drawing.Point(91, 362);
            this.text_groupnaming_group9.MaxLength = 50;
            this.text_groupnaming_group9.Name = "text_groupnaming_group9";
            this.text_groupnaming_group9.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group9.TabIndex = 41;
            this.text_groupnaming_group9.Text = "text_groupnaming_group9";
            this.text_groupnaming_group9.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group9
            // 
            this.label_groupnaming_group9.AutoSize = true;
            this.label_groupnaming_group9.Location = new System.Drawing.Point(3, 365);
            this.label_groupnaming_group9.Name = "label_groupnaming_group9";
            this.label_groupnaming_group9.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group9.TabIndex = 40;
            this.label_groupnaming_group9.Text = "label_groupnaming_group9";
            // 
            // text_groupnaming_group8
            // 
            this.text_groupnaming_group8.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group8.Location = new System.Drawing.Point(91, 331);
            this.text_groupnaming_group8.MaxLength = 50;
            this.text_groupnaming_group8.Name = "text_groupnaming_group8";
            this.text_groupnaming_group8.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group8.TabIndex = 39;
            this.text_groupnaming_group8.Text = "text_groupnaming_group8";
            this.text_groupnaming_group8.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group8
            // 
            this.label_groupnaming_group8.AutoSize = true;
            this.label_groupnaming_group8.Location = new System.Drawing.Point(3, 334);
            this.label_groupnaming_group8.Name = "label_groupnaming_group8";
            this.label_groupnaming_group8.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group8.TabIndex = 38;
            this.label_groupnaming_group8.Text = "label_groupnaming_group8";
            // 
            // text_groupnaming_group7
            // 
            this.text_groupnaming_group7.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group7.Location = new System.Drawing.Point(91, 300);
            this.text_groupnaming_group7.MaxLength = 50;
            this.text_groupnaming_group7.Name = "text_groupnaming_group7";
            this.text_groupnaming_group7.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group7.TabIndex = 37;
            this.text_groupnaming_group7.Text = "text_groupnaming_group7";
            this.text_groupnaming_group7.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group7
            // 
            this.label_groupnaming_group7.AutoSize = true;
            this.label_groupnaming_group7.Location = new System.Drawing.Point(3, 303);
            this.label_groupnaming_group7.Name = "label_groupnaming_group7";
            this.label_groupnaming_group7.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group7.TabIndex = 36;
            this.label_groupnaming_group7.Text = "label_groupnaming_group7";
            // 
            // text_groupnaming_group6
            // 
            this.text_groupnaming_group6.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group6.Location = new System.Drawing.Point(91, 269);
            this.text_groupnaming_group6.MaxLength = 50;
            this.text_groupnaming_group6.Name = "text_groupnaming_group6";
            this.text_groupnaming_group6.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group6.TabIndex = 35;
            this.text_groupnaming_group6.Text = "text_groupnaming_group6";
            this.text_groupnaming_group6.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group6
            // 
            this.label_groupnaming_group6.AutoSize = true;
            this.label_groupnaming_group6.Location = new System.Drawing.Point(3, 272);
            this.label_groupnaming_group6.Name = "label_groupnaming_group6";
            this.label_groupnaming_group6.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group6.TabIndex = 34;
            this.label_groupnaming_group6.Text = "label_groupnaming_group6";
            // 
            // text_groupnaming_group5
            // 
            this.text_groupnaming_group5.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group5.Location = new System.Drawing.Point(91, 238);
            this.text_groupnaming_group5.MaxLength = 50;
            this.text_groupnaming_group5.Name = "text_groupnaming_group5";
            this.text_groupnaming_group5.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group5.TabIndex = 33;
            this.text_groupnaming_group5.Text = "text_groupnaming_group5";
            this.text_groupnaming_group5.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group5
            // 
            this.label_groupnaming_group5.AutoSize = true;
            this.label_groupnaming_group5.Location = new System.Drawing.Point(3, 241);
            this.label_groupnaming_group5.Name = "label_groupnaming_group5";
            this.label_groupnaming_group5.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group5.TabIndex = 32;
            this.label_groupnaming_group5.Text = "label_groupnaming_group5";
            // 
            // text_groupnaming_group4
            // 
            this.text_groupnaming_group4.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group4.Location = new System.Drawing.Point(91, 207);
            this.text_groupnaming_group4.MaxLength = 50;
            this.text_groupnaming_group4.Name = "text_groupnaming_group4";
            this.text_groupnaming_group4.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group4.TabIndex = 31;
            this.text_groupnaming_group4.Text = "text_groupnaming_group4";
            this.text_groupnaming_group4.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group4
            // 
            this.label_groupnaming_group4.AutoSize = true;
            this.label_groupnaming_group4.Location = new System.Drawing.Point(3, 210);
            this.label_groupnaming_group4.Name = "label_groupnaming_group4";
            this.label_groupnaming_group4.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group4.TabIndex = 30;
            this.label_groupnaming_group4.Text = "label_groupnaming_group4";
            // 
            // text_groupnaming_group3
            // 
            this.text_groupnaming_group3.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group3.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group3.Location = new System.Drawing.Point(91, 176);
            this.text_groupnaming_group3.MaxLength = 50;
            this.text_groupnaming_group3.Name = "text_groupnaming_group3";
            this.text_groupnaming_group3.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group3.TabIndex = 29;
            this.text_groupnaming_group3.Text = "text_groupnaming_group3";
            this.text_groupnaming_group3.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group3
            // 
            this.label_groupnaming_group3.AutoSize = true;
            this.label_groupnaming_group3.Location = new System.Drawing.Point(3, 179);
            this.label_groupnaming_group3.Name = "label_groupnaming_group3";
            this.label_groupnaming_group3.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group3.TabIndex = 28;
            this.label_groupnaming_group3.Text = "label_groupnaming_group3";
            // 
            // text_groupnaming_group2
            // 
            this.text_groupnaming_group2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group2.Location = new System.Drawing.Point(91, 145);
            this.text_groupnaming_group2.MaxLength = 50;
            this.text_groupnaming_group2.Name = "text_groupnaming_group2";
            this.text_groupnaming_group2.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group2.TabIndex = 27;
            this.text_groupnaming_group2.Text = "text_groupnaming_group2";
            this.text_groupnaming_group2.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group2
            // 
            this.label_groupnaming_group2.AutoSize = true;
            this.label_groupnaming_group2.Location = new System.Drawing.Point(3, 148);
            this.label_groupnaming_group2.Name = "label_groupnaming_group2";
            this.label_groupnaming_group2.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group2.TabIndex = 26;
            this.label_groupnaming_group2.Text = "label_groupnaming_group2";
            // 
            // text_groupnaming_group1
            // 
            this.text_groupnaming_group1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group1.Location = new System.Drawing.Point(91, 114);
            this.text_groupnaming_group1.MaxLength = 50;
            this.text_groupnaming_group1.Name = "text_groupnaming_group1";
            this.text_groupnaming_group1.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group1.TabIndex = 25;
            this.text_groupnaming_group1.Text = "text_groupnaming_group1";
            this.text_groupnaming_group1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group1
            // 
            this.label_groupnaming_group1.AutoSize = true;
            this.label_groupnaming_group1.Location = new System.Drawing.Point(3, 117);
            this.label_groupnaming_group1.Name = "label_groupnaming_group1";
            this.label_groupnaming_group1.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group1.TabIndex = 24;
            this.label_groupnaming_group1.Text = "label_groupnaming_group1";
            // 
            // text_groupnaming_group0
            // 
            this.text_groupnaming_group0.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.text_groupnaming_group0.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.text_groupnaming_group0.Location = new System.Drawing.Point(91, 83);
            this.text_groupnaming_group0.MaxLength = 50;
            this.text_groupnaming_group0.Name = "text_groupnaming_group0";
            this.text_groupnaming_group0.Size = new System.Drawing.Size(200, 25);
            this.text_groupnaming_group0.TabIndex = 23;
            this.text_groupnaming_group0.Text = "text_groupnaming_group0";
            this.text_groupnaming_group0.KeyUp += new System.Windows.Forms.KeyEventHandler(this.OnChange_GroupName);
            // 
            // label_groupnaming_group0
            // 
            this.label_groupnaming_group0.AutoSize = true;
            this.label_groupnaming_group0.Location = new System.Drawing.Point(3, 86);
            this.label_groupnaming_group0.Name = "label_groupnaming_group0";
            this.label_groupnaming_group0.Size = new System.Drawing.Size(168, 17);
            this.label_groupnaming_group0.TabIndex = 22;
            this.label_groupnaming_group0.Text = "label_groupnaming_group0";
            // 
            // label_groupnaming_header
            // 
            this.label_groupnaming_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_groupnaming_header.Location = new System.Drawing.Point(3, 4);
            this.label_groupnaming_header.Name = "label_groupnaming_header";
            this.label_groupnaming_header.Size = new System.Drawing.Size(280, 76);
            this.label_groupnaming_header.TabIndex = 21;
            this.label_groupnaming_header.Text = "label_groupnaming_header";
            // 
            // button_grouping_next
            // 
            this.button_grouping_next.AllowDrop = true;
            this.button_grouping_next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_grouping_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_grouping_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_grouping_next.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_grouping_next.Location = new System.Drawing.Point(529, 484);
            this.button_grouping_next.Name = "button_grouping_next";
            this.button_grouping_next.Size = new System.Drawing.Size(100, 28);
            this.button_grouping_next.TabIndex = 45;
            this.button_grouping_next.Text = "button_grouping_next";
            this.button_grouping_next.UseVisualStyleBackColor = true;
            this.button_grouping_next.Click += new System.EventHandler(this.OnButtonNext_Click);
            // 
            // button_grouping_back
            // 
            this.button_grouping_back.AllowDrop = true;
            this.button_grouping_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_grouping_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_grouping_back.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_grouping_back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_grouping_back.Location = new System.Drawing.Point(3, 484);
            this.button_grouping_back.Name = "button_grouping_back";
            this.button_grouping_back.Size = new System.Drawing.Size(100, 28);
            this.button_grouping_back.TabIndex = 44;
            this.button_grouping_back.TabStop = false;
            this.button_grouping_back.Text = "button_grouping_back";
            this.button_grouping_back.UseVisualStyleBackColor = true;
            this.button_grouping_back.Click += new System.EventHandler(this.OnButtonBack_Click);
            // 
            // panel_grouping_multifiles
            // 
            this.panel_grouping_multifiles.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_grouping_multifiles.Controls.Add(this.txtGrouping_MultifileSelector);
            this.panel_grouping_multifiles.Controls.Add(this.label_grouping_multifiles_info);
            this.panel_grouping_multifiles.Location = new System.Drawing.Point(835, 3);
            this.panel_grouping_multifiles.Name = "panel_grouping_multifiles";
            this.panel_grouping_multifiles.Size = new System.Drawing.Size(392, 80);
            this.panel_grouping_multifiles.TabIndex = 9;
            // 
            // txtGrouping_MultifileSelector
            // 
            this.txtGrouping_MultifileSelector.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtGrouping_MultifileSelector.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.txtGrouping_MultifileSelector.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.txtGrouping_MultifileSelector.FormattingEnabled = true;
            this.txtGrouping_MultifileSelector.Location = new System.Drawing.Point(6, 52);
            this.txtGrouping_MultifileSelector.Name = "txtGrouping_MultifileSelector";
            this.txtGrouping_MultifileSelector.Size = new System.Drawing.Size(383, 25);
            this.txtGrouping_MultifileSelector.TabIndex = 1;
            this.txtGrouping_MultifileSelector.SelectedValueChanged += new System.EventHandler(this.txtGrouping_MultifileSelector_SelectedValueChanged);
            this.txtGrouping_MultifileSelector.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGrouping_MultifileSelector_KeyDown);
            // 
            // label_grouping_multifiles_info
            // 
            this.label_grouping_multifiles_info.AutoSize = true;
            this.label_grouping_multifiles_info.Location = new System.Drawing.Point(3, 0);
            this.label_grouping_multifiles_info.Name = "label_grouping_multifiles_info";
            this.label_grouping_multifiles_info.Size = new System.Drawing.Size(178, 17);
            this.label_grouping_multifiles_info.TabIndex = 0;
            this.label_grouping_multifiles_info.Text = "label_grouping_multifiles_info";
            // 
            // panel_Grouping_Tutorial
            // 
            this.panel_Grouping_Tutorial.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_Grouping_Tutorial.Controls.Add(this.text_howto_grouping);
            this.panel_Grouping_Tutorial.Location = new System.Drawing.Point(835, 89);
            this.panel_Grouping_Tutorial.Name = "panel_Grouping_Tutorial";
            this.panel_Grouping_Tutorial.Size = new System.Drawing.Size(392, 158);
            this.panel_Grouping_Tutorial.TabIndex = 8;
            // 
            // text_howto_grouping
            // 
            this.text_howto_grouping.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_howto_grouping.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_howto_grouping.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_howto_grouping.Location = new System.Drawing.Point(0, 0);
            this.text_howto_grouping.Multiline = true;
            this.text_howto_grouping.Name = "text_howto_grouping";
            this.text_howto_grouping.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_howto_grouping.Size = new System.Drawing.Size(392, 158);
            this.text_howto_grouping.TabIndex = 0;
            this.text_howto_grouping.TabStop = false;
            this.text_howto_grouping.Text = "text_howto_grouping";
            // 
            // grid_grouping
            // 
            this.grid_grouping.AllowUserToAddRows = false;
            this.grid_grouping.AllowUserToDeleteRows = false;
            this.grid_grouping.AllowUserToResizeColumns = false;
            this.grid_grouping.AllowUserToResizeRows = false;
            this.grid_grouping.BackgroundColor = System.Drawing.SystemColors.WindowFrame;
            this.grid_grouping.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.grid_grouping.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.Sunken;
            this.grid_grouping.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_grouping.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.grid_grouping.ColumnHeadersHeight = 32;
            this.grid_grouping.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_grouping.DefaultCellStyle = dataGridViewCellStyle5;
            this.grid_grouping.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.grid_grouping.GridColor = System.Drawing.SystemColors.ButtonFace;
            this.grid_grouping.Location = new System.Drawing.Point(0, 0);
            this.grid_grouping.Margin = new System.Windows.Forms.Padding(0);
            this.grid_grouping.Name = "grid_grouping";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grid_grouping.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grid_grouping.RowHeadersWidth = 44;
            this.grid_grouping.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grid_grouping.RowTemplate.Height = 64;
            this.grid_grouping.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.grid_grouping.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullColumnSelect;
            this.grid_grouping.ShowCellErrors = false;
            this.grid_grouping.ShowCellToolTips = false;
            this.grid_grouping.ShowEditingIcon = false;
            this.grid_grouping.ShowRowErrors = false;
            this.grid_grouping.Size = new System.Drawing.Size(832, 481);
            this.grid_grouping.TabIndex = 0;
            this.grid_grouping.KeyUp += new System.Windows.Forms.KeyEventHandler(this.gridGrouping_KeyUp);
            // 
            // tab_results
            // 
            this.tab_results.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_results.Controls.Add(this.list_Animals);
            this.tab_results.Controls.Add(this.panel6);
            this.tab_results.Controls.Add(this.button_results_next);
            this.tab_results.Controls.Add(this.check_chart_upscaling);
            this.tab_results.Controls.Add(this.button_results_back);
            this.tab_results.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.tab_results.Location = new System.Drawing.Point(4, 26);
            this.tab_results.Name = "tab_results";
            this.tab_results.Size = new System.Drawing.Size(1230, 250);
            this.tab_results.TabIndex = 5;
            this.tab_results.Text = "tab_results";
            // 
            // list_Animals
            // 
            this.list_Animals.AutoArrange = false;
            this.list_Animals.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.list_Animals.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.list_Animals.CheckBoxes = true;
            this.list_Animals.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.list_Animals.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.list_Animals.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.list_Animals.FullRowSelect = true;
            this.list_Animals.GridLines = true;
            listViewGroup2.Header = "ListViewGroup";
            listViewGroup2.Name = "listViewGroup1";
            this.list_Animals.Groups.AddRange(new System.Windows.Forms.ListViewGroup[] {
            listViewGroup2});
            this.list_Animals.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.list_Animals.Location = new System.Drawing.Point(3, 6);
            this.list_Animals.Name = "list_Animals";
            this.list_Animals.Size = new System.Drawing.Size(620, 207);
            this.list_Animals.TabIndex = 25;
            this.list_Animals.UseCompatibleStateImageBehavior = false;
            this.list_Animals.View = System.Windows.Forms.View.Details;
            this.list_Animals.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.list_Animals_ItemChecked);
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 68;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "well";
            this.columnHeader1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader1.Width = 50;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "animal";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader2.Width = 50;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "lines total";
            this.columnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader3.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "lines removed";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "lines left";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 100;
            // 
            // panel6
            // 
            this.panel6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel6.Controls.Add(this.text_howto_results);
            this.panel6.Location = new System.Drawing.Point(635, 6);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(589, 241);
            this.panel6.TabIndex = 27;
            // 
            // text_howto_results
            // 
            this.text_howto_results.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_howto_results.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_howto_results.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_howto_results.Location = new System.Drawing.Point(0, 0);
            this.text_howto_results.Multiline = true;
            this.text_howto_results.Name = "text_howto_results";
            this.text_howto_results.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_howto_results.Size = new System.Drawing.Size(589, 241);
            this.text_howto_results.TabIndex = 1;
            this.text_howto_results.TabStop = false;
            this.text_howto_results.Text = "text_howto_results";
            // 
            // button_results_next
            // 
            this.button_results_next.AllowDrop = true;
            this.button_results_next.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_results_next.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_results_next.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_results_next.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_results_next.Location = new System.Drawing.Point(529, 219);
            this.button_results_next.Name = "button_results_next";
            this.button_results_next.Size = new System.Drawing.Size(100, 28);
            this.button_results_next.TabIndex = 26;
            this.button_results_next.Text = "button_results_next";
            this.button_results_next.UseVisualStyleBackColor = true;
            this.button_results_next.Click += new System.EventHandler(this.OnButtonNext_Click);
            // 
            // check_chart_upscaling
            // 
            this.check_chart_upscaling.AutoSize = true;
            this.check_chart_upscaling.Checked = true;
            this.check_chart_upscaling.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_chart_upscaling.Location = new System.Drawing.Point(270, 222);
            this.check_chart_upscaling.Name = "check_chart_upscaling";
            this.check_chart_upscaling.Size = new System.Drawing.Size(153, 21);
            this.check_chart_upscaling.TabIndex = 14;
            this.check_chart_upscaling.Text = "check_chart_upscaling";
            this.check_chart_upscaling.UseVisualStyleBackColor = true;
            this.check_chart_upscaling.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // button_results_back
            // 
            this.button_results_back.AllowDrop = true;
            this.button_results_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_results_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_results_back.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_results_back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_results_back.Location = new System.Drawing.Point(3, 219);
            this.button_results_back.Name = "button_results_back";
            this.button_results_back.Size = new System.Drawing.Size(100, 28);
            this.button_results_back.TabIndex = 16;
            this.button_results_back.Text = "button_results_back";
            this.button_results_back.UseVisualStyleBackColor = true;
            this.button_results_back.Click += new System.EventHandler(this.OnButtonBack_Click);
            // 
            // tab_2circletracks
            // 
            this.tab_2circletracks.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_2circletracks.Location = new System.Drawing.Point(4, 26);
            this.tab_2circletracks.Name = "tab_2circletracks";
            this.tab_2circletracks.Size = new System.Drawing.Size(1230, 250);
            this.tab_2circletracks.TabIndex = 7;
            this.tab_2circletracks.Text = "tab_2circletracks";
            // 
            // tab_destination
            // 
            this.tab_destination.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.tab_destination.Controls.Add(this.panel8);
            this.tab_destination.Controls.Add(this.panel3);
            this.tab_destination.Controls.Add(this.button_destination_createfiles);
            this.tab_destination.Controls.Add(this.panel_destination_2circle);
            this.tab_destination.Controls.Add(this.button_destination_back);
            this.tab_destination.Controls.Add(this.panel_destination_options);
            this.tab_destination.Controls.Add(this.panel_destination_filetype);
            this.tab_destination.Controls.Add(this.panel_destination_location);
            this.tab_destination.Controls.Add(this.panel7);
            this.tab_destination.Location = new System.Drawing.Point(4, 26);
            this.tab_destination.Name = "tab_destination";
            this.tab_destination.Size = new System.Drawing.Size(1230, 250);
            this.tab_destination.TabIndex = 4;
            this.tab_destination.Text = "tab_destination";
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.check_imagemerger_enabled);
            this.panel8.Controls.Add(this.label_imagemerger_header);
            this.panel8.Location = new System.Drawing.Point(0, 392);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(629, 30);
            this.panel8.TabIndex = 20;
            // 
            // check_imagemerger_enabled
            // 
            this.check_imagemerger_enabled.AutoSize = true;
            this.check_imagemerger_enabled.Location = new System.Drawing.Point(160, -2);
            this.check_imagemerger_enabled.Name = "check_imagemerger_enabled";
            this.check_imagemerger_enabled.Size = new System.Drawing.Size(195, 21);
            this.check_imagemerger_enabled.TabIndex = 5;
            this.check_imagemerger_enabled.Text = "check_imagemerger_enabled";
            this.check_imagemerger_enabled.UseVisualStyleBackColor = true;
            this.check_imagemerger_enabled.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // label_imagemerger_header
            // 
            this.label_imagemerger_header.AutoSize = true;
            this.label_imagemerger_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_imagemerger_header.Location = new System.Drawing.Point(3, -2);
            this.label_imagemerger_header.Name = "label_imagemerger_header";
            this.label_imagemerger_header.Size = new System.Drawing.Size(156, 17);
            this.label_imagemerger_header.TabIndex = 0;
            this.label_imagemerger_header.Text = "label_imagemerger_header";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.check_chartoptions_ownfolder);
            this.panel3.Controls.Add(this.check_chartoptions_savecharts);
            this.panel3.Controls.Add(this.check_chartoptions_xaxis_animalname);
            this.panel3.Controls.Add(this.label_chartoptions_header);
            this.panel3.Location = new System.Drawing.Point(635, 232);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(589, 90);
            this.panel3.TabIndex = 21;
            // 
            // check_chartoptions_ownfolder
            // 
            this.check_chartoptions_ownfolder.AutoSize = true;
            this.check_chartoptions_ownfolder.Location = new System.Drawing.Point(160, 28);
            this.check_chartoptions_ownfolder.Name = "check_chartoptions_ownfolder";
            this.check_chartoptions_ownfolder.Size = new System.Drawing.Size(201, 21);
            this.check_chartoptions_ownfolder.TabIndex = 7;
            this.check_chartoptions_ownfolder.Text = "check_chartoptions_ownfolder";
            this.check_chartoptions_ownfolder.UseVisualStyleBackColor = true;
            this.check_chartoptions_ownfolder.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_chartoptions_savecharts
            // 
            this.check_chartoptions_savecharts.AutoSize = true;
            this.check_chartoptions_savecharts.Checked = true;
            this.check_chartoptions_savecharts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_chartoptions_savecharts.Enabled = false;
            this.check_chartoptions_savecharts.Location = new System.Drawing.Point(160, -2);
            this.check_chartoptions_savecharts.Name = "check_chartoptions_savecharts";
            this.check_chartoptions_savecharts.Size = new System.Drawing.Size(203, 21);
            this.check_chartoptions_savecharts.TabIndex = 4;
            this.check_chartoptions_savecharts.Text = "check_chartoptions_savecharts";
            this.check_chartoptions_savecharts.UseVisualStyleBackColor = true;
            this.check_chartoptions_savecharts.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_chartoptions_xaxis_animalname
            // 
            this.check_chartoptions_xaxis_animalname.AutoSize = true;
            this.check_chartoptions_xaxis_animalname.Location = new System.Drawing.Point(160, 58);
            this.check_chartoptions_xaxis_animalname.Name = "check_chartoptions_xaxis_animalname";
            this.check_chartoptions_xaxis_animalname.Size = new System.Drawing.Size(245, 21);
            this.check_chartoptions_xaxis_animalname.TabIndex = 6;
            this.check_chartoptions_xaxis_animalname.Text = "check_chartoptions_xaxis_animalname";
            this.check_chartoptions_xaxis_animalname.UseVisualStyleBackColor = true;
            this.check_chartoptions_xaxis_animalname.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // label_chartoptions_header
            // 
            this.label_chartoptions_header.AutoSize = true;
            this.label_chartoptions_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_chartoptions_header.Location = new System.Drawing.Point(3, -2);
            this.label_chartoptions_header.Name = "label_chartoptions_header";
            this.label_chartoptions_header.Size = new System.Drawing.Size(151, 17);
            this.label_chartoptions_header.TabIndex = 0;
            this.label_chartoptions_header.Text = "label_chartoptions_header";
            // 
            // button_destination_createfiles
            // 
            this.button_destination_createfiles.AllowDrop = true;
            this.button_destination_createfiles.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button_destination_createfiles.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_destination_createfiles.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_destination_createfiles.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_destination_createfiles.Location = new System.Drawing.Point(495, 215);
            this.button_destination_createfiles.Name = "button_destination_createfiles";
            this.button_destination_createfiles.Size = new System.Drawing.Size(134, 32);
            this.button_destination_createfiles.TabIndex = 15;
            this.button_destination_createfiles.Text = "button_destination_createfiles";
            this.button_destination_createfiles.UseVisualStyleBackColor = true;
            this.button_destination_createfiles.Visible = false;
            this.button_destination_createfiles.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // panel_destination_2circle
            // 
            this.panel_destination_2circle.Controls.Add(this.check_2circle_chart_combined);
            this.panel_destination_2circle.Controls.Add(this.check_2circle_merge);
            this.panel_destination_2circle.Controls.Add(this.check_2circle_chart_outer);
            this.panel_destination_2circle.Controls.Add(this.label_2circle_header);
            this.panel_destination_2circle.Controls.Add(this.check_2circle_chart_inner);
            this.panel_destination_2circle.Location = new System.Drawing.Point(635, 332);
            this.panel_destination_2circle.Name = "panel_destination_2circle";
            this.panel_destination_2circle.Size = new System.Drawing.Size(589, 120);
            this.panel_destination_2circle.TabIndex = 20;
            this.panel_destination_2circle.Visible = false;
            // 
            // check_2circle_chart_combined
            // 
            this.check_2circle_chart_combined.AutoSize = true;
            this.check_2circle_chart_combined.Checked = true;
            this.check_2circle_chart_combined.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_2circle_chart_combined.Location = new System.Drawing.Point(160, 88);
            this.check_2circle_chart_combined.Name = "check_2circle_chart_combined";
            this.check_2circle_chart_combined.Size = new System.Drawing.Size(198, 21);
            this.check_2circle_chart_combined.TabIndex = 6;
            this.check_2circle_chart_combined.Text = "check_2circle_chart_combined";
            this.check_2circle_chart_combined.UseVisualStyleBackColor = true;
            this.check_2circle_chart_combined.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_2circle_merge
            // 
            this.check_2circle_merge.AutoSize = true;
            this.check_2circle_merge.Checked = true;
            this.check_2circle_merge.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_2circle_merge.Location = new System.Drawing.Point(160, -2);
            this.check_2circle_merge.Name = "check_2circle_merge";
            this.check_2circle_merge.Size = new System.Drawing.Size(144, 21);
            this.check_2circle_merge.TabIndex = 3;
            this.check_2circle_merge.Text = "check_2circle_merge";
            this.check_2circle_merge.UseVisualStyleBackColor = true;
            this.check_2circle_merge.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_2circle_chart_outer
            // 
            this.check_2circle_chart_outer.AutoSize = true;
            this.check_2circle_chart_outer.Checked = true;
            this.check_2circle_chart_outer.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_2circle_chart_outer.Location = new System.Drawing.Point(160, 58);
            this.check_2circle_chart_outer.Name = "check_2circle_chart_outer";
            this.check_2circle_chart_outer.Size = new System.Drawing.Size(171, 21);
            this.check_2circle_chart_outer.TabIndex = 5;
            this.check_2circle_chart_outer.Text = "check_2circle_chart_outer";
            this.check_2circle_chart_outer.UseVisualStyleBackColor = true;
            this.check_2circle_chart_outer.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // label_2circle_header
            // 
            this.label_2circle_header.AutoSize = true;
            this.label_2circle_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_2circle_header.Location = new System.Drawing.Point(3, -2);
            this.label_2circle_header.Name = "label_2circle_header";
            this.label_2circle_header.Size = new System.Drawing.Size(118, 17);
            this.label_2circle_header.TabIndex = 0;
            this.label_2circle_header.Text = "label_2circle_header";
            // 
            // check_2circle_chart_inner
            // 
            this.check_2circle_chart_inner.AutoSize = true;
            this.check_2circle_chart_inner.Checked = true;
            this.check_2circle_chart_inner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_2circle_chart_inner.Location = new System.Drawing.Point(160, 28);
            this.check_2circle_chart_inner.Name = "check_2circle_chart_inner";
            this.check_2circle_chart_inner.Size = new System.Drawing.Size(169, 21);
            this.check_2circle_chart_inner.TabIndex = 4;
            this.check_2circle_chart_inner.Text = "check_2circle_chart_inner";
            this.check_2circle_chart_inner.UseVisualStyleBackColor = true;
            this.check_2circle_chart_inner.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // button_destination_back
            // 
            this.button_destination_back.AllowDrop = true;
            this.button_destination_back.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button_destination_back.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button_destination_back.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button_destination_back.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button_destination_back.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.button_destination_back.Location = new System.Drawing.Point(3, 219);
            this.button_destination_back.Name = "button_destination_back";
            this.button_destination_back.Size = new System.Drawing.Size(100, 28);
            this.button_destination_back.TabIndex = 16;
            this.button_destination_back.TabStop = false;
            this.button_destination_back.Text = "button_destination_back";
            this.button_destination_back.UseVisualStyleBackColor = true;
            this.button_destination_back.Click += new System.EventHandler(this.OnButtonBack_Click);
            // 
            // panel_destination_options
            // 
            this.panel_destination_options.Controls.Add(this.check_dataoptions_reordercounting);
            this.panel_destination_options.Controls.Add(this.check_dataoptions_addgroupcolumns);
            this.panel_destination_options.Controls.Add(this.check_dataoptions_addsumcolumns);
            this.panel_destination_options.Controls.Add(this.label_dataoptions_header);
            this.panel_destination_options.Location = new System.Drawing.Point(0, 292);
            this.panel_destination_options.Name = "panel_destination_options";
            this.panel_destination_options.Size = new System.Drawing.Size(629, 90);
            this.panel_destination_options.TabIndex = 19;
            // 
            // check_dataoptions_reordercounting
            // 
            this.check_dataoptions_reordercounting.AutoSize = true;
            this.check_dataoptions_reordercounting.Location = new System.Drawing.Point(160, 58);
            this.check_dataoptions_reordercounting.Name = "check_dataoptions_reordercounting";
            this.check_dataoptions_reordercounting.Size = new System.Drawing.Size(234, 21);
            this.check_dataoptions_reordercounting.TabIndex = 7;
            this.check_dataoptions_reordercounting.Text = "check_dataoptions_reordercounting";
            this.check_dataoptions_reordercounting.UseVisualStyleBackColor = true;
            this.check_dataoptions_reordercounting.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_dataoptions_addgroupcolumns
            // 
            this.check_dataoptions_addgroupcolumns.AutoSize = true;
            this.check_dataoptions_addgroupcolumns.Checked = true;
            this.check_dataoptions_addgroupcolumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_dataoptions_addgroupcolumns.Location = new System.Drawing.Point(160, 28);
            this.check_dataoptions_addgroupcolumns.Name = "check_dataoptions_addgroupcolumns";
            this.check_dataoptions_addgroupcolumns.Size = new System.Drawing.Size(246, 21);
            this.check_dataoptions_addgroupcolumns.TabIndex = 6;
            this.check_dataoptions_addgroupcolumns.Text = "check_dataoptions_addgroupcolumns";
            this.check_dataoptions_addgroupcolumns.UseVisualStyleBackColor = true;
            this.check_dataoptions_addgroupcolumns.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_dataoptions_addsumcolumns
            // 
            this.check_dataoptions_addsumcolumns.AutoSize = true;
            this.check_dataoptions_addsumcolumns.Checked = true;
            this.check_dataoptions_addsumcolumns.CheckState = System.Windows.Forms.CheckState.Checked;
            this.check_dataoptions_addsumcolumns.Location = new System.Drawing.Point(160, -2);
            this.check_dataoptions_addsumcolumns.Name = "check_dataoptions_addsumcolumns";
            this.check_dataoptions_addsumcolumns.Size = new System.Drawing.Size(234, 21);
            this.check_dataoptions_addsumcolumns.TabIndex = 5;
            this.check_dataoptions_addsumcolumns.Text = "check_dataoptions_addsumcolumns";
            this.check_dataoptions_addsumcolumns.UseVisualStyleBackColor = true;
            this.check_dataoptions_addsumcolumns.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // label_dataoptions_header
            // 
            this.label_dataoptions_header.AutoSize = true;
            this.label_dataoptions_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_dataoptions_header.Location = new System.Drawing.Point(3, -2);
            this.label_dataoptions_header.Name = "label_dataoptions_header";
            this.label_dataoptions_header.Size = new System.Drawing.Size(147, 17);
            this.label_dataoptions_header.TabIndex = 0;
            this.label_dataoptions_header.Text = "label_dataoptions_header";
            // 
            // panel_destination_filetype
            // 
            this.panel_destination_filetype.Controls.Add(this.radio_filetype_xlsx);
            this.panel_destination_filetype.Controls.Add(this.check_filetype_xlsx_includefilters);
            this.panel_destination_filetype.Controls.Add(this.check_filetype_xlsx_multisheet);
            this.panel_destination_filetype.Controls.Add(this.label_filetype_header);
            this.panel_destination_filetype.Controls.Add(this.radio_filetype_xls);
            this.panel_destination_filetype.Location = new System.Drawing.Point(0, 162);
            this.panel_destination_filetype.Name = "panel_destination_filetype";
            this.panel_destination_filetype.Size = new System.Drawing.Size(629, 120);
            this.panel_destination_filetype.TabIndex = 18;
            // 
            // radio_filetype_xlsx
            // 
            this.radio_filetype_xlsx.AutoSize = true;
            this.radio_filetype_xlsx.Location = new System.Drawing.Point(160, -2);
            this.radio_filetype_xlsx.Name = "radio_filetype_xlsx";
            this.radio_filetype_xlsx.Size = new System.Drawing.Size(130, 21);
            this.radio_filetype_xlsx.TabIndex = 5;
            this.radio_filetype_xlsx.Text = "radio_filetype_xlsx";
            this.radio_filetype_xlsx.UseVisualStyleBackColor = true;
            this.radio_filetype_xlsx.CheckedChanged += new System.EventHandler(this.OnRadioButton_CheckChanged);
            // 
            // check_filetype_xlsx_includefilters
            // 
            this.check_filetype_xlsx_includefilters.AutoSize = true;
            this.check_filetype_xlsx_includefilters.Location = new System.Drawing.Point(190, 58);
            this.check_filetype_xlsx_includefilters.Name = "check_filetype_xlsx_includefilters";
            this.check_filetype_xlsx_includefilters.Size = new System.Drawing.Size(210, 21);
            this.check_filetype_xlsx_includefilters.TabIndex = 8;
            this.check_filetype_xlsx_includefilters.Text = "check_filetype_xlsx_includefilters";
            this.check_filetype_xlsx_includefilters.UseVisualStyleBackColor = true;
            this.check_filetype_xlsx_includefilters.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_filetype_xlsx_multisheet
            // 
            this.check_filetype_xlsx_multisheet.AutoSize = true;
            this.check_filetype_xlsx_multisheet.Enabled = false;
            this.check_filetype_xlsx_multisheet.Location = new System.Drawing.Point(190, 28);
            this.check_filetype_xlsx_multisheet.Name = "check_filetype_xlsx_multisheet";
            this.check_filetype_xlsx_multisheet.Size = new System.Drawing.Size(196, 21);
            this.check_filetype_xlsx_multisheet.TabIndex = 6;
            this.check_filetype_xlsx_multisheet.Text = "check_filetype_xlsx_multisheet";
            this.check_filetype_xlsx_multisheet.UseVisualStyleBackColor = true;
            this.check_filetype_xlsx_multisheet.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // label_filetype_header
            // 
            this.label_filetype_header.AutoSize = true;
            this.label_filetype_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_filetype_header.Location = new System.Drawing.Point(3, -2);
            this.label_filetype_header.Name = "label_filetype_header";
            this.label_filetype_header.Size = new System.Drawing.Size(121, 17);
            this.label_filetype_header.TabIndex = 0;
            this.label_filetype_header.Text = "label_filetype_header";
            // 
            // radio_filetype_xls
            // 
            this.radio_filetype_xls.AutoSize = true;
            this.radio_filetype_xls.Checked = true;
            this.radio_filetype_xls.Location = new System.Drawing.Point(160, 88);
            this.radio_filetype_xls.Name = "radio_filetype_xls";
            this.radio_filetype_xls.Size = new System.Drawing.Size(124, 21);
            this.radio_filetype_xls.TabIndex = 7;
            this.radio_filetype_xls.TabStop = true;
            this.radio_filetype_xls.Text = "radio_filetype_xls";
            this.radio_filetype_xls.UseVisualStyleBackColor = true;
            // 
            // panel_destination_location
            // 
            this.panel_destination_location.Controls.Add(this.check_destination_subfolders);
            this.panel_destination_location.Controls.Add(this.check_destination_overwritefiles);
            this.panel_destination_location.Controls.Add(this.radio_destination_importfolder);
            this.panel_destination_location.Controls.Add(this.label_destination_header);
            this.panel_destination_location.Controls.Add(this.radio_destination_custom);
            this.panel_destination_location.Location = new System.Drawing.Point(0, 32);
            this.panel_destination_location.Name = "panel_destination_location";
            this.panel_destination_location.Size = new System.Drawing.Size(629, 120);
            this.panel_destination_location.TabIndex = 17;
            // 
            // check_destination_subfolders
            // 
            this.check_destination_subfolders.AutoSize = true;
            this.check_destination_subfolders.Location = new System.Drawing.Point(160, 88);
            this.check_destination_subfolders.Name = "check_destination_subfolders";
            this.check_destination_subfolders.Size = new System.Drawing.Size(195, 21);
            this.check_destination_subfolders.TabIndex = 4;
            this.check_destination_subfolders.Text = "check_destination_subfolders";
            this.check_destination_subfolders.UseVisualStyleBackColor = true;
            this.check_destination_subfolders.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // check_destination_overwritefiles
            // 
            this.check_destination_overwritefiles.AutoSize = true;
            this.check_destination_overwritefiles.Location = new System.Drawing.Point(160, 58);
            this.check_destination_overwritefiles.Name = "check_destination_overwritefiles";
            this.check_destination_overwritefiles.Size = new System.Drawing.Size(210, 21);
            this.check_destination_overwritefiles.TabIndex = 3;
            this.check_destination_overwritefiles.Text = "check_destination_overwritefiles";
            this.check_destination_overwritefiles.UseVisualStyleBackColor = true;
            this.check_destination_overwritefiles.CheckedChanged += new System.EventHandler(this.OnCheckbox_CheckChanged);
            // 
            // radio_destination_importfolder
            // 
            this.radio_destination_importfolder.AutoSize = true;
            this.radio_destination_importfolder.Checked = true;
            this.radio_destination_importfolder.Location = new System.Drawing.Point(160, -2);
            this.radio_destination_importfolder.Name = "radio_destination_importfolder";
            this.radio_destination_importfolder.Size = new System.Drawing.Size(205, 21);
            this.radio_destination_importfolder.TabIndex = 1;
            this.radio_destination_importfolder.TabStop = true;
            this.radio_destination_importfolder.Text = "radio_destination_importfolder";
            this.radio_destination_importfolder.UseVisualStyleBackColor = true;
            // 
            // label_destination_header
            // 
            this.label_destination_header.AutoSize = true;
            this.label_destination_header.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label_destination_header.Location = new System.Drawing.Point(3, -2);
            this.label_destination_header.Name = "label_destination_header";
            this.label_destination_header.Size = new System.Drawing.Size(142, 17);
            this.label_destination_header.TabIndex = 0;
            this.label_destination_header.Text = "label_destination_header";
            // 
            // radio_destination_custom
            // 
            this.radio_destination_custom.AutoSize = true;
            this.radio_destination_custom.Location = new System.Drawing.Point(160, 28);
            this.radio_destination_custom.Name = "radio_destination_custom";
            this.radio_destination_custom.Size = new System.Drawing.Size(173, 21);
            this.radio_destination_custom.TabIndex = 2;
            this.radio_destination_custom.Text = "radio_destination_custom";
            this.radio_destination_custom.UseVisualStyleBackColor = true;
            this.radio_destination_custom.CheckedChanged += new System.EventHandler(this.OnRadioButton_CheckChanged);
            // 
            // panel7
            // 
            this.panel7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel7.Controls.Add(this.text_howto_destination);
            this.panel7.Location = new System.Drawing.Point(635, 6);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(589, 216);
            this.panel7.TabIndex = 16;
            // 
            // text_howto_destination
            // 
            this.text_howto_destination.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.text_howto_destination.Dock = System.Windows.Forms.DockStyle.Fill;
            this.text_howto_destination.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.text_howto_destination.Location = new System.Drawing.Point(0, 0);
            this.text_howto_destination.Multiline = true;
            this.text_howto_destination.Name = "text_howto_destination";
            this.text_howto_destination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_howto_destination.Size = new System.Drawing.Size(589, 216);
            this.text_howto_destination.TabIndex = 1;
            this.text_howto_destination.TabStop = false;
            this.text_howto_destination.Text = "text_howto_destination";
            // 
            // chart_thresholds
            // 
            this.chart_thresholds.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_thresholds.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea4.AxisX.Interval = 1D;
            chartArea4.AxisX.IsLabelAutoFit = false;
            chartArea4.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisX.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX.Title = "Well no.";
            chartArea4.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisX.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisX2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.Interval = 10D;
            chartArea4.AxisY.IsLabelAutoFit = false;
            chartArea4.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.Maximum = 100D;
            chartArea4.AxisY.Minimum = 0D;
            chartArea4.AxisY.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea4.AxisY.Title = "Relative movement time";
            chartArea4.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea4.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea4.AxisY.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.AxisY2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea4.BorderColor = System.Drawing.SystemColors.ButtonFace;
            chartArea4.Name = "ChartArea1";
            chartArea4.ShadowColor = System.Drawing.Color.Black;
            this.chart_thresholds.ChartAreas.Add(chartArea4);
            legend4.BackColor = System.Drawing.SystemColors.WindowFrame;
            legend4.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            legend4.IsTextAutoFit = false;
            legend4.MaximumAutoSize = 20F;
            legend4.Name = "chart_thresholds_legend";
            legend4.ShadowColor = System.Drawing.Color.Black;
            this.chart_thresholds.Legends.Add(legend4);
            this.chart_thresholds.Location = new System.Drawing.Point(12, 376);
            this.chart_thresholds.Name = "chart_thresholds";
            this.chart_thresholds.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_thresholds.Size = new System.Drawing.Size(1240, 253);
            this.chart_thresholds.TabIndex = 11;
            this.chart_thresholds.Text = "chart_thresholds";
            title4.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title4.ForeColor = System.Drawing.SystemColors.ButtonFace;
            title4.Name = "chart_thresholds_title";
            title4.Text = "chart_thresholds_title";
            this.chart_thresholds.Titles.Add(title4);
            this.chart_thresholds.Visible = false;
            // 
            // folderBrowserDialog1
            // 
            this.folderBrowserDialog1.RootFolder = System.Environment.SpecialFolder.MyComputer;
            // 
            // chart_importeddata
            // 
            this.chart_importeddata.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_importeddata.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea5.AxisX.Interval = 1D;
            chartArea5.AxisX.IsLabelAutoFit = false;
            chartArea5.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisX.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX.Title = "Well no.";
            chartArea5.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea5.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisX.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisX2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.Interval = 10D;
            chartArea5.AxisY.IsLabelAutoFit = false;
            chartArea5.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.Maximum = 100D;
            chartArea5.AxisY.Minimum = 0D;
            chartArea5.AxisY.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea5.AxisY.Title = "Relative movement time";
            chartArea5.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea5.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.Interval = 10D;
            chartArea5.AxisY2.IsLabelAutoFit = false;
            chartArea5.AxisY2.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY2.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.Maximum = 100D;
            chartArea5.AxisY2.Minimum = 0D;
            chartArea5.AxisY2.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea5.AxisY2.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea5.AxisY2.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea5.AxisY2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea5.BorderColor = System.Drawing.SystemColors.ButtonFace;
            chartArea5.Name = "ChartArea1";
            chartArea5.ShadowColor = System.Drawing.Color.Black;
            this.chart_importeddata.ChartAreas.Add(chartArea5);
            legend5.BackColor = System.Drawing.SystemColors.WindowFrame;
            legend5.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            legend5.IsTextAutoFit = false;
            legend5.MaximumAutoSize = 20F;
            legend5.Name = "chart_importeddata_legend";
            legend5.ShadowColor = System.Drawing.Color.Black;
            this.chart_importeddata.Legends.Add(legend5);
            this.chart_importeddata.Location = new System.Drawing.Point(12, 376);
            this.chart_importeddata.Name = "chart_importeddata";
            this.chart_importeddata.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_importeddata.Size = new System.Drawing.Size(1240, 253);
            this.chart_importeddata.TabIndex = 12;
            this.chart_importeddata.Text = "chart1";
            title5.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title5.ForeColor = System.Drawing.SystemColors.ButtonFace;
            title5.Name = "chart_importeddata_title";
            title5.Text = "chart_importeddata_title";
            this.chart_importeddata.Titles.Add(title5);
            this.chart_importeddata.Visible = false;
            // 
            // chart_result
            // 
            this.chart_result.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart_result.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea6.AxisX.Interval = 1D;
            chartArea6.AxisX.IsLabelAutoFit = false;
            chartArea6.AxisX.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisX.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX.Title = "Well no.";
            chartArea6.AxisX.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea6.AxisX.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisX.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisX2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.Interval = 10D;
            chartArea6.AxisY.IsLabelAutoFit = false;
            chartArea6.AxisY.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.Maximum = 100D;
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.AxisY.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.ScaleBreakStyle.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea6.AxisY.Title = "Relative movement time";
            chartArea6.AxisY.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea6.AxisY.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.Interval = 10D;
            chartArea6.AxisY2.IsLabelAutoFit = false;
            chartArea6.AxisY2.LabelStyle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY2.LabelStyle.ForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.MajorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.MajorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.Maximum = 100D;
            chartArea6.AxisY2.Minimum = 0D;
            chartArea6.AxisY2.MinorGrid.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.MinorTickMark.LineColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.AxisY2.TextOrientation = System.Windows.Forms.DataVisualization.Charting.TextOrientation.Rotated270;
            chartArea6.AxisY2.TitleAlignment = System.Drawing.StringAlignment.Far;
            chartArea6.AxisY2.TitleFont = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            chartArea6.AxisY2.TitleForeColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.BackColor = System.Drawing.SystemColors.WindowFrame;
            chartArea6.BorderColor = System.Drawing.SystemColors.ButtonFace;
            chartArea6.Name = "ChartArea1";
            chartArea6.ShadowColor = System.Drawing.Color.Black;
            this.chart_result.ChartAreas.Add(chartArea6);
            legend6.BackColor = System.Drawing.SystemColors.WindowFrame;
            legend6.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            legend6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            legend6.IsTextAutoFit = false;
            legend6.MaximumAutoSize = 20F;
            legend6.Name = "chart_result_legend";
            legend6.ShadowColor = System.Drawing.Color.Black;
            this.chart_result.Legends.Add(legend6);
            this.chart_result.Location = new System.Drawing.Point(12, 635);
            this.chart_result.Name = "chart_result";
            this.chart_result.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart_result.Size = new System.Drawing.Size(1240, 253);
            this.chart_result.TabIndex = 13;
            this.chart_result.Text = "chart_result";
            title6.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            title6.ForeColor = System.Drawing.SystemColors.ButtonFace;
            title6.Name = "chart_result_title";
            title6.Text = "chart_result_title";
            this.chart_result.Titles.Add(title6);
            this.chart_result.Visible = false;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file,
            this.menu_filehandling,
            this.menu_favorites,
            this.menu_grouping,
            this.menu_help});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(1264, 24);
            this.menu.TabIndex = 14;
            this.menu.Text = "menu";
            // 
            // menu_file
            // 
            this.menu_file.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_file_settings,
            this.menu_file_exit});
            this.menu_file.Name = "menu_file";
            this.menu_file.Size = new System.Drawing.Size(71, 20);
            this.menu_file.Text = "menu_file";
            // 
            // menu_file_settings
            // 
            this.menu_file_settings.Name = "menu_file_settings";
            this.menu_file_settings.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.menu_file_settings.Size = new System.Drawing.Size(197, 22);
            this.menu_file_settings.Text = "menu_file_settings";
            this.menu_file_settings.Click += new System.EventHandler(this.menu_file_settings_Click);
            // 
            // menu_file_exit
            // 
            this.menu_file_exit.Name = "menu_file_exit";
            this.menu_file_exit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.menu_file_exit.Size = new System.Drawing.Size(197, 22);
            this.menu_file_exit.Text = "menu_file_exit";
            this.menu_file_exit.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // menu_filehandling
            // 
            this.menu_filehandling.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_filehandling_entryup,
            this.menu_filehandling_entrydown,
            this.toolStripSeparator3,
            this.menu_filehandling_removeentry});
            this.menu_filehandling.Name = "menu_filehandling";
            this.menu_filehandling.Size = new System.Drawing.Size(118, 20);
            this.menu_filehandling.Text = "menu_filehandling";
            this.menu_filehandling.Visible = false;
            // 
            // menu_filehandling_entryup
            // 
            this.menu_filehandling_entryup.Name = "menu_filehandling_entryup";
            this.menu_filehandling_entryup.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Up)));
            this.menu_filehandling_entryup.Size = new System.Drawing.Size(302, 22);
            this.menu_filehandling_entryup.Text = "menu_filehandling_entryup";
            // 
            // menu_filehandling_entrydown
            // 
            this.menu_filehandling_entrydown.BackColor = System.Drawing.SystemColors.Control;
            this.menu_filehandling_entrydown.Name = "menu_filehandling_entrydown";
            this.menu_filehandling_entrydown.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Down)));
            this.menu_filehandling_entrydown.Size = new System.Drawing.Size(302, 22);
            this.menu_filehandling_entrydown.Text = "menu_filehandling_entrydown";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(299, 6);
            // 
            // menu_filehandling_removeentry
            // 
            this.menu_filehandling_removeentry.Checked = true;
            this.menu_filehandling_removeentry.CheckOnClick = true;
            this.menu_filehandling_removeentry.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menu_filehandling_removeentry.Name = "menu_filehandling_removeentry";
            this.menu_filehandling_removeentry.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Delete)));
            this.menu_filehandling_removeentry.Size = new System.Drawing.Size(302, 22);
            this.menu_filehandling_removeentry.Text = "menu_filehandling_removeentry";
            this.menu_filehandling_removeentry.Click += new System.EventHandler(this.menu_filehandling_removeentry_Click);
            // 
            // menu_favorites
            // 
            this.menu_favorites.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_favorites_load1,
            this.menu_favorites_load2,
            this.menu_favorites_load3,
            this.toolStripSeparator1,
            this.menu_favorites_save1,
            this.menu_favorites_save2,
            this.menu_favorites_save3});
            this.menu_favorites.Name = "menu_favorites";
            this.menu_favorites.Size = new System.Drawing.Size(100, 20);
            this.menu_favorites.Text = "menu_favorites";
            // 
            // menu_favorites_load1
            // 
            this.menu_favorites_load1.Name = "menu_favorites_load1";
            this.menu_favorites_load1.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.menu_favorites_load1.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_load1.Text = "menu_favorites_load1";
            this.menu_favorites_load1.Click += new System.EventHandler(this.load10ToolStripMenuItem_Click);
            // 
            // menu_favorites_load2
            // 
            this.menu_favorites_load2.Name = "menu_favorites_load2";
            this.menu_favorites_load2.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.menu_favorites_load2.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_load2.Text = "menu_favorites_load2";
            this.menu_favorites_load2.Click += new System.EventHandler(this.load20ToolStripMenuItem_Click);
            // 
            // menu_favorites_load3
            // 
            this.menu_favorites_load3.Name = "menu_favorites_load3";
            this.menu_favorites_load3.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.menu_favorites_load3.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_load3.Text = "menu_favorites_load3";
            this.menu_favorites_load3.Click += new System.EventHandler(this.load30ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(234, 6);
            // 
            // menu_favorites_save1
            // 
            this.menu_favorites_save1.Name = "menu_favorites_save1";
            this.menu_favorites_save1.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F1)));
            this.menu_favorites_save1.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_save1.Text = "menu_favorites_save1";
            this.menu_favorites_save1.Click += new System.EventHandler(this.saveAs1ToolStripMenuItem_Click);
            // 
            // menu_favorites_save2
            // 
            this.menu_favorites_save2.Name = "menu_favorites_save2";
            this.menu_favorites_save2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F2)));
            this.menu_favorites_save2.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_save2.Text = "menu_favorites_save2";
            this.menu_favorites_save2.Click += new System.EventHandler(this.saveAs2ToolStripMenuItem_Click);
            // 
            // menu_favorites_save3
            // 
            this.menu_favorites_save3.Name = "menu_favorites_save3";
            this.menu_favorites_save3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F3)));
            this.menu_favorites_save3.Size = new System.Drawing.Size(237, 22);
            this.menu_favorites_save3.Text = "menu_favorites_save3";
            this.menu_favorites_save3.Click += new System.EventHandler(this.saveAs3ToolStripMenuItem_Click);
            // 
            // menu_grouping
            // 
            this.menu_grouping.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_grouping_by2,
            this.menu_grouping_by3,
            this.menu_grouping_by4,
            this.toolStripSeparator2,
            this.menu_grouping_renameutility});
            this.menu_grouping.Name = "menu_grouping";
            this.menu_grouping.Size = new System.Drawing.Size(104, 20);
            this.menu_grouping.Text = "menu_grouping";
            this.menu_grouping.Visible = false;
            // 
            // menu_grouping_by2
            // 
            this.menu_grouping_by2.Name = "menu_grouping_by2";
            this.menu_grouping_by2.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D2)));
            this.menu_grouping_by2.Size = new System.Drawing.Size(277, 22);
            this.menu_grouping_by2.Text = "menu_grouping_by2";
            this.menu_grouping_by2.Click += new System.EventHandler(this.menu_grouping2_Click);
            // 
            // menu_grouping_by3
            // 
            this.menu_grouping_by3.Name = "menu_grouping_by3";
            this.menu_grouping_by3.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D3)));
            this.menu_grouping_by3.Size = new System.Drawing.Size(277, 22);
            this.menu_grouping_by3.Text = "menu_grouping_by3";
            this.menu_grouping_by3.Click += new System.EventHandler(this.menu_grouping3_Click);
            // 
            // menu_grouping_by4
            // 
            this.menu_grouping_by4.Name = "menu_grouping_by4";
            this.menu_grouping_by4.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.D4)));
            this.menu_grouping_by4.Size = new System.Drawing.Size(277, 22);
            this.menu_grouping_by4.Text = "menu_grouping_by4";
            this.menu_grouping_by4.Click += new System.EventHandler(this.menu_grouping4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(274, 6);
            // 
            // menu_grouping_renameutility
            // 
            this.menu_grouping_renameutility.Name = "menu_grouping_renameutility";
            this.menu_grouping_renameutility.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.R)));
            this.menu_grouping_renameutility.Size = new System.Drawing.Size(277, 22);
            this.menu_grouping_renameutility.Text = "menu_grouping_renameutility";
            this.menu_grouping_renameutility.Click += new System.EventHandler(this.menugroupingrenameutilityToolStripMenuItem_Click);
            // 
            // menu_help
            // 
            this.menu_help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menu_help_helpandsupport,
            this.menu_help_about});
            this.menu_help.Name = "menu_help";
            this.menu_help.Size = new System.Drawing.Size(78, 20);
            this.menu_help.Text = "menu_help";
            // 
            // menu_help_helpandsupport
            // 
            this.menu_help_helpandsupport.Name = "menu_help_helpandsupport";
            this.menu_help_helpandsupport.ShortcutKeys = System.Windows.Forms.Keys.F11;
            this.menu_help_helpandsupport.Size = new System.Drawing.Size(247, 22);
            this.menu_help_helpandsupport.Text = "menu_help_helpandsupport";
            this.menu_help_helpandsupport.Click += new System.EventHandler(this.helpSupportToolStripMenuItem_Click);
            // 
            // menu_help_about
            // 
            this.menu_help_about.Name = "menu_help_about";
            this.menu_help_about.ShortcutKeys = System.Windows.Forms.Keys.F12;
            this.menu_help_about.Size = new System.Drawing.Size(247, 22);
            this.menu_help_about.Text = "menu_help_about";
            this.menu_help_about.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // form_converter
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.CancelButton = this.btnExit;
            this.ClientSize = new System.Drawing.Size(1264, 873);
            this.Controls.Add(this.tabcontrol);
            this.Controls.Add(this.chart_result);
            this.Controls.Add(this.checkAutostart);
            this.Controls.Add(this.label_softwarename);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.chart_importeddata);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblInfo);
            this.Controls.Add(this.chart_thresholds);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.ForeColor = System.Drawing.SystemColors.ButtonFace;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menu;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(609, 402);
            this.Name = "form_converter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "form_converter";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.formConverter_FormClosing);
            this.Load += new System.EventHandler(this.formConverter_Load);
            this.ResizeBegin += new System.EventHandler(this.formConverter_ResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.formConverter_ResizeEnd);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.formConverter_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.formConverter_DragEnter);
            this.tabcontrol.ResumeLayout(false);
            this.tab_import.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tab_basic.ResumeLayout(false);
            this.tab_basic.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tab_thresholds.ResumeLayout(false);
            this.tab_thresholds.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.tab_grouping.ResumeLayout(false);
            this.panel_grouping_groupnaming.ResumeLayout(false);
            this.panel_grouping_groupnaming.PerformLayout();
            this.panel_grouping_multifiles.ResumeLayout(false);
            this.panel_grouping_multifiles.PerformLayout();
            this.panel_Grouping_Tutorial.ResumeLayout(false);
            this.panel_Grouping_Tutorial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grid_grouping)).EndInit();
            this.tab_results.ResumeLayout(false);
            this.tab_results.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.tab_destination.ResumeLayout(false);
            this.panel8.ResumeLayout(false);
            this.panel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel_destination_2circle.ResumeLayout(false);
            this.panel_destination_2circle.PerformLayout();
            this.panel_destination_options.ResumeLayout(false);
            this.panel_destination_options.PerformLayout();
            this.panel_destination_filetype.ResumeLayout(false);
            this.panel_destination_filetype.PerformLayout();
            this.panel_destination_location.ResumeLayout(false);
            this.panel_destination_location.PerformLayout();
            this.panel7.ResumeLayout(false);
            this.panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart_thresholds)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_importeddata)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_result)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label_softwarename;
        private System.Windows.Forms.Label lblInfo;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.CheckBox checkAutostart;
        private System.Windows.Forms.TabControl tabcontrol;
        private System.Windows.Forms.TabPage tab_basic;
        private System.Windows.Forms.TabPage tab_thresholds;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_thresholds;
        private System.Windows.Forms.TabPage tab_destination;
        private System.Windows.Forms.RadioButton radio_destination_custom;
        private System.Windows.Forms.RadioButton radio_destination_importfolder;
        private System.Windows.Forms.Label label_destination_header;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.CheckBox check_clean_duplicates;
        private System.Windows.Forms.CheckBox check_clean_invalidsum;
        private System.Windows.Forms.Label label_thresholds_header_empty;
        private System.Windows.Forms.Label label_thresholds_header_inactive;
        private System.Windows.Forms.TextBox text_track_empty_max;
        private System.Windows.Forms.TextBox text_track_inactive_max;
        private System.Windows.Forms.Label label_thresholds_fish_empty;
        private System.Windows.Forms.Label label_thresholds_fish_inactive;
        private System.Windows.Forms.TextBox text_track_empty_min;
        private System.Windows.Forms.TextBox text_track_inactive_min;
        private System.Windows.Forms.Label label_thresholds_fish_fast;
        private System.Windows.Forms.Label label_thresholds_fish_slow;
        private System.Windows.Forms.Label label_thresholds_header_fast;
        private System.Windows.Forms.Label label_thresholds_header_slow;
        private System.Windows.Forms.TextBox text_track_slow_max;
        private System.Windows.Forms.TextBox text_track_fast_max;
        private System.Windows.Forms.TextBox text_track_fast_min;
        private System.Windows.Forms.TextBox text_track_slow_min;
        private System.Windows.Forms.Label label_thresholds_header_max;
        private System.Windows.Forms.Label label_thresholds_header_min;
        private System.Windows.Forms.RadioButton radio_filetype_xls;
        private System.Windows.Forms.RadioButton radio_filetype_xlsx;
        private System.Windows.Forms.CheckBox check_filetype_xlsx_multisheet;
        private System.Windows.Forms.CheckBox check_chartoptions_savecharts;
        private System.Windows.Forms.CheckBox check_destination_overwritefiles;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_importeddata;
        private System.Windows.Forms.TabPage tab_results;
        private System.Windows.Forms.Button button_basic_next;
        private System.Windows.Forms.Button button_thresholds_next;
        private System.Windows.Forms.Button button_thresholds_back;
        private System.Windows.Forms.Button button_results_back;
        private System.Windows.Forms.Label label_thresholds_fish_lines;
        private System.Windows.Forms.TextBox text_animal_threshold_max;
        private System.Windows.Forms.TextBox text_animal_threshold_min;
        private System.Windows.Forms.Label label_thresholds_header_lines;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.ListView list_Animals;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_result;
        private System.Windows.Forms.CheckBox check_chart_upscaling;
        private System.Windows.Forms.Button button_results_next;
        private System.Windows.Forms.Button button_destination_createfiles;
        private System.Windows.Forms.Button button_destination_back;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem menu_file;
        private System.Windows.Forms.ToolStripMenuItem menu_file_exit;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.TextBox text_howto_basics;
        private System.Windows.Forms.TextBox text_howto_thresholds;
        private System.Windows.Forms.TextBox text_howto_results;
        private System.Windows.Forms.TextBox text_howto_destination;
        private System.Windows.Forms.Panel panel_destination_location;
        private System.Windows.Forms.Panel panel_destination_options;
        private System.Windows.Forms.CheckBox check_dataoptions_addsumcolumns;
        private System.Windows.Forms.Label label_dataoptions_header;
        private System.Windows.Forms.Panel panel_destination_filetype;
        private System.Windows.Forms.CheckBox check_filetype_xlsx_includefilters;
        private System.Windows.Forms.Label label_filetype_header;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_load1;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_load2;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_load3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_save1;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_save2;
        private System.Windows.Forms.ToolStripMenuItem menu_favorites_save3;
        private System.Windows.Forms.ToolStripMenuItem menu_help;
        private System.Windows.Forms.ToolStripMenuItem menu_help_helpandsupport;
        private System.Windows.Forms.ToolStripMenuItem menu_help_about;
        private System.Windows.Forms.TabPage tab_grouping;
        private System.Windows.Forms.DataGridView grid_grouping;
        private System.Windows.Forms.Panel panel_grouping_multifiles;
        private System.Windows.Forms.ComboBox txtGrouping_MultifileSelector;
        private System.Windows.Forms.Label label_grouping_multifiles_info;
        private System.Windows.Forms.Panel panel_Grouping_Tutorial;
        private System.Windows.Forms.TextBox text_howto_grouping;
        private System.Windows.Forms.ToolStripMenuItem menu_grouping;
        private System.Windows.Forms.ToolStripMenuItem menu_grouping_by2;
        private System.Windows.Forms.ToolStripMenuItem menu_grouping_by3;
        private System.Windows.Forms.ToolStripMenuItem menu_grouping_by4;
        private System.Windows.Forms.Button button_grouping_next;
        private System.Windows.Forms.Button button_grouping_back;
        private System.Windows.Forms.ToolStripMenuItem menu_file_settings;
        private System.Windows.Forms.TabPage tab_import;
        private System.Windows.Forms.Button button_import_next;
        private System.Windows.Forms.TabPage tab_2circletracks;
        private System.Windows.Forms.Button button_basics_back;
        private System.Windows.Forms.Panel panel_destination_2circle;
        private System.Windows.Forms.CheckBox check_2circle_merge;
        private System.Windows.Forms.CheckBox check_2circle_chart_outer;
        private System.Windows.Forms.Label label_2circle_header;
        private System.Windows.Forms.CheckBox check_2circle_chart_inner;
        private System.Windows.Forms.CheckBox check_2circle_chart_combined;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ListView list_ImportStatus;
        private System.Windows.Forms.ColumnHeader column_import_check;
        private System.Windows.Forms.ColumnHeader column_import_filename;
        private System.Windows.Forms.ColumnHeader column_import_animals;
        private System.Windows.Forms.ColumnHeader column_import_lines;
        private System.Windows.Forms.Panel panel_grouping_groupnaming;
        private System.Windows.Forms.Button button_groupnaming_done;
        public System.Windows.Forms.TextBox text_groupnaming_group9;
        private System.Windows.Forms.Label label_groupnaming_group9;
        public System.Windows.Forms.TextBox text_groupnaming_group8;
        private System.Windows.Forms.Label label_groupnaming_group8;
        public System.Windows.Forms.TextBox text_groupnaming_group7;
        private System.Windows.Forms.Label label_groupnaming_group7;
        public System.Windows.Forms.TextBox text_groupnaming_group6;
        private System.Windows.Forms.Label label_groupnaming_group6;
        public System.Windows.Forms.TextBox text_groupnaming_group5;
        private System.Windows.Forms.Label label_groupnaming_group5;
        public System.Windows.Forms.TextBox text_groupnaming_group4;
        private System.Windows.Forms.Label label_groupnaming_group4;
        public System.Windows.Forms.TextBox text_groupnaming_group3;
        private System.Windows.Forms.Label label_groupnaming_group3;
        public System.Windows.Forms.TextBox text_groupnaming_group2;
        private System.Windows.Forms.Label label_groupnaming_group2;
        public System.Windows.Forms.TextBox text_groupnaming_group1;
        private System.Windows.Forms.Label label_groupnaming_group1;
        public System.Windows.Forms.TextBox text_groupnaming_group0;
        private System.Windows.Forms.Label label_groupnaming_group0;
        private System.Windows.Forms.Label label_groupnaming_header;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem menu_grouping_renameutility;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox check_chartoptions_xaxis_animalname;
        private System.Windows.Forms.Label label_chartoptions_header;
        private System.Windows.Forms.CheckBox check_dataoptions_reordercounting;
        private System.Windows.Forms.CheckBox check_dataoptions_addgroupcolumns;
        private System.Windows.Forms.CheckBox check_chartoptions_ownfolder;
        private System.Windows.Forms.CheckBox check_destination_subfolders;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.CheckBox check_imagemerger_enabled;
        private System.Windows.Forms.Label label_imagemerger_header;
        private System.Windows.Forms.Button button_cancel_files;
        private System.Windows.Forms.ColumnHeader column_import_duplicates;
        private System.Windows.Forms.ColumnHeader column_import_problems;
        private System.Windows.Forms.ColumnHeader column_import_imagesfound;
        private System.Windows.Forms.ColumnHeader column_import_secpertrack;
        private System.Windows.Forms.ColumnHeader column_import_duration;
        private System.Windows.Forms.ToolStripMenuItem menu_filehandling;
        private System.Windows.Forms.ToolStripMenuItem menu_filehandling_entryup;
        private System.Windows.Forms.ToolStripMenuItem menu_filehandling_entrydown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem menu_filehandling_removeentry;
    }
}