using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Interfaces
{
    public interface IDataReaderService
    {
        Task<byte[]> ReadDataAsync(string usbDevicePath);

        Task<byte[]> ReadGeneratedMockDataAsync(int dataSize);
        
    }
}
