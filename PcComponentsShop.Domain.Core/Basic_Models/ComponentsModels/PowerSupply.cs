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
        public string FormFactor { get; set; } = "no information";
        [Required]
        public int Power { get; set; }= 0;
        [Required]
        public string Certification { get; set; }= "no information";
        [Required]
        public string Cooling { get; set; }= "no information";
        [Required]
        public string Features { get; set; }= "no information";
    }
}
