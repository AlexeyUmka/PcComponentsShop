using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class MemoryModule : Good
    {
        [Required]
        public int MemoryCapacity { get; set; }
        [Required]
        public string MemoryType { get; set; }
        
        public int OperatingFrequency { get; set; }
        
        public float OperatingVoltage { get; set; }
        
        public string Timings { get; set; }
    }
}
