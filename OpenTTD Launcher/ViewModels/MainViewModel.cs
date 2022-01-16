using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace OpenTTD_Launcher.ViewModels
{
    class MainViewModel : Screen
    {
        private string _autoLaunch;
        private string _autoClose;
        private string _exePath;
        private string _configPath;

        public string AutoLaunch
        {
            get => _autoLaunch; set
            {
                _autoLaunch = value;
                NotifyOfPropertyChange(() => AutoLaunch);
            }
        }
        public string AutoClose
        {
            get => _autoClose; set
            {
                _autoClose = value;
                NotifyOfPropertyChange(() => AutoClose);
            }
        }
        public string ExePath
        {
            get => _exePath; set
            {
                _exePath = value;
                NotifyOfPropertyChange(() => ExePath);
            }
        }
        public string ConfigPath
        {
            get => _configPath; set
            {
                _configPath = value;
                NotifyOfPropertyChange(() => ConfigPath);
            }
        }

        public MainViewModel()
        {
            ConfigPath = Properties.Settings.Default.configPath;
            ToggleAutoLaunch();
            ToggleAutoLaunch();
            ToggleAutoClose();
            ToggleAutoClose();
            ChangeExePath(Properties.Settings.Default.exePath);
            ChangeConfigPath(Properties.Settings.Default.configPath);

            if (Properties.Settings.Default.autoLauch && CanLauchGame())
            {
                if (File.Exists(Properties.Settings.Default.exePath) && File.Exists(Properties.Settings.Default.exePath))
                {
                    LaunchGame();
                }
            }
        }

        public void ToggleAutoLaunch()
        {
            Trace.WriteLine("toggleAutoLaunch pressed");
            Trace.WriteLine(AutoLaunch);
            Properties.Settings.Default.autoLauch = !Properties.Settings.Default.autoLauch;
            if (Properties.Settings.Default.autoLauch)
            {
                AutoLaunch = "Disable Auto Game Launch";
            }
            else
            {
                AutoLaunch = "Enable Auto Game Launch";
            }
        }

        public void ToggleAutoClose()
        {
            Trace.WriteLine("toggleAutoClose pressed");
            Trace.WriteLine(AutoClose);
            Properties.Settings.Default.autoClose = !Properties.Settings.Default.autoClose;
            if (Properties.Settings.Default.autoClose)
            {
                AutoClose = "Disable Auto Launcher Close";
            }
            else
            {
                AutoClose = "Enable Auto Launcher Close";
            }
        }

        public void ChangeExePath(string path)
        {
            Trace.WriteLine("ChangeExePath pressed");
            Trace.WriteLine(path);

            if (File.Exists(path))
            {
                ExePath = "Change openttd.exe path";
                Properties.Settings.Default.exePath = path;
            }
            else
            {
                ExePath = "Set openttd.exe path";
            }
        }

        public void ChangeConfigPath(string path)
        {
            Trace.WriteLine("ChangeConfigPath pressed");
            Trace.WriteLine(path);

            string screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth.ToString();
            string screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight.ToString();
            Trace.WriteLine($"resolution = {screenWidth},{screenHeight}");

            if (File.Exists(path))
            {
                string[] lines = File.ReadAllLines(path);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (lines[i].Contains("resolution"))
                    {
                        lines[i] = $"resolution = {screenWidth},{screenHeight}";
                    }
                }

                File.WriteAllLines(path, lines);
                ConfigPath = "Change openttd.cfg path";
                Properties.Settings.Default.configPath = path;
            }
            else
            {
                ConfigPath = "Set openttd.cfg path";
            }
        }

        public bool CanLauchGame() => File.Exists(Properties.Settings.Default.exePath) && File.Exists(Properties.Settings.Default.configPath);

        public void LaunchGame()
        {
            Trace.WriteLine("LaunchGame");
            Trace.WriteLine(Properties.Settings.Default.exePath);
            if (File.Exists(Properties.Settings.Default.exePath))
            {
                ProcessStartInfo info = new ProcessStartInfo(Properties.Settings.Default.exePath);
                info.UseShellExecute = false;
                Process.Start(info);


                if (Properties.Settings.Default.autoClose)
                {
                    System.Windows.Application.Current.Shutdown();
                }
            }
        }

        public void SaveData()
        {
            Trace.WriteLine("SaveData Called");
            Properties.Settings.Default.Save();
        }
    }
}
