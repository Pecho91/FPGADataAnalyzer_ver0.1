using DataAnalyzer_ver0._1.Common.Utilities;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data;
using DataAnalyzer_ver0._1.Services.FT232Implementations;
using DataAnalyzer_ver0._1.Services.Implementations;
using DataAnalyzer_ver0._1.UI.ViewModels;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DataAnalyzer_ver0._1.UI.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //IntPtr ftHandle = // Obtain your FT232 handle here

            IntPtr ftHandle = (IntPtr)100;
            //var ft232Helper = new FT232Helper((IntPtr)ftHandle);
            var ft232DataReaderService = new FT232DataReaderService(ftHandle);
            var ft232DataProcessorService = new FT232DataProcessorService();

            DataContext = new MainViewModel(ft232DataReaderService, ft232DataProcessorService);
        }
    }
}