﻿using DataAnalyzer_ver0._1.Common.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.DataAnalyzer.DataProcessor.USBData
{
    public class USBDataReader
    {
        public byte[] ReadDataFromUSB(string usbDevicePath)
        {
            return USBHelper.ReadFromUSB(usbDevicePath);
        }

        public byte[] ReadGeneratedMockData(int dataSize)
        {
            return USBHelper.GenerateMockDataFromUSB(dataSize);
        }
    }
}
