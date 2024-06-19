using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.FT232Interfaces
{
    public interface IFT232DataProcessorService
    {
        Task<FT232ProcessedDataModel> ProcessedDataAsync(byte[] rawData);
    }
}
