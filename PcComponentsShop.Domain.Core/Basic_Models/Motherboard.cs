using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class Motherboard : Good
    {
        [Required]
        public string Socket { get; set; }
        [Required]
        public string Chipset { get; set; }
        [Required]
        public string MemorySlots { get; set; }
        [Required]
        public string FormFactor { get; set; }
        [Required]
        public string VideoInterfaces { get; set; }
    }
}
