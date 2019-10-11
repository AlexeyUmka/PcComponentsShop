using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class ComputerCase:Good
    {
        [Required]
        public string CaseType { get; set; }
        [Required]
        public string FormFactor { get; set; }
        [Required]
        public bool PowerSupply { get; set; }
        [Required]
        public string Features { get; set; }
        [Required]
        public int MaxCpuCoolerHeight { get; set; }
        [Required]
        public int MaxVideoCardLength { get; set; }
    }
}
