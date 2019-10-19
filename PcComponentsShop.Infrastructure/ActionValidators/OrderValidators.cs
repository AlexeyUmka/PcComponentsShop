﻿using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PcComponentsShop.Infrastructure.Business.ActionValidators
{
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
