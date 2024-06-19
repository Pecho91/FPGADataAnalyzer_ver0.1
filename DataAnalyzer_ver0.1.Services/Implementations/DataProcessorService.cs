﻿using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.USBData;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Implementations
{
    public class DataProcessorService : IDataProcessorService
    {
        private readonly USBDataProcessor _dataProcessor;

        public DataProcessorService()
        {
            _dataProcessor = new DataProcessor();
        }
        public async Task<USBProcessedData> ProcessedDataAsync(byte[] rawData)
        {
            return await Task.Run(() => _dataProcessor.ProcessRawData(rawData));
        }
    }
}
