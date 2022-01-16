using Microsoft.Win32;
using OpenTTD_Launcher.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OpenTTD_Launcher.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
        }

        private void exePath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "openttd.exe file (openttd.exe)|openttd.exe";
            if (openFileDialog.ShowDialog() == true)
            {
                MainViewModel viewModel = DataContext as MainViewModel;
                viewModel.ChangeExePath(openFileDialog.FileName);
            }
        }

        private void configPath_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "openttd.cfg file (openttd.cfg)|openttd.cfg";
            if (openFileDialog.ShowDialog() == true)
            {
                MainViewModel viewModel = DataContext as MainViewModel;
                viewModel.ChangeConfigPath(openFileDialog.FileName);
            }
        }

        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MainViewModel viewModel = DataContext as MainViewModel;
            viewModel.SaveData();
        }
    }
}
