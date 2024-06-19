using DataAnalyzer_ver0._1.Common.Models;
using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.UI.RelayCommands;
using DataAnalyzer_ver0._1.Services.Interfaces;
using OxyPlot;
using OxyPlot.Series;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DataAnalyzer_ver0._1.Services.Simulation;

namespace DataAnalyzer_ver0._1.UI.ViewModels
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
                UpdatePlot(FPGAData.ProcessedData.VoltageLevels);
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
            get => _averageVoltage;
            set
            {
                _averageVoltage = value;
                OnPropertyChanged(nameof(AverageVoltage));
            }
        }

        private PlotModel _plotModel;
        public PlotModel PlotModel
        {
            get => _plotModel;
            set
            {
                _plotModel = value;
                OnPropertyChanged(nameof(PlotModel));
            }
        }
        public ICommand StartDataAcquisitionCommand { get; set; }

        public MainViewModel(IDataAnalyzerService dataAnalyzerService, IDataProcessorService processorService, IDataReaderService readerService)
        {
            _dataAnalyzerService = dataAnalyzerService;
            _dataProcessorService = processorService;
            _dataReaderService = readerService;

            StartDataAcquisitionCommand = new RelayCommand(async () => await StartDataAcquisition());

            PlotModel = new PlotModel { Title = "Oscilloscope" };
            var lineSeries = new LineSeries { Title = "Voltage" };
            PlotModel.Series.Add(lineSeries);

        }

        private async Task StartDataAcquisition()
        {
            //const string usbPath = "Path_to_your_usb_device";

            //int dataSize = 500;
            //double amplitude = 1.0;
            //double frequency = 10.0;
            //double samplingRate = 1000;
            //double duration = dataSize / samplingRate;

            try
            {
                //double[] waveform = SinusoidalDataGenerator.GenerateSinusoidalWaveform(amplitude, frequency, samplingRate, duration);
                //byte[] rawData = await DataAcquisitionSimulator.SimulateDataAcquisition(waveform);

                //byte[] rawData = await _dataReaderService.ReadGeneratedMockDataAsync(dataSize);
                var processedData = await _dataProcessorService.ProcessedDataAsync(rawData);
                var analysisResult = await _dataAnalyzerService.AnalyzeDataAsync(processedData);

                FPGAData = new FPGADataModel
                {
                    RawData = rawData,
                    ProcessedData = processedData
                };

                PeakVoltage = analysisResult.PeakVoltage;
                AverageVoltage = analysisResult.AverageVoltage;

                UpdatePlot(processedData.VoltageLevels);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void UpdatePlot(double[] voltageLevels)
        {
            if(voltageLevels != null)
            {
                var lineSeries = (LineSeries)PlotModel.Series[0];
                lineSeries.Points.Clear();

                for(int i = 0; i < voltageLevels.Length; i++)
                {
                    lineSeries.Points.Add(new DataPoint(i, voltageLevels[i]));
                }

                PlotModel.InvalidatePlot(true);
            }
        }
    }
}
