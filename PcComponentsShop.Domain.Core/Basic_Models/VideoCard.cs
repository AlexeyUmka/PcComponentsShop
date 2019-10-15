using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class VideoCard : Good
    {
        [Required]
        public string Interface { get; set; } = "no information";
        [Required]
        public int CoreFrequency { get; set; } = 0;
        [Required]
        public int CoreFrequencyBoost { get; set; } = 0;
        [Required]
        public int MemoryFrequency { get; set; } = 0;
        [Required]
        public string Connectors { get; set; } = "no information";
    }
}
