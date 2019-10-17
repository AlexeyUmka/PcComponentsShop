using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;

namespace PcComponentsShop.UI.Helpers
{
    public static class IdentityHelpers
    {
        public static MvcHtmlString GetUserName(this HtmlHelper html, string id)
        {
            AppUserManager mgr = HttpContext.Current
                .GetOwinContext().GetUserManager<AppUserManager>();

            return new MvcHtmlString(mgr.FindByIdAsync(id).Result.UserName);
        }
    }
}