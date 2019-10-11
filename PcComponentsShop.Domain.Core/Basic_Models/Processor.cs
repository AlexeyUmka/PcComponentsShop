using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class Processor : Good
    {
        [Required]
        public string Microarchitecture { get; set; }
        [Required]
        public string Kernel { get; set; }
        [Required]
        public string Socket { get; set; }
        [Required]
        public float Frequency { get; set; }
        [Required]
        public int CoreAmount { get; set; }
        [Required]
        public string GraphicsCore { get; set; }
    }
}
