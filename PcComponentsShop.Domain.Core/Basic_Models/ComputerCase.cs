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
        public string CaseType { get; set; } = "no information";
        [Required]
        public string FormFactor { get; set; } = "no information";
        [Required]
        public string PowerSupply { get; set; } = "no information";
        [Required]
        public string Features { get; set; } = "no information";
        [Required]
        public int MaxCpuCoolerHeight { get; set; } = 0;
        [Required]
        public int MaxVideoCardLength { get; set; } = 0;
    }
}
