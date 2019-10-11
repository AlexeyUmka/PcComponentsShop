using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class PowerSupply : Good
    {
        [Required]
        public string FormFactor { get; set; }
        [Required]
        public int Power { get; set; }
        [Required]
        public string Certification { get; set; }
        [Required]
        public string Cooling { get; set; }
        [Required]
        public string Features { get; set; }
    }
}
