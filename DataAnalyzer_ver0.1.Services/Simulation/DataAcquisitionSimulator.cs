using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Simulation
{
    public class DataAcquisitionSimulator
    {
        public static async Task<byte[]> SimulateDataAcquisition(double[] waveform)
        {
            // Convert waveform to byte array (assuming 8-bit resolution)
            byte[] rawData = new byte[waveform.Length];
            for (int i = 0; i < waveform.Length; i++)
            {
                // Scale the waveform to fit within the 8-bit range
                rawData[i] = (byte)((waveform[i] + 1) * 127.5);
            }

            // Simulate asynchronous data acquisition process
            await Task.Delay(1000); // Simulate delay for data acquisition

            return rawData;
        }
    }
}
