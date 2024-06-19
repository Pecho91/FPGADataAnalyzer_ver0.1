using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.USBData;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Implementations
{
    public class USBDataProcessorService : IUSBDataProcessorService
    {
        private readonly USBDataProcessor _usbDataProcessor;

        public USBDataProcessorService()
        {
            _usbDataProcessor = new USBDataProcessor();
        }
        public async Task<USBProcessedDataModel> ProcessedDataAsync(byte[] rawData)
        {
            return await Task.Run(() => _usbDataProcessor.ProcessRawData(rawData));
        }
    }
}
