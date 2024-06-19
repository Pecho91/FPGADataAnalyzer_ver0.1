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
            byte[] rawData = new byte[waveform.Length];
            for (int i = 0; i < waveform.Length; i++)
            {
                rawData[i] = (byte)((waveform[i] + 1) * 127.5);
            }

            await Task.Delay(1000);

            return rawData;
        }
    }
}
