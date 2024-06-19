using DataAnalyzer_ver0._1.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data
{
    public class FT232DataReader
    {
        private readonly FT232Helper _ft232Helper;

        public FT232DataReader(FT232Helper ft232Helper)
        {
            _ft232Helper = ft232Helper;
        }
        public byte[] ReadDataFromFT232(uint bufferSize)
        {
            return _ft232Helper.ReadDataFromFT232(bufferSize);
        }

        public byte[] ReadGeneratedMockData(int dataSize)
        {
            return _ft232Helper.GenerateMockDataFromFT232(dataSize);
        }
    }
}
