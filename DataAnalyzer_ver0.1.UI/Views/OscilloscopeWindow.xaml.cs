using DataAnalyzer_ver0._1.Services.Implementations;
using DataAnalyzer_ver0._1.UI.ViewModels;
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

namespace DataAnalyzer_ver0._1.UI.Views
{
    /// <summary>
    /// Interaction logic for OscilloscopeWindow.xaml
    /// </summary>
    public partial class OscilloscopeWindow : Window
    {
        public OscilloscopeWindow()
        {
            InitializeComponent();

            //var dataAnalyzerService = new DataAnalyzerService();
            var dataProcessorService = new USBDataProcessorService();
            var dataReaderService = new USBDataReaderService();

            DataContext = new OsciloscopeViewModel(dataAnalyzerService, dataProcessorService, dataReaderService);
        }
    }
}
