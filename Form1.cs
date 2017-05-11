using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml.Linq;
using System.IO;
using System.Globalization;
using Microsoft.Win32;
using System.Security.Cryptography;

namespace ACESinspector
{
    public partial class Form1 : Form
    {
        ACES aces = new ACES();
        VCdb vcdb = new VCdb();
        PCdb pcdb = new PCdb();

        public Form1()
        {
            InitializeComponent();
        }

        private async void Form1_Load(object sender, EventArgs e)
        {

            lblAppVersion.Text = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();

            btnSelectVCdbFile.Enabled = false;
            btnSelectPCdbFile.Enabled = false;

            lblStatus.Text = "";
            lblStatsTitle.Text = "";
            lblStatsVCdbVersion.Text = "";
            lblStatsPCdbVersion.Text = "";
            lblStatsACESversion.Text = "";
            lblStatsAppsCount.Text = "";
            lblStatsPartsCount.Text = "";
            lblStatsQdbVersion.Text = "";
            lblStatsWarningsCount.Text = "";
            lblStatsErrorsCount.Text = "";
            lblParttypeDisagreement.Text = "";
            lblDuplicateApps.Text = "";
            lblOverlapsCount.Text = "";
            lblCNCoverlapsCount.Text = "";
            lblInvalidBasevehilcesCount.Text = "";
            lblInvalidConfigurationsCount.Text = "";
            lblInvalidParttypePositionCount.Text = "";
            lblInvalidVCdbCodesCount.Text = "";

            lblVCdbFilePath.Text = "";
            lblPCdbFilePath.Text = "";
            lblACESfilePath.Text = "";
            lblProgressPercent.Text = "";
            lblAssessmentFilePath.Text = "";
            lblAppExportFilePath.Text = "";
            lblBgExportFilePath.Text = "";
            btnAssessmentSave.Enabled = false;
            btnSelectAssessmentFile.Enabled = false;
            btnAppExportSave.Enabled = false;
            btnSelectAppExportFile.Enabled = false;
            btnSelectBgExportFile.Enabled = false;
            btnBgExportSave.Enabled = false;

            btnAnalyze.Enabled = false;
            dgParts.Width = Width - 36;
            dgParts.Height = Height - 248;
            dgParttypeDisagreement.Width = Width - 36;
            dgParttypeDisagreement.Height = Height - 248;
            dgDuplicates.Width = Width - 36;
            dgDuplicates.Height =Height - 248;
            dgOverlaps.Width = this.Width - 36;
            dgOverlaps.Height = this.Height - 248;
            dgCNCoverlaps.Width = this.Width - 36;
            dgCNCoverlaps.Height = this.Height - 248;
            dgBasevids.Width = this.Width - 36;
            dgBasevids.Height = this.Height - 248;
            dgVCdbCodes.Width = this.Width - 36;
            dgVCdbCodes.Height = this.Height - 248;
            dgParttypePosition.Width = this.Width - 36;
            dgParttypePosition.Height = this.Height - 248;
            dgVCdbConfigs.Width = this.Width - 36;
            dgVCdbConfigs.Height = this.Height - 248;

            pictureBoxParttypeDisagreement.Visible = false;
            pictureBoxCNCoverlaps.Visible = false;
            pictureBoxDuplicates.Visible = false;
            pictureBoxOverlaps.Visible = false;
            pictureBoxInvalidBasevehicles.Visible = false;
            pictureBoxInvalidVCdbCodes.Visible = false;
            pictureBoxParttypePosition.Visible = false;
            pictureBoxInvalidConfigurations.Visible = false;

            dgBasevids.Visible = false;
            dgParttypeDisagreement.Visible = false;
            dgDuplicates.Visible = false;
            dgCNCoverlaps.Visible = false;
            dgOverlaps.Visible = false;
            dgVCdbCodes.Visible = false;
            dgParttypePosition.Visible = false;
            dgVCdbConfigs.Visible = false;

            tabControl1.Width = this.Width - 20;
            tabControl1.Height = this.Height - 215;
            await Task.Run(() => loadLastVCdb(vcdb));
            if (vcdb.version != "") { lblVCdbFilePath.Text = "Version: " + vcdb.version; }
            btnSelectVCdbFile.Enabled = true;

            await Task.Run(() => loadLastPCdb(vcdb));
            if (pcdb.version != "") { lblPCdbFilePath.Text = "Version: " + pcdb.version; }
            btnSelectPCdbFile.Enabled = true;
            lblAppVersion.Left = this.Width - 65;


            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ACESinspector");
            key = key.OpenSubKey("ACESinspector", true);
            if (key.GetValue("lastAssessmentDirectoryPath") != null) { lblAssessmentFilePath.Text = key.GetValue("lastAssessmentDirectoryPath").ToString(); }
            if (key.GetValue("lastAppExportDirectoryPath") != null) { lblAppExportFilePath.Text = key.GetValue("lastAppExportDirectoryPath").ToString(); }
            if (key.GetValue("lastBuyersGuideDirectoryPath") != null) { lblBgExportFilePath.Text = key.GetValue("lastBuyersGuideDirectoryPath").ToString(); }

        }


