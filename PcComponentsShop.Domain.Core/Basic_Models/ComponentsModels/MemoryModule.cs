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
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int MemoryCapacity { get; set; } = 0;
        [Required]
        public string MemoryType { get; set; } = "no information";
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int OperatingFrequency { get; set; } = 0;
        [Required]
        [Range(minimum: 0.01f, maximum: float.MaxValue)]
        public float OperatingVoltage { get; set; } = 0;
        [Required]
        public string Timings { get; set; } = "no information";
    }
}
