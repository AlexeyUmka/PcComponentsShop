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
        public string Microarchitecture { get; set; }
        public string Kernel { get; set; }
        public string Socket { get; set; }
        public float Frequency { get; set; }
        public int CoreAmount { get; set; }
        public string GraphicsCore { get; set; }
       
    }
}
