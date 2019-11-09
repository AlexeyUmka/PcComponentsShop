using PcComponentsShop.Domain.Core.Basic_Models;
using System.Text;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;
using PcComponentsShop.UI.Controllers.Filters;
using System;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
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
        public  static bool IsGoodAlreadyInWishes(Good g, string userName)
        {
            UserManager<AppUser> userManager = HttpContext.Current.GetOwinContext().GetUserManager<AppUserManager>();
            AppUser currUser = userManager.Users.FirstOrDefault(u => u.UserName == userName);
            if (currUser != null && currUser.GoodsWishes != null && currUser.GoodsWishes.Contains($"{g.ID},{g.Category}+"))
                return true;
            else
                return false;
        }
    }
}