using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.Data;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Implementations
{
    public class DataReaderService : IDataReaderService
    {
        private readonly DataReader _dataReader;

        public DataReaderService()
        {
            _dataReader = new DataReader();
        }

        public async Task<byte[]> ReadDataAsync(string usbDevicePath)
        {
            return await Task.Run(() => _dataReader.ReadDataFromUSB(usbDevicePath));
        }
    }
}
