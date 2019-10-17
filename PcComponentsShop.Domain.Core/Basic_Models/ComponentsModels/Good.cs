using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Domain.Core.Basic_Models
{
    public class Good
    {
        [Key]
        public virtual int ID { get; set; }
        [Required]
        public virtual string FullName { get; set; }
        [Required]
        public virtual int Price { get; set; }
        [Required]
        public virtual string Brand { get; set; }
        [Required]
        public virtual string Category { get; set; }
        [Required]
        public virtual string ImgSrc { get; set; }
        public virtual DateTime ProducedAt { get; set; }
    }
}
