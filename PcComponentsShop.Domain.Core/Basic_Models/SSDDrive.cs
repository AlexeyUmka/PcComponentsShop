using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class SSDDrive : Good
    {
        public string CellMemoryType { get; set; }
        
        public string Capacity { get; set; }

        public string FormFactor { get; set; }
        
        public string ConnectionInterface { get; set; }
        
        public string ReadingSpeed { get; set; }
    }
}
