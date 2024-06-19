using DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.USBData;
using DataAnalyzer_ver0._1.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Implementations
{
    public class USBDataReaderService : IUSBDataReaderService
    {
        private readonly USBDataReader _usbDataReader;

        public USBDataReaderService()
        {
            _usbDataReader = new USBDataReader();
        }

        public async Task<byte[]> ReadDataAsync(string usbDevicePath)
        {
            return await Task.Run(() => _usbDataReader.ReadDataFromUSB(usbDevicePath));
        }

        public async Task<byte[]> ReadGeneratedMockDataAsync(int dataSize)
        {
            return await Task.Run(() => _usbDataReader.ReadGeneratedMockData(dataSize));
        }
    }
}
