using DataAnalyzer_ver0._1.Common.Models;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data;
using DataAnalyzer_ver0._1.Services.FT232Interfaces;
using DataAnalyzer_ver0._1.UI.RelayCommands;
using OxyPlot.Series;
using OxyPlot;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace DataAnalyzer_ver0._1.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private readonly FT232DataProcessor _dataProcessor;
        private readonly IFT232DataReaderService _dataReaderService;

        private FPGADataModel _fpgaData;
        public FPGADataModel FPGAData
        {
            get => _fpgaData;
            set
            {
                _fpgaData = value;
                OnPropertyChanged(nameof(FPGAData));
                UpdatePlot(FPGAData.ProcessedDataFT232.BooleanLevels);
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

        public MainViewModel(IFT232DataReaderService dataReaderService)
        {
            _dataProcessor = new FT232DataProcessor();
            _dataReaderService = dataReaderService;

            StartDataAcquisitionCommand = new RelayCommand(async () => await StartDataAcquisition());

            PlotModel = new PlotModel { Title = "Oscilloscope" };
            var lineSeries = new LineSeries { Title = "Boolean States" };
            PlotModel.Series.Add(lineSeries);
        }

        private async Task StartDataAcquisition()
        {
            uint bufferSize = 100; 

            try
            {
                byte[] rawData = await _dataReaderService.ReadGeneratedMockDataAsync((int)bufferSize);

                //byte[] rawData = await _dataReaderService.ReadDataAsync(bufferSize);
                var processedData = _dataProcessor.ProcessRawFT232Data(rawData);

                FPGAData = new FPGADataModel
                {
                    RawData = rawData,
                    ProcessedDataFT232 = processedData
                };

                UpdatePlot(processedData.BooleanLevels);
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        private void UpdatePlot(bool[] booleanLevels)
        {
            if (booleanLevels != null)
            {
                var lineSeries = (LineSeries)PlotModel.Series[0];
                lineSeries.Points.Clear();

                for (int i = 0; i < booleanLevels.Length; i++)
                {
                    lineSeries.Points.Add(new DataPoint(i, booleanLevels[i] ? 1 : 0));
                }

                PlotModel.InvalidatePlot(true);
            }
        }
    }
}
