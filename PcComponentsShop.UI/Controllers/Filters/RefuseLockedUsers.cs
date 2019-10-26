using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using PcComponentsShop.UI.Controllers;
using System.Web.Mvc.Filters;

namespace PcComponentsShop.UI.Controllers.Filters
{
    public class RefuseLockedUsers : FilterAttribute, IAuthenticationFilter
    {

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {

        }

        public void OnAuthentication(AuthenticationContext filterContext)
        { 
            if (filterContext.HttpContext.Request.IsAuthenticated && Roles.IsUserInRole("Users") && filterContext.HttpContext.GetOwinContext().GetUserManager<AppUserManager>().IsLockedOut(filterContext.HttpContext.User.Identity.GetUserId()))
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary {
                    {"action",  "BlockInformation"},
                    {"controller", "Account"},
                    {"userId", filterContext.HttpContext.User.Identity.GetUserId() }
                });
        }
    }
}