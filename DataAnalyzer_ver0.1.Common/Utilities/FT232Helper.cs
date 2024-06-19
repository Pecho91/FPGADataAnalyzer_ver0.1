using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Common.Utilities
{
    public class FT232Helper
    {
        //P/Invoke declaration from FT_read from FTDI D2XX driver
        [DllImport("FTD2XX.dll")]
        private static extern uint FT_Read(IntPtr ftHandle, byte[] buffer, uint bufferSize, ref uint bytesRead);

        private IntPtr _ftHandle;

        public  FT232Helper(IntPtr ftHandle)
        {
            _ftHandle = ftHandle;
        }

        public  byte[] ReadDataFromFT232(uint bufferSize) 
        {
            byte[] buffer = new byte[bufferSize];
            uint bytesRead = 0;

            FT_Read(_ftHandle, buffer, bufferSize, ref bytesRead);

            if(bytesRead != bufferSize)
            {
                throw new InvalidOperationException("Failed to read the expected amount of data from FT232");
            }

            return buffer;
        }

        public byte[] GenerateMockDataFromFT232(int dataSize)
        {
            byte[] data = new byte[dataSize];
            Random random = new Random();
            for(int i = 0; i < dataSize; i++)
            {
                data[i] = (byte)(random.Next(0, 2));
            }
            return data;
        }
    }
}