        void ReportImportProgress(int value)
        {
            progressBar1.Value = value;
            lblProgressPercent.Text = value.ToString() + "%";
        }

        private async void btnSelectACESfile_Click(object sender, EventArgs e)
        {
            btnSelectACESfile.Enabled = false;
            btnSelectVCdbFile.Enabled = false;
            btnSelectPCdbFile.Enabled = false;

            var progressIndicator = new Progress<int>(ReportImportProgress);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ACESinspector");
            key = key.OpenSubKey("ACESinspector", true);
            if (key.GetValue("lastACESDirectoryPath") != null) { openFileDialog.InitialDirectory = key.GetValue("lastACESDirectoryPath").ToString(); }
            string partTypeNameListString = ""; string positionNameListString = "";

            openFileDialog.Title = "Open ACES XML file";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult openFileResult = openFileDialog.ShowDialog();
            if (openFileResult.ToString() == "OK")
            {
                lblStatsTitle.Text = "";
                lblStatsACESversion.Text = "";
                lblStatsVCdbVersion.Text = ""; lblStatsVCdbVersion.ForeColor = SystemColors.ControlText;
                lblStatsPCdbVersion.Text = "";
                lblStatsQdbVersion.Text = "";
                lblStatsAppsCount.Text = "";
                lblStatsPartsCount.Text = "";
                lblStatsWarningsCount.Text = "";
                lblStatsErrorsCount.Text = "";
                lblParttypeDisagreement.Text = "";
                lblDuplicateApps.Text = "";
                lblCNCoverlapsCount.Text = "";
                lblOverlapsCount.Text = "";
                lblInvalidBasevehilcesCount.Text = "";
                lblInvalidVCdbCodesCount.Text = "";
                lblInvalidParttypePositionCount.Text = "";
                lblInvalidConfigurationsCount.Text = "";
                lblStatus.BackColor = SystemColors.ButtonFace;

                progressBarDuplicates.Value = 0;
                progressBarCNCoverlaps.Value = 0;
                progressBarOverlaps.Value = 0;
                progressBarInvalidBasevehicles.Value = 0;
                progressBarInvalidVCdbCodes.Value = 0;
                progressBarParttypePosition.Value = 0;
                progressBarInvalidConfigurations.Value = 0;

                pictureBoxParttypeDisagreement.Visible = false;
                pictureBoxCNCoverlaps.Visible = false;
                pictureBoxDuplicates.Visible = false;
                pictureBoxOverlaps.Visible = false;
                pictureBoxInvalidBasevehicles.Visible = false;
                pictureBoxInvalidVCdbCodes.Visible = false;
                pictureBoxParttypePosition.Visible = false;
                pictureBoxInvalidConfigurations.Visible = false;

                dgParts.Rows.Clear();

                dgParttypeDisagreement.Rows.Clear();
                dgParttypeDisagreement.Visible = false;

                dgBasevids.Rows.Clear();
                dgBasevids.Visible = false;

                dgDuplicates.Rows.Clear();
                dgDuplicates.Visible = false;

                dgCNCoverlaps.Rows.Clear();
                dgCNCoverlaps.Visible = false;

                dgOverlaps.Rows.Clear();
                dgOverlaps.Visible = false;

                dgVCdbCodes.Rows.Clear();
                dgVCdbCodes.Visible = false;

                dgParttypePosition.Rows.Clear();
                dgParttypePosition.Visible = false;

                dgVCdbConfigs.Rows.Clear();
                dgVCdbConfigs.Visible = false;


                aces.clear();
                lblStatus.Text = "Importing ACES xml file";
                lblACESfilePath.Text = Path.GetFileName(openFileDialog.FileName);
                toolTip1.SetToolTip(lblACESfilePath, openFileDialog.FileName);
                

                var result = await Task.Run(() => aces.import(openFileDialog.FileName, "", progressIndicator));

                btnSelectACESfile.Enabled = true;
                btnSelectVCdbFile.Enabled = true;
                btnSelectPCdbFile.Enabled = true;



                if (aces.xmlValidationErrors.Count == 0 && aces.appsCount > 0)
                {
                    lblStatsTitle.Text = aces.DocumentTitle;
                    lblStatsAppsCount.Text = aces.appsCount.ToString();
                    lblStatsACESversion.Text = aces.version;
                    lblStatsVCdbVersion.Text = aces.VcdbVersionDate;
                    lblStatsPCdbVersion.Text = aces.PcdbVersionDate;
                    lblStatsQdbVersion.Text = aces.QdbVersionDate;
                    lblStatsPartsCount.Text = aces.distinctParts.Count.ToString();
                    lblStatsErrorsCount.Text = "(not yet analyzed)";
                    lblStatsWarningsCount.Text = "(not yet analyzed)";
                    lblDuplicateApps.Text = "(not yet analyzed)";
                    lblOverlapsCount.Text = "(not yet analyzed)";
                    lblCNCoverlapsCount.Text = "(not yet analyzed)";
                    lblInvalidBasevehilcesCount.Text = "(not yet analyzed)";
                    lblInvalidConfigurationsCount.Text = "(not yet analyzed)";
                    lblInvalidParttypePositionCount.Text = "(not yet analyzed)";
                    lblInvalidVCdbCodesCount.Text = "(not yet analyzed)";

                    
                    foreach (string part in aces.distinctParts)
                    {
                        string[] partTypeIdStrings = aces.partsPartTypes[part].Split('\t');
                        partTypeNameListString = ""; foreach (string partTypeIdString in partTypeIdStrings) { partTypeNameListString += pcdb.niceParttype(Convert.ToInt32(partTypeIdString)) + ",";}
                        partTypeNameListString = partTypeNameListString.Substring(0, partTypeNameListString.Length - 1);
                        if (partTypeIdStrings.Count() > 1) {dgParttypeDisagreement.Rows.Add(part, partTypeNameListString); aces.parttypeDisagreementErrors.Add(part +"\t" + partTypeNameListString); }
                        string[] positionIdStrings = aces.partsPositions[part].Split('\t');
                        positionNameListString = ""; foreach (string positionIdString in positionIdStrings) { positionNameListString += pcdb.nicePosition(Convert.ToInt32(positionIdString)) + ","; }
                        positionNameListString = positionNameListString.Substring(0, positionNameListString.Length - 1);
                        dgParts.Rows.Add(part, Convert.ToInt32(aces.partsAppsCounts[part].ToString()), partTypeNameListString, positionNameListString);
                    }
                    progressBar1.Value = 0; lblProgressPercent.Text = ""; lblStatus.Text = "Successfully imported ACES xml";
                    btnSelectAssessmentFile.Enabled = true; btnSelectAppExportFile.Enabled = true; btnSelectBgExportFile.Enabled = true;
                    pictureBoxParttypeDisagreement.Visible = true; lblParttypeDisagreement.Text = dgParttypeDisagreement.Rows.Count.ToString();
                    if (dgParttypeDisagreement.Rows.Count > 0) {pictureBoxParttypeDisagreement.BackColor = Color.Yellow; dgParttypeDisagreement.Visible = true; } else {  pictureBoxParttypeDisagreement.BackColor = Color.Green; dgParttypeDisagreement.Visible = false; }

                    if (vcdb.version!="" && aces.successfulImport)
                    {
                        btnAnalyze.Enabled = true;
                        try {if(Directory.Exists(lblAppExportFilePath.Text)){ btnAppExportSave.Enabled = true;}}catch (Exception){ }// Fail silently.
                        try {if(Directory.Exists(lblBgExportFilePath.Text)) {btnBgExportSave.Enabled = true; }} catch (Exception) { }// Fail silently.
                    }

                    key.SetValue("lastACESDirectoryPath", Path.GetDirectoryName(openFileDialog.FileName));

                }
                else
                {
                    MessageBox.Show("XML failed schema validation.\r\n\r\n"+aces.xmlValidationErrors[0]);
                    progressBar1.Value = 0; lblProgressPercent.Text = ""; lblACESfilePath.Text = ""; lblStatus.Text = "";
                }
            }
        }


