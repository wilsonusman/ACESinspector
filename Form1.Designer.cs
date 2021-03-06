﻿namespace ACESinspector
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnSelectACESfile = new System.Windows.Forms.Button();
            this.lblACESfilePath = new System.Windows.Forms.Label();
            this.btnSelectVCdbFile = new System.Windows.Forms.Button();
            this.lblVCdbFilePath = new System.Windows.Forms.Label();
            this.btnSelectPCdbFile = new System.Windows.Forms.Button();
            this.lblPCdbFilePath = new System.Windows.Forms.Label();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.dgParts = new System.Windows.Forms.DataGridView();
            this.dgPartsPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPartsAppCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPartsParttypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgPartsPositions = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.lblDifferentialsSummary = new System.Windows.Forms.Label();
            this.lblDifferentialsLabel = new System.Windows.Forms.Label();
            this.progressBarDifferentials = new System.Windows.Forms.ProgressBar();
            this.pictureBoxParttypeDisagreement = new System.Windows.Forms.PictureBox();
            this.progressBarParttypeDisagreement = new System.Windows.Forms.ProgressBar();
            this.lblParttypeDisagreement = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBoxInvalidConfigurations = new System.Windows.Forms.PictureBox();
            this.pictureBoxParttypePosition = new System.Windows.Forms.PictureBox();
            this.pictureBoxInvalidVCdbCodes = new System.Windows.Forms.PictureBox();
            this.pictureBoxInvalidBasevehicles = new System.Windows.Forms.PictureBox();
            this.pictureBoxOverlaps = new System.Windows.Forms.PictureBox();
            this.pictureBoxDuplicates = new System.Windows.Forms.PictureBox();
            this.pictureBoxCNCoverlaps = new System.Windows.Forms.PictureBox();
            this.progressBarInvalidConfigurations = new System.Windows.Forms.ProgressBar();
            this.progressBarParttypePosition = new System.Windows.Forms.ProgressBar();
            this.progressBarInvalidVCdbCodes = new System.Windows.Forms.ProgressBar();
            this.progressBarInvalidBasevehicles = new System.Windows.Forms.ProgressBar();
            this.progressBarOverlaps = new System.Windows.Forms.ProgressBar();
            this.progressBarCNCoverlaps = new System.Windows.Forms.ProgressBar();
            this.progressBarDuplicates = new System.Windows.Forms.ProgressBar();
            this.lblInvalidParttypePositionCount = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.lblInvalidVCdbCodesCount = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lblInvalidConfigurationsCount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.lblInvalidBasevehilcesCount = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lblCNCoverlapsCount = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.lblOverlapsCount = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.lblDuplicateApps = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lblStatsErrorsCount = new System.Windows.Forms.Label();
            this.lblStatsWarningsCount = new System.Windows.Forms.Label();
            this.lblStatsPartsCount = new System.Windows.Forms.Label();
            this.lblStatsAppsCount = new System.Windows.Forms.Label();
            this.lblStatsQdbVersion = new System.Windows.Forms.Label();
            this.lblStatsPCdbVersion = new System.Windows.Forms.Label();
            this.lblStatsVCdbVersion = new System.Windows.Forms.Label();
            this.lblStatsACESversion = new System.Windows.Forms.Label();
            this.lblStatsTitle = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tabPageExports = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnNetChangeExportSave = new System.Windows.Forms.Button();
            this.lblNetChangeExportFilePath = new System.Windows.Forms.Label();
            this.btnSelectNetChangeFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectBgExportFile = new System.Windows.Forms.Button();
            this.btnBgExportSave = new System.Windows.Forms.Button();
            this.lblBgExportFilePath = new System.Windows.Forms.Label();
            this.groupBoxDataExport = new System.Windows.Forms.GroupBox();
            this.lblAppExportFilePath = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSelectAppExportFile = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBoxExportDelimiter = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnAppExportSave = new System.Windows.Forms.Button();
            this.groupBoxAssessment = new System.Windows.Forms.GroupBox();
            this.lblAssessmentFilePath = new System.Windows.Forms.Label();
            this.btnAssessmentSave = new System.Windows.Forms.Button();
            this.btnSelectAssessmentFile = new System.Windows.Forms.Button();
            this.tabPageParts = new System.Windows.Forms.TabPage();
            this.tabPagePartsMultiTypes = new System.Windows.Forms.TabPage();
            this.dgParttypeDisagreement = new System.Windows.Forms.DataGridView();
            this.dgParttypeDisagreementPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgParttypeDisagreementParttypes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageDuplicates = new System.Windows.Forms.TabPage();
            this.dgDuplicates = new System.Windows.Forms.DataGridView();
            this.dgDuplicatesBaseVehicleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesAttributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgDuplicatesAppIds = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageCNCoverlaps = new System.Windows.Forms.TabPage();
            this.dgCNCoverlaps = new System.Windows.Forms.DataGridView();
            this.dbCNCgroupnumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCapplicationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCbasevehicleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCmake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCmodel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCyear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCparttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCposition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCqty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgCNCqualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageOverlaps = new System.Windows.Forms.TabPage();
            this.dgOverlaps = new System.Windows.Forms.DataGridView();
            this.dgOverlapsBaseVehicleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsAttributes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgOverlapsParts = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageInvalidBasevids = new System.Windows.Forms.TabPage();
            this.dgBasevids = new System.Windows.Forms.DataGridView();
            this.dgBasevidsApplicationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsBasevid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgBasevidsQualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageInvalidVCdbCodes = new System.Windows.Forms.TabPage();
            this.dgVCdbCodes = new System.Windows.Forms.DataGridView();
            this.dgVCdbCodesApplicationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesQualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbCodesNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageParttypePosition = new System.Windows.Forms.TabPage();
            this.dgParttypePosition = new System.Windows.Forms.DataGridView();
            this.dataGridViewParttypePositionError = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionAppId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionBasevid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionQualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewParttypePositionPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageInvalidConfigs = new System.Windows.Forms.TabPage();
            this.dgVCdbConfigs = new System.Windows.Forms.DataGridView();
            this.tabPageAddsDropsParts = new System.Windows.Forms.TabPage();
            this.dgAddsDropsParts = new System.Windows.Forms.DataGridView();
            this.dgAddsDropsPartsAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabPageAddsDropsVehicles = new System.Windows.Forms.TabPage();
            this.dgAddsDropsVehicles = new System.Windows.Forms.DataGridView();
            this.dgAddsDropsVehiclesAction = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesBaseVid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesQualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgAddsDropsVehiclesMfrLabel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblStatus = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.lblAppVersion = new System.Windows.Forms.Label();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.btnSelectReferenceACESfile = new System.Windows.Forms.Button();
            this.lblReferenceACESfilePath = new System.Windows.Forms.Label();
            this.dgVCdbConfigsApplicationid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsBasevehicleid = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsMake = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsModel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsYear = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsParttype = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsPosition = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsQty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsPart = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsQualifiers = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgVCdbConfigsNotes = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPageStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParttypeDisagreement)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidConfigurations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParttypePosition)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidVCdbCodes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidBasevehicles)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDuplicates)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCNCoverlaps)).BeginInit();
            this.tabPageExports.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBoxDataExport.SuspendLayout();
            this.groupBoxAssessment.SuspendLayout();
            this.tabPageParts.SuspendLayout();
            this.tabPagePartsMultiTypes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParttypeDisagreement)).BeginInit();
            this.tabPageDuplicates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgDuplicates)).BeginInit();
            this.tabPageCNCoverlaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgCNCoverlaps)).BeginInit();
            this.tabPageOverlaps.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgOverlaps)).BeginInit();
            this.tabPageInvalidBasevids.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgBasevids)).BeginInit();
            this.tabPageInvalidVCdbCodes.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVCdbCodes)).BeginInit();
            this.tabPageParttypePosition.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgParttypePosition)).BeginInit();
            this.tabPageInvalidConfigs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgVCdbConfigs)).BeginInit();
            this.tabPageAddsDropsParts.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddsDropsParts)).BeginInit();
            this.tabPageAddsDropsVehicles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAddsDropsVehicles)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSelectACESfile
            // 
            this.btnSelectACESfile.Location = new System.Drawing.Point(12, 12);
            this.btnSelectACESfile.Name = "btnSelectACESfile";
            this.btnSelectACESfile.Size = new System.Drawing.Size(134, 23);
            this.btnSelectACESfile.TabIndex = 2;
            this.btnSelectACESfile.Text = "Select Primary ACES file";
            this.btnSelectACESfile.UseVisualStyleBackColor = true;
            this.btnSelectACESfile.Click += new System.EventHandler(this.btnSelectACESfile_Click);
            // 
            // lblACESfilePath
            // 
            this.lblACESfilePath.AutoSize = true;
            this.lblACESfilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblACESfilePath.Location = new System.Drawing.Point(153, 15);
            this.lblACESfilePath.Name = "lblACESfilePath";
            this.lblACESfilePath.Size = new System.Drawing.Size(45, 16);
            this.lblACESfilePath.TabIndex = 3;
            this.lblACESfilePath.Text = "label1";
            // 
            // btnSelectVCdbFile
            // 
            this.btnSelectVCdbFile.Location = new System.Drawing.Point(12, 70);
            this.btnSelectVCdbFile.Name = "btnSelectVCdbFile";
            this.btnSelectVCdbFile.Size = new System.Drawing.Size(134, 23);
            this.btnSelectVCdbFile.TabIndex = 4;
            this.btnSelectVCdbFile.Text = "Select VCdb";
            this.btnSelectVCdbFile.UseVisualStyleBackColor = true;
            this.btnSelectVCdbFile.Click += new System.EventHandler(this.btnSelectVCdbFile_Click);
            // 
            // lblVCdbFilePath
            // 
            this.lblVCdbFilePath.AutoSize = true;
            this.lblVCdbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVCdbFilePath.Location = new System.Drawing.Point(153, 73);
            this.lblVCdbFilePath.Name = "lblVCdbFilePath";
            this.lblVCdbFilePath.Size = new System.Drawing.Size(45, 16);
            this.lblVCdbFilePath.TabIndex = 5;
            this.lblVCdbFilePath.Text = "label1";
            // 
            // btnSelectPCdbFile
            // 
            this.btnSelectPCdbFile.Location = new System.Drawing.Point(12, 99);
            this.btnSelectPCdbFile.Name = "btnSelectPCdbFile";
            this.btnSelectPCdbFile.Size = new System.Drawing.Size(134, 23);
            this.btnSelectPCdbFile.TabIndex = 6;
            this.btnSelectPCdbFile.Text = "Select PCdb";
            this.btnSelectPCdbFile.UseVisualStyleBackColor = true;
            this.btnSelectPCdbFile.Click += new System.EventHandler(this.btnSelectPCdbFile_Click);
            // 
            // lblPCdbFilePath
            // 
            this.lblPCdbFilePath.AutoSize = true;
            this.lblPCdbFilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPCdbFilePath.Location = new System.Drawing.Point(153, 102);
            this.lblPCdbFilePath.Name = "lblPCdbFilePath";
            this.lblPCdbFilePath.Size = new System.Drawing.Size(45, 16);
            this.lblPCdbFilePath.TabIndex = 7;
            this.lblPCdbFilePath.Text = "label1";
            // 
            // btnAnalyze
            // 
            this.btnAnalyze.Location = new System.Drawing.Point(12, 131);
            this.btnAnalyze.Name = "btnAnalyze";
            this.btnAnalyze.Size = new System.Drawing.Size(68, 33);
            this.btnAnalyze.TabIndex = 11;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // dgParts
            // 
            this.dgParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgPartsPart,
            this.dgPartsAppCount,
            this.dgPartsParttypes,
            this.dgPartsPositions});
            this.dgParts.Location = new System.Drawing.Point(3, 3);
            this.dgParts.Name = "dgParts";
            this.dgParts.Size = new System.Drawing.Size(838, 424);
            this.dgParts.TabIndex = 0;
            // 
            // dgPartsPart
            // 
            this.dgPartsPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPartsPart.HeaderText = "Part";
            this.dgPartsPart.Name = "dgPartsPart";
            this.dgPartsPart.ReadOnly = true;
            this.dgPartsPart.Width = 51;
            // 
            // dgPartsAppCount
            // 
            this.dgPartsAppCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPartsAppCount.HeaderText = "Application Count";
            this.dgPartsAppCount.Name = "dgPartsAppCount";
            this.dgPartsAppCount.ReadOnly = true;
            this.dgPartsAppCount.Width = 105;
            // 
            // dgPartsParttypes
            // 
            this.dgPartsParttypes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPartsParttypes.HeaderText = "Part Types";
            this.dgPartsParttypes.Name = "dgPartsParttypes";
            this.dgPartsParttypes.ReadOnly = true;
            this.dgPartsParttypes.Width = 77;
            // 
            // dgPartsPositions
            // 
            this.dgPartsPositions.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgPartsPositions.HeaderText = "Positions";
            this.dgPartsPositions.Name = "dgPartsPositions";
            this.dgPartsPositions.ReadOnly = true;
            this.dgPartsPositions.Width = 74;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageStats);
            this.tabControl1.Controls.Add(this.tabPageExports);
            this.tabControl1.Controls.Add(this.tabPageParts);
            this.tabControl1.Controls.Add(this.tabPagePartsMultiTypes);
            this.tabControl1.Controls.Add(this.tabPageDuplicates);
            this.tabControl1.Controls.Add(this.tabPageCNCoverlaps);
            this.tabControl1.Controls.Add(this.tabPageOverlaps);
            this.tabControl1.Controls.Add(this.tabPageInvalidBasevids);
            this.tabControl1.Controls.Add(this.tabPageInvalidVCdbCodes);
            this.tabControl1.Controls.Add(this.tabPageParttypePosition);
            this.tabControl1.Controls.Add(this.tabPageInvalidConfigs);
            this.tabControl1.Controls.Add(this.tabPageAddsDropsParts);
            this.tabControl1.Controls.Add(this.tabPageAddsDropsVehicles);
            this.tabControl1.Location = new System.Drawing.Point(3, 173);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(845, 449);
            this.tabControl1.TabIndex = 12;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Controls.Add(this.lblDifferentialsSummary);
            this.tabPageStats.Controls.Add(this.lblDifferentialsLabel);
            this.tabPageStats.Controls.Add(this.progressBarDifferentials);
            this.tabPageStats.Controls.Add(this.pictureBoxParttypeDisagreement);
            this.tabPageStats.Controls.Add(this.progressBarParttypeDisagreement);
            this.tabPageStats.Controls.Add(this.lblParttypeDisagreement);
            this.tabPageStats.Controls.Add(this.label18);
            this.tabPageStats.Controls.Add(this.pictureBoxInvalidConfigurations);
            this.tabPageStats.Controls.Add(this.pictureBoxParttypePosition);
            this.tabPageStats.Controls.Add(this.pictureBoxInvalidVCdbCodes);
            this.tabPageStats.Controls.Add(this.pictureBoxInvalidBasevehicles);
            this.tabPageStats.Controls.Add(this.pictureBoxOverlaps);
            this.tabPageStats.Controls.Add(this.pictureBoxDuplicates);
            this.tabPageStats.Controls.Add(this.pictureBoxCNCoverlaps);
            this.tabPageStats.Controls.Add(this.progressBarInvalidConfigurations);
            this.tabPageStats.Controls.Add(this.progressBarParttypePosition);
            this.tabPageStats.Controls.Add(this.progressBarInvalidVCdbCodes);
            this.tabPageStats.Controls.Add(this.progressBarInvalidBasevehicles);
            this.tabPageStats.Controls.Add(this.progressBarOverlaps);
            this.tabPageStats.Controls.Add(this.progressBarCNCoverlaps);
            this.tabPageStats.Controls.Add(this.progressBarDuplicates);
            this.tabPageStats.Controls.Add(this.lblInvalidParttypePositionCount);
            this.tabPageStats.Controls.Add(this.label19);
            this.tabPageStats.Controls.Add(this.lblInvalidVCdbCodesCount);
            this.tabPageStats.Controls.Add(this.label17);
            this.tabPageStats.Controls.Add(this.lblInvalidConfigurationsCount);
            this.tabPageStats.Controls.Add(this.label16);
            this.tabPageStats.Controls.Add(this.lblInvalidBasevehilcesCount);
            this.tabPageStats.Controls.Add(this.label15);
            this.tabPageStats.Controls.Add(this.lblCNCoverlapsCount);
            this.tabPageStats.Controls.Add(this.label14);
            this.tabPageStats.Controls.Add(this.lblOverlapsCount);
            this.tabPageStats.Controls.Add(this.label13);
            this.tabPageStats.Controls.Add(this.lblDuplicateApps);
            this.tabPageStats.Controls.Add(this.label12);
            this.tabPageStats.Controls.Add(this.lblStatsErrorsCount);
            this.tabPageStats.Controls.Add(this.lblStatsWarningsCount);
            this.tabPageStats.Controls.Add(this.lblStatsPartsCount);
            this.tabPageStats.Controls.Add(this.lblStatsAppsCount);
            this.tabPageStats.Controls.Add(this.lblStatsQdbVersion);
            this.tabPageStats.Controls.Add(this.lblStatsPCdbVersion);
            this.tabPageStats.Controls.Add(this.lblStatsVCdbVersion);
            this.tabPageStats.Controls.Add(this.lblStatsACESversion);
            this.tabPageStats.Controls.Add(this.lblStatsTitle);
            this.tabPageStats.Controls.Add(this.label10);
            this.tabPageStats.Controls.Add(this.label9);
            this.tabPageStats.Controls.Add(this.label8);
            this.tabPageStats.Controls.Add(this.label7);
            this.tabPageStats.Controls.Add(this.label6);
            this.tabPageStats.Controls.Add(this.label5);
            this.tabPageStats.Controls.Add(this.label4);
            this.tabPageStats.Controls.Add(this.label3);
            this.tabPageStats.Controls.Add(this.label2);
            this.tabPageStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Size = new System.Drawing.Size(837, 423);
            this.tabPageStats.TabIndex = 9;
            this.tabPageStats.Text = "Statistics";
            this.tabPageStats.UseVisualStyleBackColor = true;
            // 
            // lblDifferentialsSummary
            // 
            this.lblDifferentialsSummary.AutoSize = true;
            this.lblDifferentialsSummary.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifferentialsSummary.Location = new System.Drawing.Point(332, 394);
            this.lblDifferentialsSummary.Name = "lblDifferentialsSummary";
            this.lblDifferentialsSummary.Size = new System.Drawing.Size(42, 20);
            this.lblDifferentialsSummary.TabIndex = 53;
            this.lblDifferentialsSummary.Text = "label";
            // 
            // lblDifferentialsLabel
            // 
            this.lblDifferentialsLabel.AutoSize = true;
            this.lblDifferentialsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDifferentialsLabel.Location = new System.Drawing.Point(145, 394);
            this.lblDifferentialsLabel.Name = "lblDifferentialsLabel";
            this.lblDifferentialsLabel.Size = new System.Drawing.Size(164, 20);
            this.lblDifferentialsLabel.TabIndex = 52;
            this.lblDifferentialsLabel.Text = "Adds/Drops Summary";
            // 
            // progressBarDifferentials
            // 
            this.progressBarDifferentials.Location = new System.Drawing.Point(9, 394);
            this.progressBarDifferentials.Name = "progressBarDifferentials";
            this.progressBarDifferentials.Size = new System.Drawing.Size(128, 17);
            this.progressBarDifferentials.TabIndex = 51;
            // 
            // pictureBoxParttypeDisagreement
            // 
            this.pictureBoxParttypeDisagreement.BackColor = System.Drawing.Color.Yellow;
            this.pictureBoxParttypeDisagreement.Location = new System.Drawing.Point(9, 219);
            this.pictureBoxParttypeDisagreement.Name = "pictureBoxParttypeDisagreement";
            this.pictureBoxParttypeDisagreement.Size = new System.Drawing.Size(128, 15);
            this.pictureBoxParttypeDisagreement.TabIndex = 47;
            this.pictureBoxParttypeDisagreement.TabStop = false;
            // 
            // progressBarParttypeDisagreement
            // 
            this.progressBarParttypeDisagreement.Location = new System.Drawing.Point(9, 219);
            this.progressBarParttypeDisagreement.Name = "progressBarParttypeDisagreement";
            this.progressBarParttypeDisagreement.Size = new System.Drawing.Size(128, 15);
            this.progressBarParttypeDisagreement.TabIndex = 50;
            // 
            // lblParttypeDisagreement
            // 
            this.lblParttypeDisagreement.AutoSize = true;
            this.lblParttypeDisagreement.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblParttypeDisagreement.Location = new System.Drawing.Point(332, 214);
            this.lblParttypeDisagreement.Name = "lblParttypeDisagreement";
            this.lblParttypeDisagreement.Size = new System.Drawing.Size(42, 20);
            this.lblParttypeDisagreement.TabIndex = 49;
            this.lblParttypeDisagreement.Text = "label";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(145, 214);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(180, 20);
            this.label18.TabIndex = 48;
            this.label18.Text = "Parttype Disagreements";
            // 
            // pictureBoxInvalidConfigurations
            // 
            this.pictureBoxInvalidConfigurations.BackColor = System.Drawing.Color.Red;
            this.pictureBoxInvalidConfigurations.Location = new System.Drawing.Point(9, 371);
            this.pictureBoxInvalidConfigurations.Name = "pictureBoxInvalidConfigurations";
            this.pictureBoxInvalidConfigurations.Size = new System.Drawing.Size(128, 17);
            this.pictureBoxInvalidConfigurations.TabIndex = 45;
            this.pictureBoxInvalidConfigurations.TabStop = false;
            // 
            // pictureBoxParttypePosition
            // 
            this.pictureBoxParttypePosition.BackColor = System.Drawing.Color.Red;
            this.pictureBoxParttypePosition.Location = new System.Drawing.Point(9, 349);
            this.pictureBoxParttypePosition.Name = "pictureBoxParttypePosition";
            this.pictureBoxParttypePosition.Size = new System.Drawing.Size(128, 16);
            this.pictureBoxParttypePosition.TabIndex = 44;
            this.pictureBoxParttypePosition.TabStop = false;
            // 
            // pictureBoxInvalidVCdbCodes
            // 
            this.pictureBoxInvalidVCdbCodes.BackColor = System.Drawing.Color.Red;
            this.pictureBoxInvalidVCdbCodes.Location = new System.Drawing.Point(9, 327);
            this.pictureBoxInvalidVCdbCodes.Name = "pictureBoxInvalidVCdbCodes";
            this.pictureBoxInvalidVCdbCodes.Size = new System.Drawing.Size(128, 16);
            this.pictureBoxInvalidVCdbCodes.TabIndex = 43;
            this.pictureBoxInvalidVCdbCodes.TabStop = false;
            // 
            // pictureBoxInvalidBasevehicles
            // 
            this.pictureBoxInvalidBasevehicles.BackColor = System.Drawing.Color.Red;
            this.pictureBoxInvalidBasevehicles.Location = new System.Drawing.Point(9, 305);
            this.pictureBoxInvalidBasevehicles.Name = "pictureBoxInvalidBasevehicles";
            this.pictureBoxInvalidBasevehicles.Size = new System.Drawing.Size(128, 16);
            this.pictureBoxInvalidBasevehicles.TabIndex = 42;
            this.pictureBoxInvalidBasevehicles.TabStop = false;
            // 
            // pictureBoxOverlaps
            // 
            this.pictureBoxOverlaps.BackColor = System.Drawing.Color.Red;
            this.pictureBoxOverlaps.Location = new System.Drawing.Point(9, 283);
            this.pictureBoxOverlaps.Name = "pictureBoxOverlaps";
            this.pictureBoxOverlaps.Size = new System.Drawing.Size(128, 16);
            this.pictureBoxOverlaps.TabIndex = 41;
            this.pictureBoxOverlaps.TabStop = false;
            // 
            // pictureBoxDuplicates
            // 
            this.pictureBoxDuplicates.BackColor = System.Drawing.Color.Yellow;
            this.pictureBoxDuplicates.Location = new System.Drawing.Point(9, 240);
            this.pictureBoxDuplicates.Name = "pictureBoxDuplicates";
            this.pictureBoxDuplicates.Size = new System.Drawing.Size(128, 15);
            this.pictureBoxDuplicates.TabIndex = 40;
            this.pictureBoxDuplicates.TabStop = false;
            // 
            // pictureBoxCNCoverlaps
            // 
            this.pictureBoxCNCoverlaps.BackColor = System.Drawing.Color.Red;
            this.pictureBoxCNCoverlaps.Location = new System.Drawing.Point(9, 261);
            this.pictureBoxCNCoverlaps.Name = "pictureBoxCNCoverlaps";
            this.pictureBoxCNCoverlaps.Size = new System.Drawing.Size(128, 16);
            this.pictureBoxCNCoverlaps.TabIndex = 39;
            this.pictureBoxCNCoverlaps.TabStop = false;
            // 
            // progressBarInvalidConfigurations
            // 
            this.progressBarInvalidConfigurations.Location = new System.Drawing.Point(9, 371);
            this.progressBarInvalidConfigurations.Name = "progressBarInvalidConfigurations";
            this.progressBarInvalidConfigurations.Size = new System.Drawing.Size(128, 17);
            this.progressBarInvalidConfigurations.TabIndex = 38;
            // 
            // progressBarParttypePosition
            // 
            this.progressBarParttypePosition.Location = new System.Drawing.Point(9, 349);
            this.progressBarParttypePosition.Name = "progressBarParttypePosition";
            this.progressBarParttypePosition.Size = new System.Drawing.Size(128, 16);
            this.progressBarParttypePosition.TabIndex = 37;
            // 
            // progressBarInvalidVCdbCodes
            // 
            this.progressBarInvalidVCdbCodes.Location = new System.Drawing.Point(9, 327);
            this.progressBarInvalidVCdbCodes.Name = "progressBarInvalidVCdbCodes";
            this.progressBarInvalidVCdbCodes.Size = new System.Drawing.Size(128, 16);
            this.progressBarInvalidVCdbCodes.TabIndex = 36;
            // 
            // progressBarInvalidBasevehicles
            // 
            this.progressBarInvalidBasevehicles.Location = new System.Drawing.Point(9, 305);
            this.progressBarInvalidBasevehicles.Name = "progressBarInvalidBasevehicles";
            this.progressBarInvalidBasevehicles.Size = new System.Drawing.Size(128, 16);
            this.progressBarInvalidBasevehicles.TabIndex = 35;
            // 
            // progressBarOverlaps
            // 
            this.progressBarOverlaps.Location = new System.Drawing.Point(9, 283);
            this.progressBarOverlaps.Name = "progressBarOverlaps";
            this.progressBarOverlaps.Size = new System.Drawing.Size(128, 16);
            this.progressBarOverlaps.TabIndex = 34;
            // 
            // progressBarCNCoverlaps
            // 
            this.progressBarCNCoverlaps.Location = new System.Drawing.Point(9, 261);
            this.progressBarCNCoverlaps.Name = "progressBarCNCoverlaps";
            this.progressBarCNCoverlaps.Size = new System.Drawing.Size(128, 16);
            this.progressBarCNCoverlaps.TabIndex = 33;
            // 
            // progressBarDuplicates
            // 
            this.progressBarDuplicates.Location = new System.Drawing.Point(9, 240);
            this.progressBarDuplicates.Name = "progressBarDuplicates";
            this.progressBarDuplicates.Size = new System.Drawing.Size(128, 15);
            this.progressBarDuplicates.TabIndex = 32;
            // 
            // lblInvalidParttypePositionCount
            // 
            this.lblInvalidParttypePositionCount.AutoSize = true;
            this.lblInvalidParttypePositionCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidParttypePositionCount.Location = new System.Drawing.Point(332, 349);
            this.lblInvalidParttypePositionCount.Name = "lblInvalidParttypePositionCount";
            this.lblInvalidParttypePositionCount.Size = new System.Drawing.Size(42, 20);
            this.lblInvalidParttypePositionCount.TabIndex = 31;
            this.lblInvalidParttypePositionCount.Text = "label";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(145, 349);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(179, 20);
            this.label19.TabIndex = 30;
            this.label19.Text = "PartType/Position Errors";
            // 
            // lblInvalidVCdbCodesCount
            // 
            this.lblInvalidVCdbCodesCount.AutoSize = true;
            this.lblInvalidVCdbCodesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidVCdbCodesCount.Location = new System.Drawing.Point(332, 326);
            this.lblInvalidVCdbCodesCount.Name = "lblInvalidVCdbCodesCount";
            this.lblInvalidVCdbCodesCount.Size = new System.Drawing.Size(42, 20);
            this.lblInvalidVCdbCodesCount.TabIndex = 29;
            this.lblInvalidVCdbCodesCount.Text = "label";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(145, 326);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(148, 20);
            this.label17.TabIndex = 28;
            this.label17.Text = "Invalid VCdb Codes";
            // 
            // lblInvalidConfigurationsCount
            // 
            this.lblInvalidConfigurationsCount.AutoSize = true;
            this.lblInvalidConfigurationsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidConfigurationsCount.Location = new System.Drawing.Point(332, 371);
            this.lblInvalidConfigurationsCount.Name = "lblInvalidConfigurationsCount";
            this.lblInvalidConfigurationsCount.Size = new System.Drawing.Size(42, 20);
            this.lblInvalidConfigurationsCount.TabIndex = 27;
            this.lblInvalidConfigurationsCount.Text = "label";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(145, 371);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(161, 20);
            this.label16.TabIndex = 26;
            this.label16.Text = "Invalid Configurations";
            // 
            // lblInvalidBasevehilcesCount
            // 
            this.lblInvalidBasevehilcesCount.AutoSize = true;
            this.lblInvalidBasevehilcesCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInvalidBasevehilcesCount.Location = new System.Drawing.Point(332, 303);
            this.lblInvalidBasevehilcesCount.Name = "lblInvalidBasevehilcesCount";
            this.lblInvalidBasevehilcesCount.Size = new System.Drawing.Size(42, 20);
            this.lblInvalidBasevehilcesCount.TabIndex = 25;
            this.lblInvalidBasevehilcesCount.Text = "label";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(145, 303);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(155, 20);
            this.label15.TabIndex = 24;
            this.label15.Text = "Invalid BaseVehicles";
            // 
            // lblCNCoverlapsCount
            // 
            this.lblCNCoverlapsCount.AutoSize = true;
            this.lblCNCoverlapsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCNCoverlapsCount.Location = new System.Drawing.Point(332, 261);
            this.lblCNCoverlapsCount.Name = "lblCNCoverlapsCount";
            this.lblCNCoverlapsCount.Size = new System.Drawing.Size(42, 20);
            this.lblCNCoverlapsCount.TabIndex = 23;
            this.lblCNCoverlapsCount.Text = "label";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(145, 261);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(108, 20);
            this.label14.TabIndex = 22;
            this.label14.Text = "CNC Overlaps";
            // 
            // lblOverlapsCount
            // 
            this.lblOverlapsCount.AutoSize = true;
            this.lblOverlapsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverlapsCount.Location = new System.Drawing.Point(332, 283);
            this.lblOverlapsCount.Name = "lblOverlapsCount";
            this.lblOverlapsCount.Size = new System.Drawing.Size(42, 20);
            this.lblOverlapsCount.TabIndex = 21;
            this.lblOverlapsCount.Text = "label";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(145, 283);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(71, 20);
            this.label13.TabIndex = 20;
            this.label13.Text = "Overlaps";
            // 
            // lblDuplicateApps
            // 
            this.lblDuplicateApps.AutoSize = true;
            this.lblDuplicateApps.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDuplicateApps.Location = new System.Drawing.Point(332, 237);
            this.lblDuplicateApps.Name = "lblDuplicateApps";
            this.lblDuplicateApps.Size = new System.Drawing.Size(42, 20);
            this.lblDuplicateApps.TabIndex = 19;
            this.lblDuplicateApps.Text = "label";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(145, 237);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(117, 20);
            this.label12.TabIndex = 18;
            this.label12.Text = "Duplicate Apps";
            // 
            // lblStatsErrorsCount
            // 
            this.lblStatsErrorsCount.AutoSize = true;
            this.lblStatsErrorsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsErrorsCount.Location = new System.Drawing.Point(145, 200);
            this.lblStatsErrorsCount.Name = "lblStatsErrorsCount";
            this.lblStatsErrorsCount.Size = new System.Drawing.Size(42, 20);
            this.lblStatsErrorsCount.TabIndex = 17;
            this.lblStatsErrorsCount.Text = "label";
            this.lblStatsErrorsCount.Visible = false;
            // 
            // lblStatsWarningsCount
            // 
            this.lblStatsWarningsCount.AutoSize = true;
            this.lblStatsWarningsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsWarningsCount.Location = new System.Drawing.Point(145, 177);
            this.lblStatsWarningsCount.Name = "lblStatsWarningsCount";
            this.lblStatsWarningsCount.Size = new System.Drawing.Size(42, 20);
            this.lblStatsWarningsCount.TabIndex = 16;
            this.lblStatsWarningsCount.Text = "label";
            this.lblStatsWarningsCount.Visible = false;
            // 
            // lblStatsPartsCount
            // 
            this.lblStatsPartsCount.AutoSize = true;
            this.lblStatsPartsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsPartsCount.Location = new System.Drawing.Point(145, 155);
            this.lblStatsPartsCount.Name = "lblStatsPartsCount";
            this.lblStatsPartsCount.Size = new System.Drawing.Size(42, 20);
            this.lblStatsPartsCount.TabIndex = 15;
            this.lblStatsPartsCount.Text = "label";
            // 
            // lblStatsAppsCount
            // 
            this.lblStatsAppsCount.AutoSize = true;
            this.lblStatsAppsCount.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsAppsCount.Location = new System.Drawing.Point(145, 133);
            this.lblStatsAppsCount.Name = "lblStatsAppsCount";
            this.lblStatsAppsCount.Size = new System.Drawing.Size(42, 20);
            this.lblStatsAppsCount.TabIndex = 14;
            this.lblStatsAppsCount.Text = "label";
            // 
            // lblStatsQdbVersion
            // 
            this.lblStatsQdbVersion.AutoSize = true;
            this.lblStatsQdbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsQdbVersion.Location = new System.Drawing.Point(145, 111);
            this.lblStatsQdbVersion.Name = "lblStatsQdbVersion";
            this.lblStatsQdbVersion.Size = new System.Drawing.Size(42, 20);
            this.lblStatsQdbVersion.TabIndex = 13;
            this.lblStatsQdbVersion.Text = "label";
            // 
            // lblStatsPCdbVersion
            // 
            this.lblStatsPCdbVersion.AutoSize = true;
            this.lblStatsPCdbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsPCdbVersion.Location = new System.Drawing.Point(145, 89);
            this.lblStatsPCdbVersion.Name = "lblStatsPCdbVersion";
            this.lblStatsPCdbVersion.Size = new System.Drawing.Size(42, 20);
            this.lblStatsPCdbVersion.TabIndex = 12;
            this.lblStatsPCdbVersion.Text = "label";
            // 
            // lblStatsVCdbVersion
            // 
            this.lblStatsVCdbVersion.AutoSize = true;
            this.lblStatsVCdbVersion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsVCdbVersion.Location = new System.Drawing.Point(145, 67);
            this.lblStatsVCdbVersion.Name = "lblStatsVCdbVersion";
            this.lblStatsVCdbVersion.Size = new System.Drawing.Size(42, 20);
            this.lblStatsVCdbVersion.TabIndex = 11;
            this.lblStatsVCdbVersion.Text = "label";
            // 
            // lblStatsACESversion
            // 
            this.lblStatsACESversion.AutoSize = true;
            this.lblStatsACESversion.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsACESversion.Location = new System.Drawing.Point(145, 43);
            this.lblStatsACESversion.Name = "lblStatsACESversion";
            this.lblStatsACESversion.Size = new System.Drawing.Size(42, 20);
            this.lblStatsACESversion.TabIndex = 10;
            this.lblStatsACESversion.Text = "label";
            // 
            // lblStatsTitle
            // 
            this.lblStatsTitle.AutoSize = true;
            this.lblStatsTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatsTitle.Location = new System.Drawing.Point(145, 21);
            this.lblStatsTitle.Name = "lblStatsTitle";
            this.lblStatsTitle.Size = new System.Drawing.Size(42, 20);
            this.lblStatsTitle.TabIndex = 9;
            this.lblStatsTitle.Text = "label";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(5, 200);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(91, 20);
            this.label10.TabIndex = 8;
            this.label10.Text = "Total Errors";
            this.label10.Visible = false;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(5, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(115, 20);
            this.label9.TabIndex = 7;
            this.label9.Text = "Total Warnings";
            this.label9.Visible = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(5, 155);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(85, 20);
            this.label8.TabIndex = 6;
            this.label8.Text = "Part Count";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(5, 133);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(134, 20);
            this.label7.TabIndex = 5;
            this.label7.Text = "Application Count";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(5, 111);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "Qdb Version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(5, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(106, 20);
            this.label5.TabIndex = 3;
            this.label5.Text = "PCdb Version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(5, 67);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 20);
            this.label4.TabIndex = 2;
            this.label4.Text = "VCdb Version";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(5, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 20);
            this.label3.TabIndex = 1;
            this.label3.Text = "ACES Version";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(5, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "Title";
            // 
            // tabPageExports
            // 
            this.tabPageExports.Controls.Add(this.groupBox2);
            this.tabPageExports.Controls.Add(this.groupBox1);
            this.tabPageExports.Controls.Add(this.groupBoxDataExport);
            this.tabPageExports.Controls.Add(this.groupBoxAssessment);
            this.tabPageExports.Location = new System.Drawing.Point(4, 22);
            this.tabPageExports.Name = "tabPageExports";
            this.tabPageExports.Size = new System.Drawing.Size(837, 423);
            this.tabPageExports.TabIndex = 5;
            this.tabPageExports.Text = "Exports";
            this.tabPageExports.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnNetChangeExportSave);
            this.groupBox2.Controls.Add(this.lblNetChangeExportFilePath);
            this.groupBox2.Controls.Add(this.btnSelectNetChangeFile);
            this.groupBox2.Location = new System.Drawing.Point(16, 277);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(479, 77);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Net-Changes Export";
            // 
            // btnNetChangeExportSave
            // 
            this.btnNetChangeExportSave.Location = new System.Drawing.Point(5, 48);
            this.btnNetChangeExportSave.Name = "btnNetChangeExportSave";
            this.btnNetChangeExportSave.Size = new System.Drawing.Size(89, 23);
            this.btnNetChangeExportSave.TabIndex = 2;
            this.btnNetChangeExportSave.Text = "Export";
            this.btnNetChangeExportSave.UseVisualStyleBackColor = true;
            this.btnNetChangeExportSave.Click += new System.EventHandler(this.btnNetChangeExportSave_Click);
            // 
            // lblNetChangeExportFilePath
            // 
            this.lblNetChangeExportFilePath.AutoSize = true;
            this.lblNetChangeExportFilePath.Location = new System.Drawing.Point(119, 24);
            this.lblNetChangeExportFilePath.Name = "lblNetChangeExportFilePath";
            this.lblNetChangeExportFilePath.Size = new System.Drawing.Size(29, 13);
            this.lblNetChangeExportFilePath.TabIndex = 1;
            this.lblNetChangeExportFilePath.Text = "label";
            // 
            // btnSelectNetChangeFile
            // 
            this.btnSelectNetChangeFile.Location = new System.Drawing.Point(5, 19);
            this.btnSelectNetChangeFile.Name = "btnSelectNetChangeFile";
            this.btnSelectNetChangeFile.Size = new System.Drawing.Size(108, 23);
            this.btnSelectNetChangeFile.TabIndex = 0;
            this.btnSelectNetChangeFile.Text = "Select Ouptut Path";
            this.btnSelectNetChangeFile.UseVisualStyleBackColor = true;
            this.btnSelectNetChangeFile.Click += new System.EventHandler(this.btnSelectNetChangeFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectBgExportFile);
            this.groupBox1.Controls.Add(this.btnBgExportSave);
            this.groupBox1.Controls.Add(this.lblBgExportFilePath);
            this.groupBox1.Location = new System.Drawing.Point(16, 193);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(479, 78);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Buyer\'s Guide Export";
            // 
            // btnSelectBgExportFile
            // 
            this.btnSelectBgExportFile.Location = new System.Drawing.Point(6, 19);
            this.btnSelectBgExportFile.Name = "btnSelectBgExportFile";
            this.btnSelectBgExportFile.Size = new System.Drawing.Size(107, 23);
            this.btnSelectBgExportFile.TabIndex = 2;
            this.btnSelectBgExportFile.Text = "Select Output Path";
            this.btnSelectBgExportFile.UseVisualStyleBackColor = true;
            this.btnSelectBgExportFile.Click += new System.EventHandler(this.btnSelectBgExportFile_Click);
            // 
            // btnBgExportSave
            // 
            this.btnBgExportSave.Location = new System.Drawing.Point(6, 48);
            this.btnBgExportSave.Name = "btnBgExportSave";
            this.btnBgExportSave.Size = new System.Drawing.Size(75, 23);
            this.btnBgExportSave.TabIndex = 1;
            this.btnBgExportSave.Text = "Export";
            this.btnBgExportSave.UseVisualStyleBackColor = true;
            this.btnBgExportSave.Click += new System.EventHandler(this.btnBGExportSave_Click);
            // 
            // lblBgExportFilePath
            // 
            this.lblBgExportFilePath.AutoSize = true;
            this.lblBgExportFilePath.Location = new System.Drawing.Point(119, 24);
            this.lblBgExportFilePath.Name = "lblBgExportFilePath";
            this.lblBgExportFilePath.Size = new System.Drawing.Size(29, 13);
            this.lblBgExportFilePath.TabIndex = 0;
            this.lblBgExportFilePath.Text = "label";
            // 
            // groupBoxDataExport
            // 
            this.groupBoxDataExport.Controls.Add(this.lblAppExportFilePath);
            this.groupBoxDataExport.Controls.Add(this.label11);
            this.groupBoxDataExport.Controls.Add(this.comboBox1);
            this.groupBoxDataExport.Controls.Add(this.btnSelectAppExportFile);
            this.groupBoxDataExport.Controls.Add(this.checkBox2);
            this.groupBoxDataExport.Controls.Add(this.label1);
            this.groupBoxDataExport.Controls.Add(this.comboBoxExportDelimiter);
            this.groupBoxDataExport.Controls.Add(this.checkBox1);
            this.groupBoxDataExport.Controls.Add(this.btnAppExportSave);
            this.groupBoxDataExport.Location = new System.Drawing.Point(16, 98);
            this.groupBoxDataExport.Name = "groupBoxDataExport";
            this.groupBoxDataExport.Size = new System.Drawing.Size(479, 77);
            this.groupBoxDataExport.TabIndex = 1;
            this.groupBoxDataExport.TabStop = false;
            this.groupBoxDataExport.Text = "Flattened Application Data Export";
            // 
            // lblAppExportFilePath
            // 
            this.lblAppExportFilePath.AutoSize = true;
            this.lblAppExportFilePath.Location = new System.Drawing.Point(119, 24);
            this.lblAppExportFilePath.Name = "lblAppExportFilePath";
            this.lblAppExportFilePath.Size = new System.Drawing.Size(29, 13);
            this.lblAppExportFilePath.TabIndex = 8;
            this.lblAppExportFilePath.Text = "label";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(5, 71);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(30, 13);
            this.label11.TabIndex = 7;
            this.label11.Text = "Style";
            this.label11.Visible = false;
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(41, 68);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(119, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.Visible = false;
            // 
            // btnSelectAppExportFile
            // 
            this.btnSelectAppExportFile.Location = new System.Drawing.Point(6, 19);
            this.btnSelectAppExportFile.Name = "btnSelectAppExportFile";
            this.btnSelectAppExportFile.Size = new System.Drawing.Size(107, 23);
            this.btnSelectAppExportFile.TabIndex = 5;
            this.btnSelectAppExportFile.Text = "Select Output Path";
            this.btnSelectAppExportFile.UseVisualStyleBackColor = true;
            this.btnSelectAppExportFile.Click += new System.EventHandler(this.btnSelectAppExportFile_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(188, 95);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(177, 17);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Translate PCdb codes to names";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.Visible = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(174, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Delimiter";
            this.label1.Visible = false;
            // 
            // comboBoxExportDelimiter
            // 
            this.comboBoxExportDelimiter.FormattingEnabled = true;
            this.comboBoxExportDelimiter.Items.AddRange(new object[] {
            "Tab",
            "Pipe (|)",
            "Tilde (~)"});
            this.comboBoxExportDelimiter.Location = new System.Drawing.Point(227, 68);
            this.comboBoxExportDelimiter.Name = "comboBoxExportDelimiter";
            this.comboBoxExportDelimiter.Size = new System.Drawing.Size(67, 21);
            this.comboBoxExportDelimiter.TabIndex = 2;
            this.comboBoxExportDelimiter.Visible = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(5, 95);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(177, 17);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "Translate VCdb codes to names";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.Visible = false;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnAppExportSave
            // 
            this.btnAppExportSave.Location = new System.Drawing.Point(6, 48);
            this.btnAppExportSave.Name = "btnAppExportSave";
            this.btnAppExportSave.Size = new System.Drawing.Size(75, 23);
            this.btnAppExportSave.TabIndex = 0;
            this.btnAppExportSave.Text = "Export";
            this.btnAppExportSave.UseVisualStyleBackColor = true;
            this.btnAppExportSave.Click += new System.EventHandler(this.btnAppExportSave_Click);
            // 
            // groupBoxAssessment
            // 
            this.groupBoxAssessment.Controls.Add(this.lblAssessmentFilePath);
            this.groupBoxAssessment.Controls.Add(this.btnAssessmentSave);
            this.groupBoxAssessment.Controls.Add(this.btnSelectAssessmentFile);
            this.groupBoxAssessment.Location = new System.Drawing.Point(16, 19);
            this.groupBoxAssessment.Name = "groupBoxAssessment";
            this.groupBoxAssessment.Size = new System.Drawing.Size(479, 73);
            this.groupBoxAssessment.TabIndex = 0;
            this.groupBoxAssessment.TabStop = false;
            this.groupBoxAssessment.Text = "Assessment Spreadsheet Export";
            // 
            // lblAssessmentFilePath
            // 
            this.lblAssessmentFilePath.AutoSize = true;
            this.lblAssessmentFilePath.Location = new System.Drawing.Point(119, 23);
            this.lblAssessmentFilePath.Name = "lblAssessmentFilePath";
            this.lblAssessmentFilePath.Size = new System.Drawing.Size(29, 13);
            this.lblAssessmentFilePath.TabIndex = 2;
            this.lblAssessmentFilePath.Text = "label";
            // 
            // btnAssessmentSave
            // 
            this.btnAssessmentSave.Location = new System.Drawing.Point(6, 46);
            this.btnAssessmentSave.Name = "btnAssessmentSave";
            this.btnAssessmentSave.Size = new System.Drawing.Size(75, 21);
            this.btnAssessmentSave.TabIndex = 1;
            this.btnAssessmentSave.Text = "Export";
            this.btnAssessmentSave.UseVisualStyleBackColor = true;
            this.btnAssessmentSave.Click += new System.EventHandler(this.btnAssessmentSave_Click);
            // 
            // btnSelectAssessmentFile
            // 
            this.btnSelectAssessmentFile.Location = new System.Drawing.Point(6, 19);
            this.btnSelectAssessmentFile.Name = "btnSelectAssessmentFile";
            this.btnSelectAssessmentFile.Size = new System.Drawing.Size(107, 21);
            this.btnSelectAssessmentFile.TabIndex = 0;
            this.btnSelectAssessmentFile.Text = "Select Ouptut Path";
            this.btnSelectAssessmentFile.UseVisualStyleBackColor = true;
            this.btnSelectAssessmentFile.Click += new System.EventHandler(this.btnSelectAssessmentFile_Click);
            // 
            // tabPageParts
            // 
            this.tabPageParts.Controls.Add(this.dgParts);
            this.tabPageParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageParts.Name = "tabPageParts";
            this.tabPageParts.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageParts.Size = new System.Drawing.Size(837, 423);
            this.tabPageParts.TabIndex = 1;
            this.tabPageParts.Text = "Parts";
            this.tabPageParts.UseVisualStyleBackColor = true;
            // 
            // tabPagePartsMultiTypes
            // 
            this.tabPagePartsMultiTypes.Controls.Add(this.dgParttypeDisagreement);
            this.tabPagePartsMultiTypes.Location = new System.Drawing.Point(4, 22);
            this.tabPagePartsMultiTypes.Name = "tabPagePartsMultiTypes";
            this.tabPagePartsMultiTypes.Size = new System.Drawing.Size(837, 423);
            this.tabPagePartsMultiTypes.TabIndex = 11;
            this.tabPagePartsMultiTypes.Text = "Parttype Disagreement";
            this.tabPagePartsMultiTypes.UseVisualStyleBackColor = true;
            // 
            // dgParttypeDisagreement
            // 
            this.dgParttypeDisagreement.AllowUserToAddRows = false;
            this.dgParttypeDisagreement.AllowUserToDeleteRows = false;
            this.dgParttypeDisagreement.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParttypeDisagreement.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgParttypeDisagreementPart,
            this.dgParttypeDisagreementParttypes});
            this.dgParttypeDisagreement.Location = new System.Drawing.Point(3, 3);
            this.dgParttypeDisagreement.Name = "dgParttypeDisagreement";
            this.dgParttypeDisagreement.Size = new System.Drawing.Size(838, 424);
            this.dgParttypeDisagreement.TabIndex = 1;
            // 
            // dgParttypeDisagreementPart
            // 
            this.dgParttypeDisagreementPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgParttypeDisagreementPart.HeaderText = "Part";
            this.dgParttypeDisagreementPart.Name = "dgParttypeDisagreementPart";
            this.dgParttypeDisagreementPart.ReadOnly = true;
            this.dgParttypeDisagreementPart.Width = 51;
            // 
            // dgParttypeDisagreementParttypes
            // 
            this.dgParttypeDisagreementParttypes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgParttypeDisagreementParttypes.HeaderText = "Part Types";
            this.dgParttypeDisagreementParttypes.Name = "dgParttypeDisagreementParttypes";
            this.dgParttypeDisagreementParttypes.ReadOnly = true;
            this.dgParttypeDisagreementParttypes.Width = 83;
            // 
            // tabPageDuplicates
            // 
            this.tabPageDuplicates.Controls.Add(this.dgDuplicates);
            this.tabPageDuplicates.Location = new System.Drawing.Point(4, 22);
            this.tabPageDuplicates.Name = "tabPageDuplicates";
            this.tabPageDuplicates.Size = new System.Drawing.Size(837, 423);
            this.tabPageDuplicates.TabIndex = 2;
            this.tabPageDuplicates.Text = "Duplicates";
            this.tabPageDuplicates.UseVisualStyleBackColor = true;
            // 
            // dgDuplicates
            // 
            this.dgDuplicates.AllowUserToAddRows = false;
            this.dgDuplicates.AllowUserToDeleteRows = false;
            this.dgDuplicates.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDuplicates.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgDuplicatesBaseVehicleid,
            this.dgDuplicatesMake,
            this.dgDuplicatesModel,
            this.dgDuplicatesYear,
            this.dgDuplicatesParttype,
            this.dgDuplicatesPosition,
            this.dgDuplicatesAttributes,
            this.dgDuplicatesAppIds});
            this.dgDuplicates.Location = new System.Drawing.Point(3, 3);
            this.dgDuplicates.Name = "dgDuplicates";
            this.dgDuplicates.Size = new System.Drawing.Size(838, 420);
            this.dgDuplicates.TabIndex = 1;
            this.dgDuplicates.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgDuplicates_SortCompare);
            // 
            // dgDuplicatesBaseVehicleid
            // 
            this.dgDuplicatesBaseVehicleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesBaseVehicleid.HeaderText = "BaseVehicle id";
            this.dgDuplicatesBaseVehicleid.Name = "dgDuplicatesBaseVehicleid";
            this.dgDuplicatesBaseVehicleid.ReadOnly = true;
            this.dgDuplicatesBaseVehicleid.Width = 102;
            // 
            // dgDuplicatesMake
            // 
            this.dgDuplicatesMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesMake.HeaderText = "Make";
            this.dgDuplicatesMake.Name = "dgDuplicatesMake";
            this.dgDuplicatesMake.ReadOnly = true;
            this.dgDuplicatesMake.Width = 59;
            // 
            // dgDuplicatesModel
            // 
            this.dgDuplicatesModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesModel.HeaderText = "Model";
            this.dgDuplicatesModel.Name = "dgDuplicatesModel";
            this.dgDuplicatesModel.ReadOnly = true;
            this.dgDuplicatesModel.Width = 61;
            // 
            // dgDuplicatesYear
            // 
            this.dgDuplicatesYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesYear.HeaderText = "Year";
            this.dgDuplicatesYear.Name = "dgDuplicatesYear";
            this.dgDuplicatesYear.ReadOnly = true;
            this.dgDuplicatesYear.Width = 54;
            // 
            // dgDuplicatesParttype
            // 
            this.dgDuplicatesParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesParttype.HeaderText = "Part Type";
            this.dgDuplicatesParttype.Name = "dgDuplicatesParttype";
            this.dgDuplicatesParttype.ReadOnly = true;
            this.dgDuplicatesParttype.Width = 78;
            // 
            // dgDuplicatesPosition
            // 
            this.dgDuplicatesPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesPosition.HeaderText = "Position";
            this.dgDuplicatesPosition.Name = "dgDuplicatesPosition";
            this.dgDuplicatesPosition.ReadOnly = true;
            this.dgDuplicatesPosition.Width = 69;
            // 
            // dgDuplicatesAttributes
            // 
            this.dgDuplicatesAttributes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesAttributes.HeaderText = "Qualifiers";
            this.dgDuplicatesAttributes.Name = "dgDuplicatesAttributes";
            this.dgDuplicatesAttributes.ReadOnly = true;
            this.dgDuplicatesAttributes.Width = 75;
            // 
            // dgDuplicatesAppIds
            // 
            this.dgDuplicatesAppIds.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgDuplicatesAppIds.HeaderText = "App ids";
            this.dgDuplicatesAppIds.Name = "dgDuplicatesAppIds";
            this.dgDuplicatesAppIds.ReadOnly = true;
            this.dgDuplicatesAppIds.Width = 67;
            // 
            // tabPageCNCoverlaps
            // 
            this.tabPageCNCoverlaps.Controls.Add(this.dgCNCoverlaps);
            this.tabPageCNCoverlaps.Location = new System.Drawing.Point(4, 22);
            this.tabPageCNCoverlaps.Name = "tabPageCNCoverlaps";
            this.tabPageCNCoverlaps.Size = new System.Drawing.Size(837, 423);
            this.tabPageCNCoverlaps.TabIndex = 4;
            this.tabPageCNCoverlaps.Text = "CNC Overlaps";
            this.tabPageCNCoverlaps.UseVisualStyleBackColor = true;
            // 
            // dgCNCoverlaps
            // 
            this.dgCNCoverlaps.AllowUserToAddRows = false;
            this.dgCNCoverlaps.AllowUserToDeleteRows = false;
            this.dgCNCoverlaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgCNCoverlaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dbCNCgroupnumber,
            this.dgCNCapplicationid,
            this.dgCNCbasevehicleid,
            this.dgCNCmake,
            this.dgCNCmodel,
            this.dgCNCyear,
            this.dgCNCparttype,
            this.dgCNCposition,
            this.dgCNCqty,
            this.dgCNCPart,
            this.dgCNCqualifiers});
            this.dgCNCoverlaps.Location = new System.Drawing.Point(3, 3);
            this.dgCNCoverlaps.Name = "dgCNCoverlaps";
            this.dgCNCoverlaps.Size = new System.Drawing.Size(838, 424);
            this.dgCNCoverlaps.TabIndex = 3;
            this.dgCNCoverlaps.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgCNCoverlaps_SortCompare);
            // 
            // dbCNCgroupnumber
            // 
            this.dbCNCgroupnumber.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dbCNCgroupnumber.HeaderText = "CNC Group";
            this.dbCNCgroupnumber.Name = "dbCNCgroupnumber";
            this.dbCNCgroupnumber.ReadOnly = true;
            this.dbCNCgroupnumber.Width = 79;
            // 
            // dgCNCapplicationid
            // 
            this.dgCNCapplicationid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCapplicationid.HeaderText = "App id";
            this.dgCNCapplicationid.Name = "dgCNCapplicationid";
            this.dgCNCapplicationid.ReadOnly = true;
            this.dgCNCapplicationid.Width = 51;
            // 
            // dgCNCbasevehicleid
            // 
            this.dgCNCbasevehicleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCbasevehicleid.HeaderText = "Base Vehicle id";
            this.dgCNCbasevehicleid.Name = "dgCNCbasevehicleid";
            this.dgCNCbasevehicleid.ReadOnly = true;
            this.dgCNCbasevehicleid.Width = 87;
            // 
            // dgCNCmake
            // 
            this.dgCNCmake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCmake.HeaderText = "Make";
            this.dgCNCmake.Name = "dgCNCmake";
            this.dgCNCmake.ReadOnly = true;
            this.dgCNCmake.Width = 59;
            // 
            // dgCNCmodel
            // 
            this.dgCNCmodel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCmodel.HeaderText = "Model";
            this.dgCNCmodel.Name = "dgCNCmodel";
            this.dgCNCmodel.ReadOnly = true;
            this.dgCNCmodel.Width = 61;
            // 
            // dgCNCyear
            // 
            this.dgCNCyear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCyear.HeaderText = "Year";
            this.dgCNCyear.Name = "dgCNCyear";
            this.dgCNCyear.ReadOnly = true;
            this.dgCNCyear.Width = 54;
            // 
            // dgCNCparttype
            // 
            this.dgCNCparttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCparttype.HeaderText = "Part Type";
            this.dgCNCparttype.Name = "dgCNCparttype";
            this.dgCNCparttype.ReadOnly = true;
            this.dgCNCparttype.Width = 72;
            // 
            // dgCNCposition
            // 
            this.dgCNCposition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCposition.HeaderText = "Position";
            this.dgCNCposition.Name = "dgCNCposition";
            this.dgCNCposition.ReadOnly = true;
            this.dgCNCposition.Width = 69;
            // 
            // dgCNCqty
            // 
            this.dgCNCqty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCqty.HeaderText = "Qty";
            this.dgCNCqty.Name = "dgCNCqty";
            this.dgCNCqty.ReadOnly = true;
            this.dgCNCqty.Width = 48;
            // 
            // dgCNCPart
            // 
            this.dgCNCPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCPart.HeaderText = "Part";
            this.dgCNCPart.Name = "dgCNCPart";
            this.dgCNCPart.ReadOnly = true;
            this.dgCNCPart.Width = 51;
            // 
            // dgCNCqualifiers
            // 
            this.dgCNCqualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgCNCqualifiers.HeaderText = "Qualifiers";
            this.dgCNCqualifiers.Name = "dgCNCqualifiers";
            this.dgCNCqualifiers.ReadOnly = true;
            this.dgCNCqualifiers.Width = 75;
            // 
            // tabPageOverlaps
            // 
            this.tabPageOverlaps.Controls.Add(this.dgOverlaps);
            this.tabPageOverlaps.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverlaps.Name = "tabPageOverlaps";
            this.tabPageOverlaps.Size = new System.Drawing.Size(837, 423);
            this.tabPageOverlaps.TabIndex = 3;
            this.tabPageOverlaps.Text = "Overlaps";
            this.tabPageOverlaps.UseVisualStyleBackColor = true;
            // 
            // dgOverlaps
            // 
            this.dgOverlaps.AllowUserToAddRows = false;
            this.dgOverlaps.AllowUserToDeleteRows = false;
            this.dgOverlaps.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgOverlaps.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgOverlapsBaseVehicleid,
            this.dgOverlapsMake,
            this.dgOverlapsModel,
            this.dgOverlapsYear,
            this.dgOverlapsParttype,
            this.dgOverlapsPosition,
            this.dgOverlapsAttributes,
            this.dgOverlapsParts});
            this.dgOverlaps.Location = new System.Drawing.Point(3, 3);
            this.dgOverlaps.Name = "dgOverlaps";
            this.dgOverlaps.Size = new System.Drawing.Size(838, 424);
            this.dgOverlaps.TabIndex = 2;
            this.dgOverlaps.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgOverlaps_SortCompare);
            // 
            // dgOverlapsBaseVehicleid
            // 
            this.dgOverlapsBaseVehicleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsBaseVehicleid.HeaderText = "BaseVehicle id";
            this.dgOverlapsBaseVehicleid.Name = "dgOverlapsBaseVehicleid";
            this.dgOverlapsBaseVehicleid.ReadOnly = true;
            this.dgOverlapsBaseVehicleid.Width = 102;
            // 
            // dgOverlapsMake
            // 
            this.dgOverlapsMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsMake.HeaderText = "Make";
            this.dgOverlapsMake.Name = "dgOverlapsMake";
            this.dgOverlapsMake.ReadOnly = true;
            this.dgOverlapsMake.Width = 59;
            // 
            // dgOverlapsModel
            // 
            this.dgOverlapsModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsModel.HeaderText = "Model";
            this.dgOverlapsModel.Name = "dgOverlapsModel";
            this.dgOverlapsModel.ReadOnly = true;
            this.dgOverlapsModel.Width = 61;
            // 
            // dgOverlapsYear
            // 
            this.dgOverlapsYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsYear.HeaderText = "Year";
            this.dgOverlapsYear.Name = "dgOverlapsYear";
            this.dgOverlapsYear.ReadOnly = true;
            this.dgOverlapsYear.Width = 54;
            // 
            // dgOverlapsParttype
            // 
            this.dgOverlapsParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsParttype.HeaderText = "Part Type";
            this.dgOverlapsParttype.Name = "dgOverlapsParttype";
            this.dgOverlapsParttype.ReadOnly = true;
            this.dgOverlapsParttype.Width = 78;
            // 
            // dgOverlapsPosition
            // 
            this.dgOverlapsPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsPosition.HeaderText = "Position";
            this.dgOverlapsPosition.Name = "dgOverlapsPosition";
            this.dgOverlapsPosition.ReadOnly = true;
            this.dgOverlapsPosition.Width = 69;
            // 
            // dgOverlapsAttributes
            // 
            this.dgOverlapsAttributes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsAttributes.HeaderText = "Qualifiers";
            this.dgOverlapsAttributes.Name = "dgOverlapsAttributes";
            this.dgOverlapsAttributes.ReadOnly = true;
            this.dgOverlapsAttributes.Width = 75;
            // 
            // dgOverlapsParts
            // 
            this.dgOverlapsParts.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgOverlapsParts.HeaderText = "Parts";
            this.dgOverlapsParts.Name = "dgOverlapsParts";
            this.dgOverlapsParts.ReadOnly = true;
            this.dgOverlapsParts.Width = 56;
            // 
            // tabPageInvalidBasevids
            // 
            this.tabPageInvalidBasevids.Controls.Add(this.dgBasevids);
            this.tabPageInvalidBasevids.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvalidBasevids.Name = "tabPageInvalidBasevids";
            this.tabPageInvalidBasevids.Size = new System.Drawing.Size(837, 423);
            this.tabPageInvalidBasevids.TabIndex = 6;
            this.tabPageInvalidBasevids.Text = "Invalid Basevehicles";
            this.tabPageInvalidBasevids.UseVisualStyleBackColor = true;
            // 
            // dgBasevids
            // 
            this.dgBasevids.AllowUserToAddRows = false;
            this.dgBasevids.AllowUserToDeleteRows = false;
            this.dgBasevids.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgBasevids.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgBasevidsApplicationid,
            this.dgBasevidsBasevid,
            this.dgBasevidsParttype,
            this.dgBasevidsPosition,
            this.dgBasevidsQty,
            this.dgBasevidsPart,
            this.dgBasevidsQualifiers});
            this.dgBasevids.Location = new System.Drawing.Point(3, 3);
            this.dgBasevids.Name = "dgBasevids";
            this.dgBasevids.Size = new System.Drawing.Size(838, 424);
            this.dgBasevids.TabIndex = 2;
            // 
            // dgBasevidsApplicationid
            // 
            this.dgBasevidsApplicationid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsApplicationid.HeaderText = "App id";
            this.dgBasevidsApplicationid.Name = "dgBasevidsApplicationid";
            this.dgBasevidsApplicationid.ReadOnly = true;
            this.dgBasevidsApplicationid.Width = 51;
            // 
            // dgBasevidsBasevid
            // 
            this.dgBasevidsBasevid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsBasevid.HeaderText = "Base Vehicle id";
            this.dgBasevidsBasevid.Name = "dgBasevidsBasevid";
            this.dgBasevidsBasevid.ReadOnly = true;
            this.dgBasevidsBasevid.Width = 87;
            // 
            // dgBasevidsParttype
            // 
            this.dgBasevidsParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsParttype.HeaderText = "Part Type";
            this.dgBasevidsParttype.Name = "dgBasevidsParttype";
            this.dgBasevidsParttype.ReadOnly = true;
            this.dgBasevidsParttype.Width = 72;
            // 
            // dgBasevidsPosition
            // 
            this.dgBasevidsPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsPosition.HeaderText = "Position";
            this.dgBasevidsPosition.Name = "dgBasevidsPosition";
            this.dgBasevidsPosition.ReadOnly = true;
            this.dgBasevidsPosition.Width = 69;
            // 
            // dgBasevidsQty
            // 
            this.dgBasevidsQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsQty.HeaderText = "Qty";
            this.dgBasevidsQty.Name = "dgBasevidsQty";
            this.dgBasevidsQty.ReadOnly = true;
            this.dgBasevidsQty.Width = 48;
            // 
            // dgBasevidsPart
            // 
            this.dgBasevidsPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsPart.HeaderText = "Part";
            this.dgBasevidsPart.Name = "dgBasevidsPart";
            this.dgBasevidsPart.ReadOnly = true;
            this.dgBasevidsPart.Width = 51;
            // 
            // dgBasevidsQualifiers
            // 
            this.dgBasevidsQualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgBasevidsQualifiers.HeaderText = "Qualifiers";
            this.dgBasevidsQualifiers.Name = "dgBasevidsQualifiers";
            this.dgBasevidsQualifiers.ReadOnly = true;
            this.dgBasevidsQualifiers.Width = 75;
            // 
            // tabPageInvalidVCdbCodes
            // 
            this.tabPageInvalidVCdbCodes.Controls.Add(this.dgVCdbCodes);
            this.tabPageInvalidVCdbCodes.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvalidVCdbCodes.Name = "tabPageInvalidVCdbCodes";
            this.tabPageInvalidVCdbCodes.Size = new System.Drawing.Size(837, 423);
            this.tabPageInvalidVCdbCodes.TabIndex = 7;
            this.tabPageInvalidVCdbCodes.Text = "Invalid VCdb codes";
            this.tabPageInvalidVCdbCodes.UseVisualStyleBackColor = true;
            // 
            // dgVCdbCodes
            // 
            this.dgVCdbCodes.AllowUserToAddRows = false;
            this.dgVCdbCodes.AllowUserToDeleteRows = false;
            this.dgVCdbCodes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVCdbCodes.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgVCdbCodesApplicationid,
            this.dgVCdbCodesMake,
            this.dgVCdbCodesModel,
            this.dgVCdbCodesYear,
            this.dgVCdbCodesParttype,
            this.dgVCdbCodesPosition,
            this.dgVCdbCodesQty,
            this.dgVCdbCodesPart,
            this.dgVCdbCodesQualifiers,
            this.dgVCdbCodesNotes});
            this.dgVCdbCodes.Location = new System.Drawing.Point(3, 3);
            this.dgVCdbCodes.Name = "dgVCdbCodes";
            this.dgVCdbCodes.Size = new System.Drawing.Size(838, 425);
            this.dgVCdbCodes.TabIndex = 2;
            // 
            // dgVCdbCodesApplicationid
            // 
            this.dgVCdbCodesApplicationid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesApplicationid.HeaderText = "App id";
            this.dgVCdbCodesApplicationid.Name = "dgVCdbCodesApplicationid";
            this.dgVCdbCodesApplicationid.ReadOnly = true;
            this.dgVCdbCodesApplicationid.Width = 51;
            // 
            // dgVCdbCodesMake
            // 
            this.dgVCdbCodesMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesMake.HeaderText = "Make";
            this.dgVCdbCodesMake.Name = "dgVCdbCodesMake";
            this.dgVCdbCodesMake.ReadOnly = true;
            this.dgVCdbCodesMake.Width = 59;
            // 
            // dgVCdbCodesModel
            // 
            this.dgVCdbCodesModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesModel.HeaderText = "Model";
            this.dgVCdbCodesModel.Name = "dgVCdbCodesModel";
            this.dgVCdbCodesModel.ReadOnly = true;
            this.dgVCdbCodesModel.Width = 61;
            // 
            // dgVCdbCodesYear
            // 
            this.dgVCdbCodesYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesYear.HeaderText = "Year";
            this.dgVCdbCodesYear.Name = "dgVCdbCodesYear";
            this.dgVCdbCodesYear.ReadOnly = true;
            this.dgVCdbCodesYear.Width = 54;
            // 
            // dgVCdbCodesParttype
            // 
            this.dgVCdbCodesParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesParttype.HeaderText = "Part Type";
            this.dgVCdbCodesParttype.Name = "dgVCdbCodesParttype";
            this.dgVCdbCodesParttype.ReadOnly = true;
            this.dgVCdbCodesParttype.Width = 72;
            // 
            // dgVCdbCodesPosition
            // 
            this.dgVCdbCodesPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesPosition.HeaderText = "Position";
            this.dgVCdbCodesPosition.Name = "dgVCdbCodesPosition";
            this.dgVCdbCodesPosition.ReadOnly = true;
            this.dgVCdbCodesPosition.Width = 69;
            // 
            // dgVCdbCodesQty
            // 
            this.dgVCdbCodesQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesQty.HeaderText = "Qty";
            this.dgVCdbCodesQty.Name = "dgVCdbCodesQty";
            this.dgVCdbCodesQty.ReadOnly = true;
            this.dgVCdbCodesQty.Width = 48;
            // 
            // dgVCdbCodesPart
            // 
            this.dgVCdbCodesPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesPart.HeaderText = "Part";
            this.dgVCdbCodesPart.Name = "dgVCdbCodesPart";
            this.dgVCdbCodesPart.ReadOnly = true;
            this.dgVCdbCodesPart.Width = 51;
            // 
            // dgVCdbCodesQualifiers
            // 
            this.dgVCdbCodesQualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesQualifiers.HeaderText = "VCdb Coded Attributes";
            this.dgVCdbCodesQualifiers.Name = "dgVCdbCodesQualifiers";
            this.dgVCdbCodesQualifiers.ReadOnly = true;
            this.dgVCdbCodesQualifiers.Width = 127;
            // 
            // dgVCdbCodesNotes
            // 
            this.dgVCdbCodesNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbCodesNotes.HeaderText = "Notes";
            this.dgVCdbCodesNotes.Name = "dgVCdbCodesNotes";
            this.dgVCdbCodesNotes.ReadOnly = true;
            this.dgVCdbCodesNotes.Width = 60;
            // 
            // tabPageParttypePosition
            // 
            this.tabPageParttypePosition.Controls.Add(this.dgParttypePosition);
            this.tabPageParttypePosition.Location = new System.Drawing.Point(4, 22);
            this.tabPageParttypePosition.Name = "tabPageParttypePosition";
            this.tabPageParttypePosition.Size = new System.Drawing.Size(837, 423);
            this.tabPageParttypePosition.TabIndex = 10;
            this.tabPageParttypePosition.Text = "Parttypes/Positions";
            this.tabPageParttypePosition.UseVisualStyleBackColor = true;
            // 
            // dgParttypePosition
            // 
            this.dgParttypePosition.AllowUserToAddRows = false;
            this.dgParttypePosition.AllowUserToDeleteRows = false;
            this.dgParttypePosition.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgParttypePosition.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewParttypePositionError,
            this.dataGridViewParttypePositionAppId,
            this.dataGridViewParttypePositionBasevid,
            this.dataGridViewParttypePositionMake,
            this.dataGridViewParttypePositionModel,
            this.dataGridViewParttypePositionYear,
            this.dataGridViewParttypePositionParttype,
            this.dataGridViewParttypePositionPosition,
            this.dataGridViewParttypePositionQty,
            this.dataGridViewParttypePositionQualifiers,
            this.dataGridViewParttypePositionPart});
            this.dgParttypePosition.Location = new System.Drawing.Point(3, 3);
            this.dgParttypePosition.Name = "dgParttypePosition";
            this.dgParttypePosition.Size = new System.Drawing.Size(838, 424);
            this.dgParttypePosition.TabIndex = 4;
            this.dgParttypePosition.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgParttypePosition_SortCompare);
            // 
            // dataGridViewParttypePositionError
            // 
            this.dataGridViewParttypePositionError.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionError.HeaderText = "Error";
            this.dataGridViewParttypePositionError.Name = "dataGridViewParttypePositionError";
            this.dataGridViewParttypePositionError.ReadOnly = true;
            this.dataGridViewParttypePositionError.Width = 54;
            // 
            // dataGridViewParttypePositionAppId
            // 
            this.dataGridViewParttypePositionAppId.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionAppId.HeaderText = "App id";
            this.dataGridViewParttypePositionAppId.Name = "dataGridViewParttypePositionAppId";
            this.dataGridViewParttypePositionAppId.ReadOnly = true;
            this.dataGridViewParttypePositionAppId.Width = 51;
            // 
            // dataGridViewParttypePositionBasevid
            // 
            this.dataGridViewParttypePositionBasevid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionBasevid.HeaderText = "BaseVehicle Id";
            this.dataGridViewParttypePositionBasevid.Name = "dataGridViewParttypePositionBasevid";
            this.dataGridViewParttypePositionBasevid.ReadOnly = true;
            this.dataGridViewParttypePositionBasevid.Width = 95;
            // 
            // dataGridViewParttypePositionMake
            // 
            this.dataGridViewParttypePositionMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionMake.HeaderText = "Make";
            this.dataGridViewParttypePositionMake.Name = "dataGridViewParttypePositionMake";
            this.dataGridViewParttypePositionMake.ReadOnly = true;
            this.dataGridViewParttypePositionMake.Width = 59;
            // 
            // dataGridViewParttypePositionModel
            // 
            this.dataGridViewParttypePositionModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionModel.HeaderText = "Model";
            this.dataGridViewParttypePositionModel.Name = "dataGridViewParttypePositionModel";
            this.dataGridViewParttypePositionModel.ReadOnly = true;
            this.dataGridViewParttypePositionModel.Width = 61;
            // 
            // dataGridViewParttypePositionYear
            // 
            this.dataGridViewParttypePositionYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionYear.HeaderText = "Year";
            this.dataGridViewParttypePositionYear.Name = "dataGridViewParttypePositionYear";
            this.dataGridViewParttypePositionYear.ReadOnly = true;
            this.dataGridViewParttypePositionYear.Width = 54;
            // 
            // dataGridViewParttypePositionParttype
            // 
            this.dataGridViewParttypePositionParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionParttype.HeaderText = "Part Type";
            this.dataGridViewParttypePositionParttype.Name = "dataGridViewParttypePositionParttype";
            this.dataGridViewParttypePositionParttype.ReadOnly = true;
            this.dataGridViewParttypePositionParttype.Width = 72;
            // 
            // dataGridViewParttypePositionPosition
            // 
            this.dataGridViewParttypePositionPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionPosition.HeaderText = "Position";
            this.dataGridViewParttypePositionPosition.Name = "dataGridViewParttypePositionPosition";
            this.dataGridViewParttypePositionPosition.ReadOnly = true;
            this.dataGridViewParttypePositionPosition.Width = 69;
            // 
            // dataGridViewParttypePositionQty
            // 
            this.dataGridViewParttypePositionQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionQty.HeaderText = "Qty";
            this.dataGridViewParttypePositionQty.Name = "dataGridViewParttypePositionQty";
            this.dataGridViewParttypePositionQty.ReadOnly = true;
            this.dataGridViewParttypePositionQty.Width = 48;
            // 
            // dataGridViewParttypePositionQualifiers
            // 
            this.dataGridViewParttypePositionQualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionQualifiers.HeaderText = "Qualifiers";
            this.dataGridViewParttypePositionQualifiers.Name = "dataGridViewParttypePositionQualifiers";
            this.dataGridViewParttypePositionQualifiers.ReadOnly = true;
            this.dataGridViewParttypePositionQualifiers.Width = 75;
            // 
            // dataGridViewParttypePositionPart
            // 
            this.dataGridViewParttypePositionPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewParttypePositionPart.HeaderText = "Part";
            this.dataGridViewParttypePositionPart.Name = "dataGridViewParttypePositionPart";
            this.dataGridViewParttypePositionPart.ReadOnly = true;
            this.dataGridViewParttypePositionPart.Width = 51;
            // 
            // tabPageInvalidConfigs
            // 
            this.tabPageInvalidConfigs.Controls.Add(this.dgVCdbConfigs);
            this.tabPageInvalidConfigs.Location = new System.Drawing.Point(4, 22);
            this.tabPageInvalidConfigs.Name = "tabPageInvalidConfigs";
            this.tabPageInvalidConfigs.Size = new System.Drawing.Size(837, 423);
            this.tabPageInvalidConfigs.TabIndex = 8;
            this.tabPageInvalidConfigs.Text = "Invalid Configurations";
            this.tabPageInvalidConfigs.UseVisualStyleBackColor = true;
            // 
            // dgVCdbConfigs
            // 
            this.dgVCdbConfigs.AllowUserToAddRows = false;
            this.dgVCdbConfigs.AllowUserToDeleteRows = false;
            this.dgVCdbConfigs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVCdbConfigs.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgVCdbConfigsApplicationid,
            this.dgVCdbConfigsBasevehicleid,
            this.dgVCdbConfigsMake,
            this.dgVCdbConfigsModel,
            this.dgVCdbConfigsYear,
            this.dgVCdbConfigsParttype,
            this.dgVCdbConfigsPosition,
            this.dgVCdbConfigsQty,
            this.dgVCdbConfigsPart,
            this.dgVCdbConfigsQualifiers,
            this.dgVCdbConfigsNotes});
            this.dgVCdbConfigs.Location = new System.Drawing.Point(3, 3);
            this.dgVCdbConfigs.Name = "dgVCdbConfigs";
            this.dgVCdbConfigs.Size = new System.Drawing.Size(838, 424);
            this.dgVCdbConfigs.TabIndex = 3;
            this.dgVCdbConfigs.SortCompare += new System.Windows.Forms.DataGridViewSortCompareEventHandler(this.dgVCdbConfigs_SortCompare);
            // 
            // tabPageAddsDropsParts
            // 
            this.tabPageAddsDropsParts.Controls.Add(this.dgAddsDropsParts);
            this.tabPageAddsDropsParts.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddsDropsParts.Name = "tabPageAddsDropsParts";
            this.tabPageAddsDropsParts.Size = new System.Drawing.Size(837, 423);
            this.tabPageAddsDropsParts.TabIndex = 12;
            this.tabPageAddsDropsParts.Text = "Adds/Drops Parts";
            this.tabPageAddsDropsParts.UseVisualStyleBackColor = true;
            // 
            // dgAddsDropsParts
            // 
            this.dgAddsDropsParts.AllowUserToAddRows = false;
            this.dgAddsDropsParts.AllowUserToDeleteRows = false;
            this.dgAddsDropsParts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddsDropsParts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgAddsDropsPartsAction,
            this.dataGridViewTextBoxPart});
            this.dgAddsDropsParts.Location = new System.Drawing.Point(3, 3);
            this.dgAddsDropsParts.Name = "dgAddsDropsParts";
            this.dgAddsDropsParts.Size = new System.Drawing.Size(838, 424);
            this.dgAddsDropsParts.TabIndex = 2;
            // 
            // dgAddsDropsPartsAction
            // 
            this.dgAddsDropsPartsAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsPartsAction.HeaderText = "Action";
            this.dgAddsDropsPartsAction.Name = "dgAddsDropsPartsAction";
            this.dgAddsDropsPartsAction.ReadOnly = true;
            this.dgAddsDropsPartsAction.Width = 62;
            // 
            // dataGridViewTextBoxPart
            // 
            this.dataGridViewTextBoxPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dataGridViewTextBoxPart.HeaderText = "Part";
            this.dataGridViewTextBoxPart.Name = "dataGridViewTextBoxPart";
            this.dataGridViewTextBoxPart.ReadOnly = true;
            this.dataGridViewTextBoxPart.Width = 51;
            // 
            // tabPageAddsDropsVehicles
            // 
            this.tabPageAddsDropsVehicles.Controls.Add(this.dgAddsDropsVehicles);
            this.tabPageAddsDropsVehicles.Location = new System.Drawing.Point(4, 22);
            this.tabPageAddsDropsVehicles.Name = "tabPageAddsDropsVehicles";
            this.tabPageAddsDropsVehicles.Size = new System.Drawing.Size(837, 423);
            this.tabPageAddsDropsVehicles.TabIndex = 13;
            this.tabPageAddsDropsVehicles.Text = "Adds/Drops Vehicles";
            this.tabPageAddsDropsVehicles.UseVisualStyleBackColor = true;
            // 
            // dgAddsDropsVehicles
            // 
            this.dgAddsDropsVehicles.AllowUserToAddRows = false;
            this.dgAddsDropsVehicles.AllowUserToDeleteRows = false;
            this.dgAddsDropsVehicles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAddsDropsVehicles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgAddsDropsVehiclesAction,
            this.dgAddsDropsVehiclesBaseVid,
            this.dgAddsDropsVehiclesMake,
            this.dgAddsDropsVehiclesModel,
            this.dgAddsDropsVehiclesYear,
            this.dgAddsDropsVehiclesParttype,
            this.dgAddsDropsVehiclesPosition,
            this.dgAddsDropsVehiclesQualifiers,
            this.dgAddsDropsVehiclesMfrLabel});
            this.dgAddsDropsVehicles.Location = new System.Drawing.Point(3, 3);
            this.dgAddsDropsVehicles.Name = "dgAddsDropsVehicles";
            this.dgAddsDropsVehicles.Size = new System.Drawing.Size(838, 425);
            this.dgAddsDropsVehicles.TabIndex = 3;
            // 
            // dgAddsDropsVehiclesAction
            // 
            this.dgAddsDropsVehiclesAction.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesAction.HeaderText = "Action";
            this.dgAddsDropsVehiclesAction.Name = "dgAddsDropsVehiclesAction";
            this.dgAddsDropsVehiclesAction.ReadOnly = true;
            this.dgAddsDropsVehiclesAction.Width = 62;
            // 
            // dgAddsDropsVehiclesBaseVid
            // 
            this.dgAddsDropsVehiclesBaseVid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesBaseVid.HeaderText = "BaseVehicle id";
            this.dgAddsDropsVehiclesBaseVid.Name = "dgAddsDropsVehiclesBaseVid";
            this.dgAddsDropsVehiclesBaseVid.ReadOnly = true;
            this.dgAddsDropsVehiclesBaseVid.Width = 102;
            // 
            // dgAddsDropsVehiclesMake
            // 
            this.dgAddsDropsVehiclesMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesMake.HeaderText = "Make";
            this.dgAddsDropsVehiclesMake.Name = "dgAddsDropsVehiclesMake";
            this.dgAddsDropsVehiclesMake.ReadOnly = true;
            this.dgAddsDropsVehiclesMake.Width = 59;
            // 
            // dgAddsDropsVehiclesModel
            // 
            this.dgAddsDropsVehiclesModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesModel.HeaderText = "Model";
            this.dgAddsDropsVehiclesModel.Name = "dgAddsDropsVehiclesModel";
            this.dgAddsDropsVehiclesModel.ReadOnly = true;
            this.dgAddsDropsVehiclesModel.Width = 61;
            // 
            // dgAddsDropsVehiclesYear
            // 
            this.dgAddsDropsVehiclesYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesYear.HeaderText = "Year";
            this.dgAddsDropsVehiclesYear.Name = "dgAddsDropsVehiclesYear";
            this.dgAddsDropsVehiclesYear.ReadOnly = true;
            this.dgAddsDropsVehiclesYear.Width = 54;
            // 
            // dgAddsDropsVehiclesParttype
            // 
            this.dgAddsDropsVehiclesParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesParttype.HeaderText = "Part Type";
            this.dgAddsDropsVehiclesParttype.Name = "dgAddsDropsVehiclesParttype";
            this.dgAddsDropsVehiclesParttype.ReadOnly = true;
            this.dgAddsDropsVehiclesParttype.Width = 78;
            // 
            // dgAddsDropsVehiclesPosition
            // 
            this.dgAddsDropsVehiclesPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesPosition.HeaderText = "Position";
            this.dgAddsDropsVehiclesPosition.Name = "dgAddsDropsVehiclesPosition";
            this.dgAddsDropsVehiclesPosition.ReadOnly = true;
            this.dgAddsDropsVehiclesPosition.Width = 69;
            // 
            // dgAddsDropsVehiclesQualifiers
            // 
            this.dgAddsDropsVehiclesQualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesQualifiers.HeaderText = "Qualifiers";
            this.dgAddsDropsVehiclesQualifiers.Name = "dgAddsDropsVehiclesQualifiers";
            this.dgAddsDropsVehiclesQualifiers.ReadOnly = true;
            this.dgAddsDropsVehiclesQualifiers.Width = 75;
            // 
            // dgAddsDropsVehiclesMfrLabel
            // 
            this.dgAddsDropsVehiclesMfrLabel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgAddsDropsVehiclesMfrLabel.HeaderText = "MfrLabel";
            this.dgAddsDropsVehiclesMfrLabel.Name = "dgAddsDropsVehiclesMfrLabel";
            this.dgAddsDropsVehiclesMfrLabel.ReadOnly = true;
            this.dgAddsDropsVehiclesMfrLabel.Width = 73;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(86, 131);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(619, 20);
            this.lblStatus.TabIndex = 13;
            this.lblStatus.Text = "l1 label1 label1 label1 label1 label1 label1 label1 label1 label1 label1 label1 l" +
    "abel1 label1";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(711, 102);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(95, 23);
            this.button3.TabIndex = 14;
            this.button3.Text = "Select Qdb";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(86, 151);
            this.progressBar1.MarqueeAnimationSpeed = 0;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(709, 10);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 15;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Location = new System.Drawing.Point(801, 149);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(33, 13);
            this.lblProgressPercent.TabIndex = 16;
            this.lblProgressPercent.Text = "100%";
            // 
            // lblAppVersion
            // 
            this.lblAppVersion.AutoSize = true;
            this.lblAppVersion.Location = new System.Drawing.Point(790, 0);
            this.lblAppVersion.Name = "lblAppVersion";
            this.lblAppVersion.Size = new System.Drawing.Size(16, 13);
            this.lblAppVersion.TabIndex = 33;
            this.lblAppVersion.Text = "...";
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // btnSelectReferenceACESfile
            // 
            this.btnSelectReferenceACESfile.Location = new System.Drawing.Point(12, 41);
            this.btnSelectReferenceACESfile.Name = "btnSelectReferenceACESfile";
            this.btnSelectReferenceACESfile.Size = new System.Drawing.Size(134, 23);
            this.btnSelectReferenceACESfile.TabIndex = 34;
            this.btnSelectReferenceACESfile.Text = "Select Reference ACES";
            this.btnSelectReferenceACESfile.UseVisualStyleBackColor = true;
            this.btnSelectReferenceACESfile.Click += new System.EventHandler(this.btnSelectReferenceACESfile_Click);
            // 
            // lblReferenceACESfilePath
            // 
            this.lblReferenceACESfilePath.AutoSize = true;
            this.lblReferenceACESfilePath.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReferenceACESfilePath.Location = new System.Drawing.Point(152, 44);
            this.lblReferenceACESfilePath.Name = "lblReferenceACESfilePath";
            this.lblReferenceACESfilePath.Size = new System.Drawing.Size(45, 16);
            this.lblReferenceACESfilePath.TabIndex = 35;
            this.lblReferenceACESfilePath.Text = "label1";
            // 
            // dgVCdbConfigsApplicationid
            // 
            this.dgVCdbConfigsApplicationid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsApplicationid.HeaderText = "App id";
            this.dgVCdbConfigsApplicationid.Name = "dgVCdbConfigsApplicationid";
            this.dgVCdbConfigsApplicationid.ReadOnly = true;
            this.dgVCdbConfigsApplicationid.Width = 62;
            // 
            // dgVCdbConfigsBasevehicleid
            // 
            this.dgVCdbConfigsBasevehicleid.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsBasevehicleid.HeaderText = "Base Vehicle id";
            this.dgVCdbConfigsBasevehicleid.Name = "dgVCdbConfigsBasevehicleid";
            this.dgVCdbConfigsBasevehicleid.ReadOnly = true;
            this.dgVCdbConfigsBasevehicleid.Width = 87;
            // 
            // dgVCdbConfigsMake
            // 
            this.dgVCdbConfigsMake.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsMake.HeaderText = "Make";
            this.dgVCdbConfigsMake.Name = "dgVCdbConfigsMake";
            this.dgVCdbConfigsMake.ReadOnly = true;
            this.dgVCdbConfigsMake.Width = 59;
            // 
            // dgVCdbConfigsModel
            // 
            this.dgVCdbConfigsModel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsModel.HeaderText = "Model";
            this.dgVCdbConfigsModel.Name = "dgVCdbConfigsModel";
            this.dgVCdbConfigsModel.ReadOnly = true;
            this.dgVCdbConfigsModel.Width = 61;
            // 
            // dgVCdbConfigsYear
            // 
            this.dgVCdbConfigsYear.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsYear.HeaderText = "Year";
            this.dgVCdbConfigsYear.Name = "dgVCdbConfigsYear";
            this.dgVCdbConfigsYear.ReadOnly = true;
            this.dgVCdbConfigsYear.Width = 54;
            // 
            // dgVCdbConfigsParttype
            // 
            this.dgVCdbConfigsParttype.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsParttype.HeaderText = "Part Type";
            this.dgVCdbConfigsParttype.Name = "dgVCdbConfigsParttype";
            this.dgVCdbConfigsParttype.ReadOnly = true;
            this.dgVCdbConfigsParttype.Width = 72;
            // 
            // dgVCdbConfigsPosition
            // 
            this.dgVCdbConfigsPosition.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsPosition.HeaderText = "Position";
            this.dgVCdbConfigsPosition.Name = "dgVCdbConfigsPosition";
            this.dgVCdbConfigsPosition.ReadOnly = true;
            this.dgVCdbConfigsPosition.Width = 69;
            // 
            // dgVCdbConfigsQty
            // 
            this.dgVCdbConfigsQty.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsQty.HeaderText = "Qty";
            this.dgVCdbConfigsQty.Name = "dgVCdbConfigsQty";
            this.dgVCdbConfigsQty.ReadOnly = true;
            this.dgVCdbConfigsQty.Width = 48;
            // 
            // dgVCdbConfigsPart
            // 
            this.dgVCdbConfigsPart.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsPart.HeaderText = "Part";
            this.dgVCdbConfigsPart.Name = "dgVCdbConfigsPart";
            this.dgVCdbConfigsPart.ReadOnly = true;
            this.dgVCdbConfigsPart.Width = 51;
            // 
            // dgVCdbConfigsQualifiers
            // 
            this.dgVCdbConfigsQualifiers.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsQualifiers.HeaderText = "VCdb Coded Attributes";
            this.dgVCdbConfigsQualifiers.Name = "dgVCdbConfigsQualifiers";
            this.dgVCdbConfigsQualifiers.ReadOnly = true;
            this.dgVCdbConfigsQualifiers.Width = 127;
            // 
            // dgVCdbConfigsNotes
            // 
            this.dgVCdbConfigsNotes.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.dgVCdbConfigsNotes.HeaderText = "Notes";
            this.dgVCdbConfigsNotes.Name = "dgVCdbConfigsNotes";
            this.dgVCdbConfigsNotes.ReadOnly = true;
            this.dgVCdbConfigsNotes.Width = 60;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(894, 628);
            this.Controls.Add(this.lblReferenceACESfilePath);
            this.Controls.Add(this.btnSelectReferenceACESfile);
            this.Controls.Add(this.lblAppVersion);
            this.Controls.Add(this.lblProgressPercent);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.lblPCdbFilePath);
            this.Controls.Add(this.btnSelectPCdbFile);
            this.Controls.Add(this.lblVCdbFilePath);
            this.Controls.Add(this.btnSelectVCdbFile);
            this.Controls.Add(this.lblACESfilePath);
            this.Controls.Add(this.btnSelectACESfile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(500, 667);
            this.Name = "Form1";
            this.Text = "ACESinspector";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.dgParts)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPageStats.ResumeLayout(false);
            this.tabPageStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParttypeDisagreement)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidConfigurations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxParttypePosition)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidVCdbCodes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInvalidBasevehicles)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOverlaps)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDuplicates)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCNCoverlaps)).EndInit();
            this.tabPageExports.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBoxDataExport.ResumeLayout(false);
            this.groupBoxDataExport.PerformLayout();
            this.groupBoxAssessment.ResumeLayout(false);
            this.groupBoxAssessment.PerformLayout();
            this.tabPageParts.ResumeLayout(false);
            this.tabPagePartsMultiTypes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgParttypeDisagreement)).EndInit();
            this.tabPageDuplicates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgDuplicates)).EndInit();
            this.tabPageCNCoverlaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgCNCoverlaps)).EndInit();
            this.tabPageOverlaps.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgOverlaps)).EndInit();
            this.tabPageInvalidBasevids.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgBasevids)).EndInit();
            this.tabPageInvalidVCdbCodes.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVCdbCodes)).EndInit();
            this.tabPageParttypePosition.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgParttypePosition)).EndInit();
            this.tabPageInvalidConfigs.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgVCdbConfigs)).EndInit();
            this.tabPageAddsDropsParts.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAddsDropsParts)).EndInit();
            this.tabPageAddsDropsVehicles.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgAddsDropsVehicles)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnSelectACESfile;
        private System.Windows.Forms.Label lblACESfilePath;
        private System.Windows.Forms.Button btnSelectVCdbFile;
        private System.Windows.Forms.Label lblVCdbFilePath;
        private System.Windows.Forms.Button btnSelectPCdbFile;
        private System.Windows.Forms.Label lblPCdbFilePath;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.DataGridView dgParts;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageParts;
        private System.Windows.Forms.TabPage tabPageDuplicates;
        private System.Windows.Forms.DataGridView dgDuplicates;
        private System.Windows.Forms.TabPage tabPageOverlaps;
        private System.Windows.Forms.DataGridView dgOverlaps;
        private System.Windows.Forms.TabPage tabPageCNCoverlaps;
        private System.Windows.Forms.DataGridView dgCNCoverlaps;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.TabPage tabPageExports;
        private System.Windows.Forms.GroupBox groupBoxDataExport;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBoxExportDelimiter;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button btnAppExportSave;
        private System.Windows.Forms.GroupBox groupBoxAssessment;
        private System.Windows.Forms.Label lblAssessmentFilePath;
        private System.Windows.Forms.Button btnAssessmentSave;
        private System.Windows.Forms.Button btnSelectAssessmentFile;
        private System.Windows.Forms.TabPage tabPageInvalidBasevids;
        private System.Windows.Forms.TabPage tabPageInvalidVCdbCodes;
        private System.Windows.Forms.TabPage tabPageInvalidConfigs;
        private System.Windows.Forms.DataGridView dgBasevids;
        private System.Windows.Forms.TabPage tabPageStats;
        private System.Windows.Forms.Label lblStatsErrorsCount;
        private System.Windows.Forms.Label lblStatsWarningsCount;
        private System.Windows.Forms.Label lblStatsPartsCount;
        private System.Windows.Forms.Label lblStatsAppsCount;
        private System.Windows.Forms.Label lblStatsQdbVersion;
        private System.Windows.Forms.Label lblStatsPCdbVersion;
        private System.Windows.Forms.Label lblStatsVCdbVersion;
        private System.Windows.Forms.Label lblStatsACESversion;
        private System.Windows.Forms.Label lblStatsTitle;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgVCdbCodes;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSelectAppExportFile;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.DataGridView dgVCdbConfigs;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lblDuplicateApps;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label lblOverlapsCount;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label lblCNCoverlapsCount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label lblInvalidBasevehilcesCount;
        private System.Windows.Forms.Label lblInvalidConfigurationsCount;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label lblInvalidVCdbCodesCount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lblAppExportFilePath;
        private System.Windows.Forms.Button btnBgExportSave;
        private System.Windows.Forms.Label lblBgExportFilePath;
        private System.Windows.Forms.Label lblAppVersion;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Label lblInvalidParttypePositionCount;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TabPage tabPageParttypePosition;
        private System.Windows.Forms.DataGridView dgParttypePosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesBaseVehicleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgDuplicatesAppIds;
        private System.Windows.Forms.Button btnSelectBgExportFile;
        private System.Windows.Forms.ProgressBar progressBarInvalidConfigurations;
        private System.Windows.Forms.ProgressBar progressBarParttypePosition;
        private System.Windows.Forms.ProgressBar progressBarInvalidVCdbCodes;
        private System.Windows.Forms.ProgressBar progressBarInvalidBasevehicles;
        private System.Windows.Forms.ProgressBar progressBarOverlaps;
        private System.Windows.Forms.ProgressBar progressBarCNCoverlaps;
        private System.Windows.Forms.ProgressBar progressBarDuplicates;
        private System.Windows.Forms.PictureBox pictureBoxCNCoverlaps;
        private System.Windows.Forms.PictureBox pictureBoxInvalidConfigurations;
        private System.Windows.Forms.PictureBox pictureBoxParttypePosition;
        private System.Windows.Forms.PictureBox pictureBoxInvalidVCdbCodes;
        private System.Windows.Forms.PictureBox pictureBoxInvalidBasevehicles;
        private System.Windows.Forms.PictureBox pictureBoxOverlaps;
        private System.Windows.Forms.PictureBox pictureBoxDuplicates;
        private System.Windows.Forms.TabPage tabPagePartsMultiTypes;
        private System.Windows.Forms.DataGridView dgParttypeDisagreement;
        private System.Windows.Forms.Label lblParttypeDisagreement;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.PictureBox pictureBoxParttypeDisagreement;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPartsPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPartsAppCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPartsParttypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgPartsPositions;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgParttypeDisagreementPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgParttypeDisagreementParttypes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dbCNCgroupnumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCapplicationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCbasevehicleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCmake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCmodel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCyear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCparttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCposition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCqty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgCNCqualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsBaseVehicleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsAttributes;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgOverlapsParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsApplicationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsBasevid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgBasevidsQualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesApplicationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesQualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbCodesNotes;
        private System.Windows.Forms.ProgressBar progressBarParttypeDisagreement;
        private System.Windows.Forms.Button btnSelectReferenceACESfile;
        private System.Windows.Forms.Label lblReferenceACESfilePath;
        private System.Windows.Forms.ProgressBar progressBarDifferentials;
        private System.Windows.Forms.Label lblDifferentialsSummary;
        private System.Windows.Forms.Label lblDifferentialsLabel;
        private System.Windows.Forms.TabPage tabPageAddsDropsParts;
        private System.Windows.Forms.DataGridView dgAddsDropsParts;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsPartsAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxPart;
        private System.Windows.Forms.TabPage tabPageAddsDropsVehicles;
        private System.Windows.Forms.DataGridView dgAddsDropsVehicles;
        private System.Windows.Forms.Button btnNetChangeExportSave;
        private System.Windows.Forms.Label lblNetChangeExportFilePath;
        private System.Windows.Forms.Button btnSelectNetChangeFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesAction;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesBaseVid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesQualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgAddsDropsVehiclesMfrLabel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionError;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionAppId;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionBasevid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionQualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewParttypePositionPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsApplicationid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsBasevehicleid;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsMake;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsModel;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsYear;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsParttype;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsPosition;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsQty;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsPart;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsQualifiers;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgVCdbConfigsNotes;
    }
}

