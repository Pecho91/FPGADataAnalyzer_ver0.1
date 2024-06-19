using DataAnalyzer_ver0._1.Common.Processing;
using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.Analysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Interfaces
{
    public interface IUSBDataAnalyzerService
    {
        Task<USBAnalysisResult> AnalyzeDataAsync(USBProcessedDataModel usbProcessedData);
    }
}
