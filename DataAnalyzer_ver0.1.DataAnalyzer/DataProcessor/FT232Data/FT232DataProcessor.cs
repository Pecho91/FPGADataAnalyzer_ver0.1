using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.FT232Data
{
    public class FT232DataProcessor
    {
        public FT232ProcessedDataModel ProcessRawFT232Data(byte[] rawData)
        {
            bool[] booleanLevels = rawData.Select(b => b > 0).ToArray();

            return new FT232ProcessedDataModel
            {
                BooleanLevels = booleanLevels
            };
        }
    }
}

