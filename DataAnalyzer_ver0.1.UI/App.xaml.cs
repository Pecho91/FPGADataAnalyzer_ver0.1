using DataAnalyzer_ver0._1.Common.Utilities;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data;
using DataAnalyzer_ver0._1.Services.FT232Implementations;
using DataAnalyzer_ver0._1.UI.ViewModels;
using DataAnalyzer_ver0._1.UI.Views;
using System.Configuration;
using System.Data;
using System.Windows;

namespace DataAnalyzer_ver0._1.UI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        // USB
        //protected override void OnStartup(StartupEventArgs e)
        //{
 
        //    base.OnStartup(e);

        //   var oscilloscopeWindow = new OscilloscopeWindow();
        //   oscilloscopeWindow.Show();
        //}

        // FT232
        protected override void OnStartup(StartupEventArgs e)
        {
            

            base.OnStartup(e);
         
            IntPtr ftHandle = IntPtr.Zero;

            var ft232DataReaderService = new FT232DataReaderService(ftHandle);
            var ft232DataProcessorService = new FT232DataProcessorService();


            var mainViewModel = new MainViewModel(ft232DataReaderService, ft232DataProcessorService);

            // Create and show the main window
            var mainWindow = new MainWindow
            {
                DataContext = mainViewModel
            };
            mainWindow.Show();
        }

    }

}
