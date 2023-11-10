using Google.Apis.Drive.v3;
using Google.Apis.Services;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.Json;
using VirixUpdater.Properties;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace VirixUpdater
{
    public partial class Form1 : Form
    {
        enum MessageState { UnknownVersion, UpToDate, UpdateAvailable }
        private MessageState _messageState;

        private static readonly Color _colorAttention = ColorTranslator.FromHtml("#FAA629");
        private static readonly Color _colorUnimportant = ColorTranslator.FromHtml("#4875BA");

        public Form1()
        {
            InitializeComponent();
            Select();
            _messageState = MessageState.UnknownVersion;

        } // end constructor

        private void Form1_Load(object sender, EventArgs e)
        {
            textBoxCurrentVersion.Text = $"v{Modpack.CurrentVersion}";
            textBoxLatestVersion.Text = $"v{Modpack.LatestVersion}";
            Modpack.Updated += RefreshUI;
            Modpack.LoadModsFolder();
            RefreshUI();

        } // end Form1_Load

        private void buttonBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(dialog.SelectedPath))
            {
                Modpack.ModsFolder = dialog.SelectedPath;
                RefreshUI();
                Modpack.SaveModsFolder();
            }

        } // end buttonBrowse_Click

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            Modpack.UpdateModpack();

        } // end buttonUpdate_Click

        /// <summary>
        /// Refreshes UI.
        /// </summary>
        private void RefreshUI()
        {
            textBoxCurrentVersion.Text = Modpack.CurrentVersion;
            textBoxLatestVersion.Text = Modpack.LatestVersion;
            textBoxModsFolder.Text = Modpack.ModsFolder;

            // Update button
            buttonUpdate.Enabled = false;
            if (Modpack.CurrentVersion != Modpack.LatestVersion)
            {
                _messageState = MessageState.UpdateAvailable;
                buttonUpdate.Enabled = true;
            }
            else
                _messageState = MessageState.UpToDate;

            // Message label
            switch (_messageState)
            {
                case MessageState.UnknownVersion:
                    labelMessage.Text = "Unknown version.";
                    labelMessage.ForeColor = _colorUnimportant;
                    break;
                case MessageState.UpdateAvailable:
                    labelMessage.Text = "An update is available!";
                    labelMessage.ForeColor = _colorAttention;
                    break;
                case MessageState.UpToDate:
                    labelMessage.Text = "No updates available.";
                    labelMessage.ForeColor = _colorUnimportant;
                    break;
            }

        } // end RefreshUI

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            // Output mods list
            if (e.KeyCode == Keys.F1)
                Modpack.OutputModFilenames();

        }

    } // end class Form1

} // end namespace