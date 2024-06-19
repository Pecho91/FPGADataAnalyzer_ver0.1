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
        public USBAnalysisResult AnalyzeData(USBProcessedDataModel processedData)
        {

            return new USBAnalysisResult
            {
                PeakVoltage = processedData.VoltageLevels.Max(),
                AverageVoltage = processedData.VoltageLevels.Average(),
            };
        }

    }
}
