using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.FT232Interfaces
{
    public interface IFT232DataReaderService
    {
        Task<byte[]> ReadDataAsync(uint bufferSize);

        Task<byte[]> ReadGeneratedMockDataAsync(int dataSize);
    }
}
