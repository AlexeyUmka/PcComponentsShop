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
        public string PowerSupply { get; set; }
        public string Features { get; set; }
        public int MaxCpuCoolerHeight { get; set; }
        public int MaxVideoCardLength { get; set; }
    }
}
