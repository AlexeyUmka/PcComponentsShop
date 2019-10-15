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
        public string Microarchitecture { get; set; } = "no information";
        [Required]
        public string Kernel { get; set; }= "no information";
        [Required]
        public string Socket { get; set; }= "no information";
        [Required]
        public float Frequency { get; set; } = 0;
        [Required]
        public int CoreAmount { get; set; } = 0;
        [Required]
        public string GraphicsCore { get; set; }= "no information";
       
    }
}
