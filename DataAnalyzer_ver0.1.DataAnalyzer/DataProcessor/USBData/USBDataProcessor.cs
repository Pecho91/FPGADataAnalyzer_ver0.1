using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.USBData
{
    public class USBDataProcessor
    {
        public USBProcessedDataModel ProcessRawUSBData(byte[] rawData)
        {

            double[] voltageLevels = new double[rawData.Length];

            for (int i = 0; i < rawData.Length; i++)
            {
                voltageLevels[i] = rawData[i]; //example conversion
            }

            return new USBProcessedDataModel
            {
                VoltageLevels = voltageLevels,
                SamplingRate = 1000 //example sampling rate
            };
        }
    }
}
