using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Common.Utilities
{
    public class USBHelper
    {
        public static byte[] ReadFromUSB(string usbDevicePath)
        {
            try
            {
                return File.ReadAllBytes(usbDevicePath);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Failed to read from USB", ex);
            }
            
        }
    }
}
