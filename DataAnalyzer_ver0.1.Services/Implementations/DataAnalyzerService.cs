//using DataAnalyzer_ver0._1.Common.Processing;
//using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.Analysis;
//using DataAnalyzer_ver0._1.Services.Interfaces;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DataAnalyzer_ver0._1.Services.Implementations
//{
//    public class DataAnalyzerService : IDataAnalyzerService
//    {
//        private readonly DataAnalyzerProcessor _dataAnalyzer;

//        public DataAnalyzerService()
//        {
//            _dataAnalyzer = new DataAnalyzerProcessor();
//        }

//        public async Task<AnalysisResult> AnalyzeDataAsync(ProcessedData processedData)
//        {
//            return await Task.Run(() => _dataAnalyzer.AnalyzeData(processedData));
//        }
//    }
//}
