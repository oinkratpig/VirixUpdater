using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using VirixUpdater.Properties;

namespace VirixUpdater
{
    internal static class Modpack
    {
        /// <summary>
        /// Latest version (fetched from server FTP)
        /// </summary>
        public static string LatestVersion { get; private set; }

        /// <summary>
        /// Current version (read from virix_version.txt in mods folder)
        /// </summary>
        public static string CurrentVersion { get; private set; }

        /// <summary>
        /// Virix mods folder
        /// </summary>
        public static string? ModsFolder {
            get { return _modsFolder; }
            set {
                _modsFolder = value;
                CurrentVersion = GetCurrentVersion();
            }
        }

        // Events
        public delegate void UpdatedHandler();
        public static event UpdatedHandler Updated;

        // Fields
        public static readonly string defaultVersion = "?.?";
        private static readonly string _saveFile = "modsfolder.txt";
        private static readonly string _modsFile = "virix_mods.csv";
        private static readonly string? _assemblyPath;
        private static string? _modsFolder;
        private static string[] _modFileNames;
        private static int _currentModIndex;

        // Constructor
        static Modpack()
        {
            _assemblyPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            LatestVersion = GetLatestVersion();
            CurrentVersion = defaultVersion;

        } // end constructor

        /// <summary>
        /// Updates the modpack.
        /// </summary>
        public static void UpdateModpack()
        {
            if (!Directory.Exists(ModsFolder)) return;

            // Get list of mod file names
            string str = string.Empty;
            using (WebClient wc = new WebClient())
            {
                byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/oinkratpig/VirixUpdater/master/Mods/virix_mods.csv");
                str = Encoding.Default.GetString(raw);
            }
            _modFileNames = str.Split(',');
            // Remove extra element at end because of trailing comma
            _modFileNames = _modFileNames.Take(_modFileNames.Count() - 1).ToArray();

            // Remove all mods not in the mod list
            foreach(string filePath in Directory.GetFiles(ModsFolder))
                if(Path.GetExtension(filePath) == ".jar" && !_modFileNames.Contains(Path.GetFileName(filePath)))
                    File.Delete(filePath);

            // Progress bar
            FormInstalling formInstalling = new FormInstalling();
            formInstalling.Show();

            // Download all mods into mods folder
            _currentModIndex = 0;
            using (WebClient wc = new WebClient())
            {
                new Task(() => {
                    // Cancel
                    bool canceled = false;
                    formInstalling.FormClosed += (object? sender, FormClosedEventArgs e) =>
                    {
                        canceled = true;
                    };
                    // Download mods
                    while (_currentModIndex < _modFileNames.Length)
                    {
                        if (canceled) return;
                        DownloadNextMod(wc, formInstalling);
                    }
                    // Update version
                    using (StreamWriter writer = new StreamWriter(Path.Join(ModsFolder, "virix_version.txt")))
                        writer.Write(LatestVersion);
                    CurrentVersion = LatestVersion;
                    // Done downloading
                    MessageBox.Show("Finished updating");
                    Updated.Invoke();
                    formInstalling.Close();
                }).Start();
            }

        } // end UpdateModpack

        /// <summary>
        /// Download the next queued mod for download
        /// </summary>
        private static void DownloadNextMod(WebClient wc, FormInstalling formInstalling)
        {
            string newline = "\r\n";
            if (string.IsNullOrWhiteSpace(formInstalling.InstallingTextBox.Text))
                newline = string.Empty;
            // Download file
            int oldLen = formInstalling.InstallingTextBox.Text.Length;
            string mod = _modFileNames[_currentModIndex];
            if (File.Exists(Path.Join(ModsFolder, mod)))
                //formInstalling.InstallingTextBox.AppendText($"{newline}Mod \"{mod}\" already installed");
                formInstalling.InstallingTextBox.Text += $"{newline}Mod \"{mod}\" already installed";
            else
            {
                //formInstalling.InstallingTextBox.AppendText($"{newline}Downloading \"{mod}");
                formInstalling.InstallingTextBox.Text += $"{newline}Downloading \"{mod}";
                DownloadFile(wc, "https://raw.githubusercontent.com/oinkratpig/VirixUpdater/master/Mods/" + mod, Path.Join(ModsFolder, mod));
            }
            // Progress
            formInstalling.InstallingProgressBar.Value = (int)((++_currentModIndex + 1.0f) / _modFileNames.Length * 100);

        } // end DownloadModByIndex

        /// <summary>
        /// Download a file from the internet asyncronously
        /// </summary>
        /// <param name="url"></param>
        private static void DownloadFile(WebClient wc, string url, string destination)
        {
            byte[] modBytes = wc.DownloadData(url);
            using (FileStream stream = new FileStream(destination, FileMode.Create, FileAccess.Write))
                stream.Write(modBytes, 0, modBytes.Length);

        } // end DownloadFile

        /// <summary>
        /// Overwrite the mods folder save file with new mods folder.
        /// </summary>
        public static void SaveModsFolder()
        {
            using (StreamWriter writer = new StreamWriter(Path.Join(_assemblyPath, _saveFile)))
                writer.WriteLine(ModsFolder);

        } // end SaveModsFolder

        /// <summary>
        /// Loads the saved mods folder.
        /// </summary>
        public static void LoadModsFolder()
        {
            string path = Path.Join(_assemblyPath, _saveFile);
            if (File.Exists(path))
                using (StreamReader reader = new StreamReader(path))
                    ModsFolder = reader.ReadLine();

        } // end SaveModsFolder

        /// <summary>
        /// Saves a file containing all mod filenames.
        /// Just for Oinky purposes.
        /// </summary>
        public static void OutputModFilenames()
        {
            string modsRepoFolder = "C:\\Users\\knila\\Desktop\\Dev\\Visual Studio\\VirixUpdater\\Mods";
            if (!Directory.Exists(modsRepoFolder)) return;

            using (StreamWriter writer = new StreamWriter(Path.Join(_assemblyPath, _modsFile)))
                foreach (string filepath in Directory.GetFiles(modsRepoFolder))
                {
                    if (Path.GetExtension(filepath) == ".jar")
                    {
                        writer.Write(Path.GetFileName(filepath) + ",");
                    }
                }

        } // end OutputModFilenames

        /// <summary>
        /// Returns version number of latest version of modpack
        /// </summary>
        private static string GetLatestVersion()
        {
            try
            {
                string str = string.Empty;
                using (WebClient wc = new WebClient())
                {
                    byte[] raw = wc.DownloadData("https://raw.githubusercontent.com/oinkratpig/VirixUpdater/master/Mods/virix_version.txt");
                    str = Encoding.Default.GetString(raw);
                }
                return str;
            }
            catch (Exception)
            {
                return defaultVersion;
            }

        } // end ReadFileWeb

        /// <summary>
        /// Returns version number of currently-installed version of modpack
        /// </summary>
        private static string GetCurrentVersion()
        {
            string path = Path.Join(ModsFolder, "virix_version.txt");
            if (!File.Exists(path)) return "?.?";

            using (StreamReader reader = new StreamReader(path))
                return reader.ReadToEnd();

        } // end GetInstalledVersion

    } // end class Modpack

} // end namespace