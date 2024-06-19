using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.Analysis;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Implementations
{
    public class USBDataAnalyzerService : IUSBDataAnalyzerService
    {
        private readonly USBDataAnalyzerProcessor _usbDataAnalyzer;

        public USBDataAnalyzerService()
        {
            _usbDataAnalyzer = new USBDataAnalyzerProcessor();
        }

        public async Task<USBAnalysisResult> AnalyzeDataAsync(USBProcessedDataModel usbProcessedData)
        {
            return await Task.Run(() => _usbDataAnalyzer.AnalyzeUSBData(usbProcessedData));
        }
    }
}
