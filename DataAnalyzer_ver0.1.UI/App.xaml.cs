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
        protected override void OnStartup(StartupEventArgs e)
        {
 
            base.OnStartup(e);

           var oscilloscopeWindow = new OscilloscopeWindow();
           oscilloscopeWindow.Show();
        }

    }

}