        private async void btnSelectVCdbFile_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportImportProgress);
            string md5Hash = "";

            using (var openFileDialog = new OpenFileDialog())
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("ACESinspector");
                key = key.OpenSubKey("ACESinspector", true);
                if (key.GetValue("lastVCdbDirectoryPath") != null) { openFileDialog.InitialDirectory = key.GetValue("lastVCdbDirectoryPath").ToString(); }

                openFileDialog.RestoreDirectory = false;
                openFileDialog.Filter = "Access Database files (*.accdb)|*.accdb";

                DialogResult openFileResult = openFileDialog.ShowDialog();

                if (openFileResult.ToString() == "OK")
                {
                    vcdb.disconnect();
                    vcdb.clear();
                    lblVCdbFilePath.Text = "Loading...";
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(openFileDialog.FileName))
                        {
                            md5Hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        }
                    }

                    vcdb.connect(openFileDialog.FileName);
                    var result = await Task.Run(() => vcdb.import());
                    lblVCdbFilePath.Text = "Version: " + vcdb.version;
                    if (vcdb.version != "")
                    {
                        key.SetValue("lastVCdbDirectoryPath", Path.GetDirectoryName(openFileDialog.FileName));
                        key.SetValue("lastVCdbFilePath", openFileDialog.FileName);
                        key.SetValue("lastVCdbFileMD5", md5Hash);

                        if (aces.successfulImport){btnAnalyze.Enabled = true;}
                    }
                    else
                    {
                        MessageBox.Show("Error importing VCdb ("+result+")");
                    }
                }
            }
        }

        private async void btnSelectPCdbFile_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportImportProgress);
            string md5Hash = "";
            using (var openFileDialog = new OpenFileDialog())
            {
                RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                key.CreateSubKey("ACESinspector");
                key = key.OpenSubKey("ACESinspector", true);
                if (key.GetValue("lastPCdbDirectoryPath") != null) { openFileDialog.InitialDirectory = key.GetValue("lastPCdbDirectoryPath").ToString(); }
                openFileDialog.RestoreDirectory = false;
                openFileDialog.Filter = "Access Database files (*.accdb)|*.accdb";
                DialogResult openFileResult = openFileDialog.ShowDialog();

                if (openFileResult.ToString() == "OK")
                {
                    pcdb.disconnect();
                    pcdb.clear();
                    lblPCdbFilePath.Text = "Loading...";
                    using (var md5 = MD5.Create())
                    {
                        using (var stream = File.OpenRead(openFileDialog.FileName))
                        {
                            md5Hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                        }
                    }

                    pcdb.connect(openFileDialog.FileName);
                    var result = await Task.Run(() => pcdb.import());
                    lblPCdbFilePath.Text = "Version: " + pcdb.version;
                    if (pcdb.version != "")
                    {
                        key.SetValue("lastPCdbDirectoryPath", Path.GetDirectoryName(openFileDialog.FileName));
                        key.SetValue("lastPCdbFilePath", openFileDialog.FileName);
                        key.SetValue("lastPCdbFileMD5", md5Hash);
                    }
                    else
                    {
                        MessageBox.Show("Error importing PCdb (" + result + ")");
                    }
                }
            }
        }



        public async void loadLastVCdb(VCdb vcdb)
        {
            string vcdbFilePath = null;
            string md5Hash;
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ACESinspector");
            key = key.OpenSubKey("ACESinspector", true);
            vcdbFilePath = key.GetValue("lastVCdbFilePath","").ToString();
            if (vcdbFilePath != "")
            {
                using (var md5 = MD5.Create())
                {
                    try
                    {
                        using (var stream = File.OpenRead(vcdbFilePath))
                        {
                            md5Hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                            if (md5Hash == key.GetValue("lastVCdbFileMD5").ToString())
                            {
                                vcdb.disconnect();
                                vcdb.clear();
                                vcdb.connect(vcdbFilePath);
                                vcdb.import();
                            }
                        }
                    }
                    catch (Exception ex)
                    {// most likely a file-not-found error

                    }
                }
            }
        }


        public async void loadLastPCdb(VCdb vcdb)
        {
            string pcdbFilePath = null;
            string md5Hash;
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ACESinspector");
            key = key.OpenSubKey("ACESinspector", true);
            pcdbFilePath = key.GetValue("lastPCdbFilePath","").ToString();
            if (pcdbFilePath != "")
            {
                using (var md5 = MD5.Create())
                {
                    try
                    {
                        using (var stream = File.OpenRead(pcdbFilePath))
                        {
                            md5Hash = BitConverter.ToString(md5.ComputeHash(stream)).Replace("-", string.Empty);
                            if (md5Hash == key.GetValue("lastPCdbFileMD5").ToString())
                            {
                                pcdb.disconnect();
                                pcdb.clear();
                                pcdb.connect(pcdbFilePath);
                                pcdb.import();
                            }
                        }
                    }
                    catch (Exception ex)
                    {// most likely a file-not-found error

                    }
                }
            }
        }







        private void Form1_Resize(object sender, EventArgs e)
        {
            dgParts.Width = this.Width - 36;
            dgParts.Height = this.Height - 248;
            dgParttypeDisagreement.Width = Width - 36;
            dgParttypeDisagreement.Height = Height - 248;
            dgDuplicates.Width = this.Width - 36;
            dgDuplicates.Height = this.Height - 248;
            dgOverlaps.Width = this.Width - 36;
            dgOverlaps.Height = this.Height - 248;
            dgCNCoverlaps.Width = this.Width - 36;
            dgCNCoverlaps.Height = this.Height - 248;
            dgBasevids.Width = this.Width - 36;
            dgBasevids.Height = this.Height - 248;
            dgVCdbCodes.Width = this.Width - 36;
            dgVCdbCodes.Height = this.Height - 248;
            dgParttypePosition.Width = this.Width - 36;
            dgParttypePosition.Height = this.Height - 248;
            dgVCdbConfigs.Width = this.Width - 36;
            dgVCdbConfigs.Height = this.Height - 248;

            tabControl1.Width = this.Width - 20;
            tabControl1.Height = this.Height - 215;
            //btnAnalyze.Left = Width -100;
            progressBar1.Width = Width - 150;
            lblProgressPercent.Left = Width - 60;
            //lblProgressPercent.Text = "100%";
            lblAppVersion.Left = this.Width - 65;







        }

        void ReportAnalyzeProgress(int value)
        {
            progressBar1.Value = value;
            lblProgressPercent.Text = value.ToString() + "%";
        }

        void ReportAnalyzeProgressDuplicates(int value)
        {
            progressBarDuplicates.Value = value;
        }

        void ReportAnalyzeProgressCNCoverlaps(int value)
        {
            progressBarCNCoverlaps.Value = value;
        }

        void ReportAnalyzeProgressOverlaps(int value)
        {
            progressBarOverlaps.Value = value;
        }

        void ReportAnalyzeProgressInvalidBasevehicles(int value)
        {
            progressBarInvalidBasevehicles.Value = value;
        }

        void ReportAnalyzeProgressInvalidVCdbCodes (int value)
        {
            progressBarInvalidVCdbCodes.Value = value;
        }

        void ReportAnalyzeProgressParttypePosition(int value)
        {
            progressBarParttypePosition.Value = value;
        }

        void ReportAnalyzeProgressInvalidConfigurations(int value)
        {
            progressBarInvalidConfigurations.Value = value;
        }


        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            btnAnalyze.Enabled = false;
            btnSelectACESfile.Enabled = false;
            btnSelectVCdbFile.Enabled = false;
            btnSelectPCdbFile.Enabled = false;

            lblStatsVCdbVersion.Text = aces.VcdbVersionDate; lblStatsVCdbVersion.ForeColor = SystemColors.ControlText;
            lblStatsPCdbVersion.Text = aces.PcdbVersionDate; lblStatsPCdbVersion.ForeColor = SystemColors.ControlText;
            lblStatsQdbVersion.Text = aces.QdbVersionDate; lblStatsQdbVersion.ForeColor = SystemColors.ControlText;

            lblStatsWarningsCount.Text = "";
            lblStatsErrorsCount.Text = "";
            lblDuplicateApps.Text = "";
            lblCNCoverlapsCount.Text = "";
            lblOverlapsCount.Text = "";
            lblInvalidBasevehilcesCount.Text = "";
            lblInvalidVCdbCodesCount.Text = "";
            lblInvalidParttypePositionCount.Text = "";
            lblInvalidConfigurationsCount.Text = "";
            lblStatus.BackColor = SystemColors.ButtonFace;

            dgBasevids.Rows.Clear();
            dgDuplicates.Rows.Clear();
            dgCNCoverlaps.Rows.Clear();
            dgOverlaps.Rows.Clear();
            dgVCdbCodes.Rows.Clear();
            dgParttypePosition.Rows.Clear();
            dgVCdbConfigs.Rows.Clear();

            aces.clearAnalysisResults();

            lblStatsErrorsCount.Text = "(analyzing)";
            lblStatsWarningsCount.Text = "(analyzing)";

            var progressIndicator = new Progress<int>(ReportAnalyzeProgress);

            var progressDuplicates = new Progress<int>(ReportAnalyzeProgressDuplicates);
            var progressCNCoverlaps = new Progress<int>(ReportAnalyzeProgressCNCoverlaps);
            var progressOverlaps = new Progress<int>(ReportAnalyzeProgressOverlaps);
            var progressInvalidBasevehicles = new Progress<int>(ReportAnalyzeProgressInvalidBasevehicles);
            var progressInvalidVCdbCodes = new Progress<int>(ReportAnalyzeProgressInvalidVCdbCodes);
            var progressParttypePosition = new Progress<int>(ReportAnalyzeProgressParttypePosition);
            var progressInvalidConfigurations = new Progress<int>(ReportAnalyzeProgressInvalidConfigurations);

            //await Task.Run(() => aces.disperateAttributes(vcdb, pcdb, progressIndicator));


            lblParttypeDisagreement.Text = dgParttypeDisagreement.Rows.Count.ToString();



            lblStatus.Text = "Analyzing"; lblDuplicateApps.Text = "(analyzing)";
            await Task.Run(() => aces.duplicates(vcdb, pcdb, progressDuplicates));
            lblDuplicateApps.Text = aces.duplicateErrors.Count.ToString();
            pictureBoxDuplicates.Visible = true; if (aces.duplicateErrors.Count > 0) { dgDuplicates.Visible = true; pictureBoxDuplicates.BackColor = Color.Yellow; } else { pictureBoxDuplicates.BackColor = Color.Green; }
            foreach (string error in aces.duplicateErrors) { dgDuplicates.Rows.Add(error.Split('\t')); }

            lblCNCoverlapsCount.Text = "(analyzing)";
            await Task.Run(() => aces.CNCoverlaps(vcdb, pcdb, progressCNCoverlaps));
            lblCNCoverlapsCount.Text = aces.CNCoverlapsErrors.Count.ToString();
            pictureBoxCNCoverlaps.Visible = true; if (aces.CNCoverlapsErrors.Count > 0) { dgCNCoverlaps.Visible = true; pictureBoxCNCoverlaps.BackColor = Color.Red; } else { pictureBoxCNCoverlaps.BackColor = Color.Green; }
            foreach (string error in aces.CNCoverlapsErrors) { dgCNCoverlaps.Rows.Add(error.Split('\t')); }

            lblOverlapsCount.Text = "(analyzing)";
            await Task.Run(() => aces.overlaps(vcdb, pcdb, progressOverlaps));
            lblOverlapsCount.Text = aces.overlapsErrors.Count.ToString();
            pictureBoxOverlaps.Visible = true; if (aces.overlapsErrors.Count > 0) { dgOverlaps.Visible = true; pictureBoxOverlaps.BackColor = Color.Red;}else { pictureBoxOverlaps.BackColor = Color.Green; }
            foreach (string error in aces.overlapsErrors)
            {
                dgOverlaps.Rows.Add(error.Split('\t'));
            }


            lblInvalidBasevehilcesCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidBasevids(vcdb, pcdb, progressInvalidBasevehicles));
            lblInvalidBasevehilcesCount.Text = aces.basevehicleidsErrors.Count.ToString();
            pictureBoxInvalidBasevehicles.Visible = true; if (aces.basevehicleidsErrors.Count > 0) { dgBasevids.Visible = true; pictureBoxInvalidBasevehicles.BackColor = Color.Red; } else { pictureBoxInvalidBasevehicles.BackColor = Color.Green; }
            foreach (string error in aces.basevehicleidsErrors) { dgBasevids.Rows.Add(error.Split('\t')); }

            lblInvalidVCdbCodesCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidAttributes(vcdb, pcdb, progressInvalidVCdbCodes));
            lblInvalidVCdbCodesCount.Text = aces.vcdbCodesErrors.Count.ToString();
            pictureBoxInvalidVCdbCodes.Visible = true; if (aces.vcdbCodesErrors.Count > 0) { dgVCdbCodes.Visible = true; pictureBoxInvalidVCdbCodes.BackColor = Color.Red; } else { pictureBoxInvalidVCdbCodes.BackColor = Color.Green; }
            foreach (string error in aces.vcdbCodesErrors) { dgVCdbCodes.Rows.Add(error.Split('\t')); }

            lblInvalidParttypePositionCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidParttypePositions(vcdb, pcdb, progressParttypePosition));
            lblInvalidParttypePositionCount.Text = aces.parttypePositionErrors.Count.ToString();
            pictureBoxParttypePosition.Visible = true; if (aces.parttypePositionErrors.Count > 0) { dgParttypePosition.Visible = true; pictureBoxParttypePosition.BackColor = Color.Red; } else { pictureBoxParttypePosition.BackColor = Color.Green; }
            foreach (string error in aces.parttypePositionErrors) { dgParttypePosition.Rows.Add(error.Split('\t')); }
            

            lblInvalidConfigurationsCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidConfigs(vcdb, pcdb, progressInvalidConfigurations));
            lblInvalidConfigurationsCount.Text = aces.vcdbConfigurationsErrors.Count.ToString();
            pictureBoxInvalidConfigurations.Visible = true; if (aces.vcdbConfigurationsErrors.Count > 0) { dgVCdbConfigs.Visible = true; pictureBoxInvalidConfigurations.BackColor = Color.Red; } else { pictureBoxInvalidConfigurations.BackColor = Color.Green; }
            foreach (string error in aces.vcdbConfigurationsErrors) {dgVCdbConfigs.Rows.Add(error.Split('\t')); }


            aces.analysisComplete = true;
            btnSelectACESfile.Enabled = true;
            btnSelectVCdbFile.Enabled = true;
            btnSelectPCdbFile.Enabled = true;


            if (lblAssessmentFilePath.Text != "") { btnAssessmentSave.Enabled = true; }


            if (aces.analysisErrors > 0)
            {
                lblStatus.Text = "Analysis complete (Failed)"; lblStatus.BackColor = Color.Red;
            }
            else
            {
                if (aces.analysisWarnings > 0)
                {
                    lblStatus.Text = "Analysis complete (Passed with warnings)"; lblStatus.BackColor = Color.Yellow;
                }
                else
                {
                    lblStatus.Text = "Analysis complete (Passed)"; lblStatus.BackColor = Color.LightGreen;
                }
            }

            
            if (aces.VcdbVersionDate != vcdb.version)
            {
                lblStatsVCdbVersion.ForeColor = Color.DarkOrange;
                lblStatsVCdbVersion.Text = aces.VcdbVersionDate + "  (validated against VCdb:" + vcdb.version + ")";
            }

            lblProgressPercent.Text = ""; 

            lblStatsErrorsCount.Text = aces.analysisErrors.ToString();
            lblStatsWarningsCount.Text = aces.analysisWarnings.ToString();
        }

        private void groupBoxFilters_Enter(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSelectAssessmentFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    lblAssessmentFilePath.Text = fbd.SelectedPath;
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                    key.CreateSubKey("ACESinspector");
                    key = key.OpenSubKey("ACESinspector", true);
                    key.SetValue("lastAssessmentDirectoryPath", fbd.SelectedPath);
                    if (aces.analysisComplete) { btnAssessmentSave.Enabled = true; }
                }
            }
        }

        private async void btnAssessmentSave_Click(object sender, EventArgs e)
        {
            if (lblAssessmentFilePath.Text != "")
            {
                string result = aces.generateAssessmentFile(lblAssessmentFilePath.Text + @"\Assessment_" + Path.GetFileName(aces.filePath)  ,pcdb);
                MessageBox.Show(result);
            }

        }

        private void btnSelectAppExportFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && aces.appsCount > 0)
                {
                    lblAppExportFilePath.Text = fbd.SelectedPath; btnAppExportSave.Enabled = true;
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                    key.CreateSubKey("ACESinspector");
                    key = key.OpenSubKey("ACESinspector", true);
                    key.SetValue("lastAppExportDirectoryPath", fbd.SelectedPath);
                }
            }

        }

        private async void btnAppExportSave_Click(object sender, EventArgs e)
        {
            if (lblAppExportFilePath.Text != "")
            {
                string result = aces.exportFlatApps(lblAppExportFilePath.Text + @"\FlattenedApps.txt",vcdb,pcdb);
                MessageBox.Show(result);
            }

        }

        private void btnSelectBgExportFile_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && aces.appsCount > 0)
                {
                    lblBgExportFilePath.Text = fbd.SelectedPath; btnBgExportSave.Enabled = true;
                    RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
                    key.CreateSubKey("ACESinspector");
                    key = key.OpenSubKey("ACESinspector", true);
                    key.SetValue("lastBuyersGuideDirectoryPath", fbd.SelectedPath);

                }
            }

        }

        private async void btnBGExportSave_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportAnalyzeProgress);
            btnAnalyze.Enabled = false; btnBgExportSave.Enabled = false; btnSelectBgExportFile.Enabled = false;

            lblStatus.Text = "Exporting buyer's guide"; 
            await Task.Run(() => aces.exportBuyersGuide(lblBgExportFilePath.Text + @"\BuyersGuide.txt", vcdb, progressIndicator));
            lblStatus.Text = ""; progressBar1.Value = 0; btnAnalyze.Enabled = true; btnBgExportSave.Enabled = true; btnSelectBgExportFile.Enabled = true;

            //            MessageBox.Show(result);
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }

        private void dgCNCoverlaps_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //Column 0 is group number - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }

            //Column 1 is app id - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 1)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }

            //Column 2 is basevid - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 2)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }


            //Column 5 is year - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 5)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }
        }

        private void dgDuplicates_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //Column 0 is basevid - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }

        }

        private void dgOverlaps_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            //Column 0 is group number - it needs to be compared numerically for sort instead of the default alpha
            if (e.Column.Index == 0)
            {
                e.SortResult = int.Parse(e.CellValue1.ToString()).CompareTo(int.Parse(e.CellValue2.ToString()));
                e.Handled = true;//pass by the default sorting
            }

        }

    }
}
