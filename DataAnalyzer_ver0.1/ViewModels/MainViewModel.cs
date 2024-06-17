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
        private readonly IDataProcessorService _dataProcessorService;
        private readonly IDataReaderService _dataReaderService;

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
            _dataProcessorService = processorService;
            _dataReaderService = readerService;

            StartDataAcquisitionCommand = new RelayCommand(async () => await StartDataAcquisition());
           
        }

        private async Task StartDataAcquisition()
        {
            const string usbPath = "Path_to_your_usb_device";

            try
            {
                byte[] rawData = await _dataReaderService.ReadDataAsync(usbPath);
                var processedData = await _dataProcessorService.ProcessedDataAsync(rawData);
                var analysisResult = await _dataAnalyzerService.AnalyzeDataAsync(processedData);

                FPGAData = new FPGADataModel
                {
                    RawData = rawData,
                    ProcessedData = processedData
                };

                //Update UI
                PeakVoltage = analysisResult.PeakVoltage;
                AverageVoltage = analysisResult.AverageVoltage;
            }
            catch (Exception ex)
            {
                //handle exception
            }
        }

        private double _peakVoltage;
        public double PeakVoltage
        {
            get => _peakVoltage;
            set
            {
                _peakVoltage = value;
                OnPropertyChanged(nameof(PeakVoltage));
            }
        }

        private double _averageVoltage;
        public double AverageVoltage
        {
            get => _peakVoltage;
            set
            {
                _peakVoltage = value;
                OnPropertyChanged(nameof(AverageVoltage));
            }
        }
    }
}
