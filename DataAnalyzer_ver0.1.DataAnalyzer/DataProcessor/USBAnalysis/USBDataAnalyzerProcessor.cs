using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.Analysis
{
    public class USBDataAnalyzerProcessor
    {
        public USBAnalysisResult AnalyzeUSBData(USBProcessedDataModel usbProcessedData)
        {

            return new USBAnalysisResult
            {
                PeakVoltage = usbProcessedData.VoltageLevels.Max(),
                AverageVoltage = usbProcessedData.VoltageLevels.Average(),
            };
        }

    }
}
