using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PcComponentsShop.Infrastructure.Business.Basic_Models
{
    public enum OrderStatus
    {
        Registered,
        Paid,
        Finished,
        Canceled
    }
    public class Order
    {
        public int OrderId { get; set; }
        [Required]
        [StringLength(maximumLength:10, MinimumLength = 4)]
        public string OrderStatus { get; set; }
        [Required]
        [StringLength(maximumLength:255, MinimumLength = 5)]
        public string FullGoodName { get; set; }
        [Required]
        public int GoodId { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [Range(minimum: 1, maximum: int.MaxValue)]
        public int GoodAmount { get; set; }
        [Required]
        public string GoodCategory { get; set; }
        [Required]
        public int GoodPrice { get; set; }
        [Required]
        public string GoodImgSrc { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? PaidAt { get; set; }
    }
}
