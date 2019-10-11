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
        public string Interface { get; set; }
        [Required]
        public int CoreFrequency { get; set; }
        [Required]
        public int CoreFrequencyBoost { get; set; }
        [Required]
        public int MemoryFrequency { get; set; }
        [Required]
        public string Connectors { get; set; }
    }
}
