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
        
        public string FormFactor { get; set; }
       
        public int Power { get; set; }
        
        public string Certification { get; set; }
        
        public string Cooling { get; set; }
        
        public string Features { get; set; }
    }
}
