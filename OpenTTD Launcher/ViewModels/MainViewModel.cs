using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenTTD_Launcher.ViewModels
{
    class MainViewModel : Screen
    {
        private bool _autoLauch;
        private bool _autoClose;
        private string _exePath;
        private string _configPath;

        public bool AutoLauch { get => _autoLauch; set => _autoLauch = value; }
        public bool AutoClose { get => _autoClose; set => _autoClose = value; }
        public string ExePath { get => _exePath; set => _exePath = value; }
        public string ConfigPath { get => _configPath; set => _configPath = value; }

        public MainViewModel()
        {


        }


    }
}
