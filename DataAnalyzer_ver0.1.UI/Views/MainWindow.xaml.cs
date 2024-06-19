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

            var dataAnalyzerService = new USBDataAnalyzerService();
            var dataProcessorService = new USBDataProcessorService();
            var dataReaderService = new USBDataReaderService();

            DataContext = new MainViewModel(dataAnalyzerService, dataProcessorService, dataReaderService);
        }
    }
}