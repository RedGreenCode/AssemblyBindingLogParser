using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FusLogParser
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private List<string> _files;
        private void RefreshList()
        {
            lstFileNames.Items.Clear();
            txtOutput.Clear();
            _files = Directory.GetFiles(txtPath.Text, "*.htm", SearchOption.AllDirectories).ToList();
            foreach (var file in _files)
            {
                lstFileNames.Items.Add(file);
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            txtPath.Text = @"C:\Logs\Default";
            txtAssemblyLocation.Text = @"D:\Assemblies";
            RefreshList();
        }

        private void ToggleBold()
        {
            if (txtOutput.SelectionFont == null) return;
            var currentFont = txtOutput.SelectionFont;
            var newFontStyle = txtOutput.SelectionFont.Bold ? FontStyle.Regular : FontStyle.Bold;

            txtOutput.SelectionFont = new Font(
                currentFont.FontFamily,
                currentFont.Size,
                newFontStyle
            );
        }

        private LogParser _lp;

        private void lstFileNames_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtOutput.Clear();
            var filePath = (string)lstFileNames.SelectedItem;
            //var file = File.ReadAllText(filePath);
            //txtOutput.Text = file;

            string[] file;
            try
            {
                file = File.ReadAllLines(filePath);
            }
            catch (Exception)
            {
                return;
            }
            _lp = new LogParser(file);
            _lp.Parse();

            ToggleBold();
            txtOutput.AppendText("Summary");
            ToggleBold();
            txtOutput.AppendText(Environment.NewLine + _lp.Summary + Environment.NewLine + Environment.NewLine);
            txtOutput.AppendText("------------------------------" + Environment.NewLine + Environment.NewLine);

            if (_lp.Executable != null)
            {
                ToggleBold();
                txtOutput.AppendText("Executable: ");
                ToggleBold();
                txtOutput.AppendText(_lp.Executable + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.DisplayName != null)
            {
                ToggleBold();
                txtOutput.AppendText("Target assembly name: ");
                ToggleBold();
                txtOutput.AppendText(_lp.DisplayName + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.CallingAssembly != null)
            {
                ToggleBold();
                txtOutput.AppendText("Calling assembly name: ");
                ToggleBold();
                txtOutput.AppendText(_lp.CallingAssembly + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.AppConfig != null)
            {
                ToggleBold();
                txtOutput.AppendText("App config path: ");
                ToggleBold();
                txtOutput.AppendText(_lp.AppConfig + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.PostPolicyReference != null)
            {
                ToggleBold();
                txtOutput.AppendText("Target assembly name (after app config): ");
                ToggleBold();
                txtOutput.AppendText(_lp.PostPolicyReference + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.SuccessfulDownload != null)
            {
                ToggleBold();
                txtOutput.AppendText("Found target assembly at path: ");
                ToggleBold();
                txtOutput.AppendText(_lp.SuccessfulDownload + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.AssemblyNameFull != null)
            {
                ToggleBold();
                txtOutput.AppendText("Found assembly name: ");
                ToggleBold();
                txtOutput.AppendText(_lp.AssemblyNameFull + Environment.NewLine + Environment.NewLine);
            }

            if (_lp.NameMismatch != null)
            {
                ToggleBold();
                txtOutput.AppendText("Name mismatch part: ");
                ToggleBold();
                txtOutput.AppendText(_lp.NameMismatch + Environment.NewLine + Environment.NewLine);
            }
        }

        private void btnOpenOriginal_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start((string)lstFileNames.SelectedItem);
        }

        private void btnOpenConfig_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(_lp.AppConfig);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshList();
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            foreach (var file in _files)
            {
                File.Delete(file);
            }
            RefreshList();
        }

        private void btnGenerateBindingRedirect_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_lp.GetBindingRedirect());
        }

        private void btnGenerateCopyCommand_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_lp.GetCopyCommand(txtAssemblyLocation.Text));
        }

        private void btnCopyTargetAssemblyName_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(_lp.DisplayAssemblyName);
        }
    }
}
