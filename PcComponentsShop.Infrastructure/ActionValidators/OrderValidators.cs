using PcComponentsShop.Domain.Core.Basic_Models;
using System.Collections.Generic;
using System.Linq;

namespace PcComponentsShop.Infrastructure.Business.ActionValidators
{
    /// <summary>
    /// Represents a validation static class, which validate Order.
    /// !Important! Before invoke IsValidOrder you should assign a value to AllGoods and UserName
    /// </summary>
    public static class OrderValidators
    {
        public static IEnumerable<Good> AllGoods { get; set; }
        public static string UserName { get; set; }
        public static bool IsValidOrder(string userName, Good good, int goodAmount)
        {
            if (!string.IsNullOrEmpty(UserName) && userName == UserName && AllGoods != null 
                && AllGoods.Count() > 0 && AllGoods.Contains(good) && goodAmount > 0)
                return true;
            return false;
        }
    }
}
