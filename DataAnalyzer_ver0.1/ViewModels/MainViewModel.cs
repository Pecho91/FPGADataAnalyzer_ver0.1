using DataAnalyzer_ver0._1.Common.Models;
using DataAnalyzer_ver0._1.RelayCommands;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAnalyzer_ver0._1.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly IDataAnalyzerService _dataAnalyzerService;
        private readonly IDataProcessorService _processorService;
        private readonly IDataReaderService _readerService;

        private FPGADataModel _fpgaData;
        public FPGADataModel FPGAData
        {
            get => _fpgaData;
            set
            {
                _fpgaData = value;
                OnPropertyChanged(nameof(FPGAData));
            }
        }

        public ICommand StartDataAcquisitionCommand { get; set; }

        public MainViewModel(IDataAnalyzerService dataAnalyzerService, IDataProcessorService processorService, IDataReaderService readerService)
        {
            _dataAnalyzerService = dataAnalyzerService;
            _processorService = processorService;
            _readerService = readerService;

            StartDataAcquisitionCommand = new RelayCommand(async () => await StartDataAcquisition());
           
        }

        private async Task StartDataAcquisition()
        {

        }
    }
}
