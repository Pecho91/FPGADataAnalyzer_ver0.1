using DataAnalyzer_ver0._1.Common.Utilities;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data;
using DataAnalyzer_ver0._1.Services.FT232Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.FT232Implementations
{
    public class FT232DataReaderService : IFT232DataReaderService
    {
        private readonly FT232DataReader _ft232DataReader;

        public FT232DataReaderService(IntPtr ftHandle)
        {
            var ft232Helper = new FT232Helper(ftHandle);
            _ft232DataReader = new FT232DataReader(ft232Helper);
        }

        public async Task<byte[]> ReadDataAsync(uint bufferSize)
        {
            return await Task.Run(() => _ft232DataReader.ReadDataFromFT232(bufferSize));
        }

        public async Task<byte[]> ReadGeneratedMockDataAsync(int dataSize)
        {
            return await Task.Run(() => _ft232DataReader.ReadGeneratedMockData(dataSize));
        }
    }
}
