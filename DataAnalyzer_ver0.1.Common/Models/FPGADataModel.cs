using DataAnalyzer_ver0._1.Common.Processing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAnalyzer_ver0._1.Common.Models
{
    public class FPGADataModel
    {
        public byte[] RawData { get; set; }
        public ProcessedData ProcessedData { get; set; }
    }
}
