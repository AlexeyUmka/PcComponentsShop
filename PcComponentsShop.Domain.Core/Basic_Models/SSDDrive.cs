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
        [Required]
        public string CellMemoryType { get; set; }
        [Required]
        public float Capacity { get; set; }
        [Required]
        public string ConnectionInterface { get; set; }
        [Required]
        public string ReadingSpeed { get; set; }
    }
}
