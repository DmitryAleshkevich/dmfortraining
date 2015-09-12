using JPEGCompressionRealization.View;
using JPEGCompressionRealization.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace JPEGCompressionRealization
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            var mainWindow = new MainWindow() { DataContext = new ImageViewModel()};
            mainWindow.Show(); 
        }
    }
}
