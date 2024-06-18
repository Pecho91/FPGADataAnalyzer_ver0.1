using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Services.Simulation
{
    public class SinusoidalDataGenerator
    {
        public static double[] GenerateSinusoidalWaveform(double amplitude, double frequency, double samplingRate, double duration)
        {
            int numSamples = (int)(duration * samplingRate);
            double[] waveform = new double[numSamples];

            double timeIncrement = 1.0 / samplingRate;
            double angularFrequency = 2 * Math.PI * frequency;

            for (int i = 0; i < numSamples; i++)
            {
                double time = i * timeIncrement;
                waveform[i] = amplitude * Math.Sin(angularFrequency * time);
            }

            return waveform;
        }
    }
}
