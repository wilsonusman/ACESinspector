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
            btnAssessmentSave.Enabled = false;
            btnSelectAssessmentFile.Enabled = false;
            btnAppExportSave.Enabled = false;
            btnSelectAppExportFile.Enabled = false;

            btnAnalyze.Enabled = false;
            dgParts.Width = Width - 36;
            dgParts.Height = Height - 248;

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


            tabControl1.Width = this.Width - 20;
            tabControl1.Height = this.Height - 215;
            await Task.Run(() => loadLastVCdb(vcdb));
            if (vcdb.version != "") { lblVCdbFilePath.Text = "Version: " + vcdb.version; }
            btnSelectVCdbFile.Enabled = true;

            await Task.Run(() => loadLastPCdb(vcdb));
            if (pcdb.version != "") { lblPCdbFilePath.Text = "Version: " + pcdb.version; }
            btnSelectPCdbFile.Enabled = true;
            lblAppVersion.Left = this.Width - 55;

        }


        void ReportImportProgress(int value)
        {
            progressBar1.Value = value;
            lblProgressPercent.Text = value.ToString() + "%";
        }

        private async void btnSelectACESfile_Click(object sender, EventArgs e)
        {
            var progressIndicator = new Progress<int>(ReportImportProgress);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            RegistryKey key = Registry.CurrentUser.OpenSubKey("Software", true);
            key.CreateSubKey("ACESinspector");
            key = key.OpenSubKey("ACESinspector", true);
            if (key.GetValue("lastACESDirectoryPath") != null) { openFileDialog.InitialDirectory = key.GetValue("lastACESDirectoryPath").ToString(); }

            openFileDialog.Title = "Open ACES XML file";
            openFileDialog.RestoreDirectory = false;
            openFileDialog.Filter = "XML files (*.xml)|*.xml";
            DialogResult openFileResult = openFileDialog.ShowDialog();
            if (openFileResult.ToString() == "OK")
            {
                lblStatsTitle.Text = "";
                lblStatsACESversion.Text = "";
                lblStatsVCdbVersion.Text = "";
                lblStatsPCdbVersion.Text = "";
                lblStatsQdbVersion.Text = "";
                lblStatsAppsCount.Text = "";
                lblStatsPartsCount.Text = "";
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

                dgParts.Rows.Clear();
                dgBasevids.Rows.Clear();
                dgDuplicates.Rows.Clear();
                dgCNCoverlaps.Rows.Clear();
                dgOverlaps.Rows.Clear();
                dgVCdbCodes.Rows.Clear();
                dgParttypePosition.Rows.Clear();
                dgVCdbConfigs.Rows.Clear();

                aces.clear();
                lblStatus.Text = "Importing ACES xml file";
                lblACESfilePath.Text = Path.GetFileName(openFileDialog.FileName);
                toolTip1.SetToolTip(lblACESfilePath, openFileDialog.FileName);
                

                var result = await Task.Run(() => aces.import(openFileDialog.FileName, "", progressIndicator));

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

                    foreach (string part in aces.distinctParts) { dgParts.Rows.Add(part, Convert.ToInt32(aces.partsAppsCounts[part].ToString())); }
                    progressBar1.Value = 0; lblProgressPercent.Text = ""; lblStatus.Text = "Successfully imported ACES xml";
                    btnSelectAssessmentFile.Enabled = true; btnSelectAppExportFile.Enabled = true;

                    if (vcdb.version!="" && aces.successfulImport){btnAnalyze.Enabled = true;}

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
            lblAppVersion.Left = this.Width - 55;


            

        }

        void ReportAnalyzeProgress(int value)
        {
            progressBar1.Value = value;
            lblProgressPercent.Text = value.ToString() + "%";
        }


        private async void btnAnalyze_Click(object sender, EventArgs e)
        {
            btnAnalyze.Enabled = false;

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


            lblStatus.Text = "Duplicates"; lblDuplicateApps.Text = "(analyzing)";
            await Task.Run(() => aces.duplicates(vcdb, pcdb, progressIndicator));
            lblDuplicateApps.Text = aces.duplicateErrors.Count.ToString();
            foreach (string error in aces.duplicateErrors) { dgDuplicates.Rows.Add(error.Split('\t')); }

            lblStatus.Text = "CNC overlaps"; lblCNCoverlapsCount.Text = "(analyzing)";
            await Task.Run(() => aces.CNCoverlaps(vcdb, pcdb, progressIndicator));
            lblCNCoverlapsCount.Text = aces.CNCoverlapsErrors.Count.ToString();
            foreach (string error in aces.CNCoverlapsErrors) { dgCNCoverlaps.Rows.Add(error.Split('\t')); }

            lblStatus.Text = "Overlaps"; lblOverlapsCount.Text = "(analyzing)";
            await Task.Run(() => aces.overlaps(vcdb, pcdb, progressIndicator));
            lblOverlapsCount.Text = aces.overlapsErrors.Count.ToString();
            foreach (string error in aces.overlapsErrors) { dgOverlaps.Rows.Add(error.Split('\t')); }

            lblStatus.Text = "Base vehicles"; lblInvalidBasevehilcesCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidBasevids(vcdb, pcdb, progressIndicator));
            lblInvalidBasevehilcesCount.Text = aces.basevehicleidsErrors.Count.ToString();
            foreach (string error in aces.basevehicleidsErrors) { dgBasevids.Rows.Add(error.Split('\t')); }

            lblStatus.Text = "VCdb codes"; lblInvalidVCdbCodesCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidAttributes(vcdb, pcdb, progressIndicator));
            lblInvalidVCdbCodesCount.Text = aces.vcdbCodesErrors.Count.ToString();
            foreach (string error in aces.vcdbCodesErrors) { dgVCdbCodes.Rows.Add(error.Split('\t')); }

            lblStatus.Text = "Parttype/Position"; lblInvalidParttypePositionCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidParttypePositions(vcdb, pcdb, progressIndicator));
            lblInvalidParttypePositionCount.Text = aces.parttypePositionErrors.Count.ToString();
            foreach (string error in aces.parttypePositionErrors) { dgParttypePosition.Rows.Add(error.Split('\t')); }



            lblStatus.Text = "VCdb configs"; lblInvalidConfigurationsCount.Text = "(analyzing)";
            await Task.Run(() => aces.invalidConfigs(vcdb, pcdb, progressIndicator));
            lblInvalidConfigurationsCount.Text = aces.vcdbConfigurationsErrors.Count.ToString();
            foreach (string error in aces.vcdbConfigurationsErrors) {dgVCdbConfigs.Rows.Add(error.Split('\t')); }
            aces.analysisComplete = true;

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


            progressBar1.Value = 0; lblProgressPercent.Text = ""; 

            lblStatsErrorsCount.Text = aces.analysisErrors.ToString();
            lblStatsWarningsCount.Text = aces.analysisWarnings.ToString();
            btnAnalyze.Enabled = true;

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
                    if(aces.analysisComplete) { btnAssessmentSave.Enabled = true; }
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

        private void btnBGExportSave_Click(object sender, EventArgs e)
        {
            aces.exportBuyersGuide("", vcdb);

        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }
}
