using PcComponentsShop.Domain.Core.Basic_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PcComponentsShop.UI.Helpers
{
    public static class CatalogHelpers
    {
        public static bool IsGoodAlreadyInBasket(string cookie, Good g)
        {
            if (!string.IsNullOrEmpty(cookie))
            {
                StringBuilder id = new StringBuilder();
                StringBuilder category = new StringBuilder();
                bool isWriteId = true;
                foreach (char c in cookie)
                {
                    if (c != ',' && isWriteId)
                        id.AppendFormat(c.ToString());
                    else if (c == ',')
                        isWriteId = false;
                    else if (c != '+' && !isWriteId)
                        category.AppendFormat(c.ToString());
                    else
                    {
                        if (int.TryParse(id.ToString(), out int identifer) && !string.IsNullOrEmpty(category.ToString()))
                        {
                            if (g.ID == identifer && g.Category == category.ToString())
                                return true;
                        }
                        id = new StringBuilder();
                        category = new StringBuilder();
                        isWriteId = true;
                    }
                }
            }
            return false;
        }
    }
}