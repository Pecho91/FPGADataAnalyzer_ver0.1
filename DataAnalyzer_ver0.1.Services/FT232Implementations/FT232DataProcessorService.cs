using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data;
using DataAnalyzer_ver0._1.Services.FT232Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.FT232Implementations
{
    public class FT232DataProcessorService : IFT232DataProcessorService
    {
        private readonly FT232DataProcessor _ft232DataProcessor;

        public FT232DataProcessorService()
        {
            _ft232DataProcessor = new FT232DataProcessor();
        }
        public async Task<FT232ProcessedDataModel> ProcessedDataAsync(byte[] rawData)
        {
            return await Task.Run(() => _ft232DataProcessor.ProcessRawData(rawData));
        }
    }
}
