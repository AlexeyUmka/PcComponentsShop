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

namespace PcComponentsShop.UI.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return View("Error", new string[] { "У вас недостаточно прав для выполнения данной операции" });
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel details, string returnUrl)
        {
            AppUser user = await UserManager.FindAsync(details.Name, details.Password);
            AppUser currUser = UserManager.Users.FirstOrDefault(u => u.UserName == details.Name);
            if ((user == null) || (currUser != null && UserManager.IsLockedOut(currUser.Id)))
            {
                if (currUser != null)
                {
                    currUser.LockoutEnabled = true;

                    if (UserManager.IsLockedOut(currUser.Id))
                    {
                        ModelState.AddModelError("", $"Ваш аккаунт заблокирован в целях безопасноти, до {currUser.LockoutEndDateUtc.Value}");
                        UserManager.ResetAccessFailedCount(currUser.Id);
                    }
                    else if (UserManager.MaxFailedAccessAttemptsBeforeLockout <= currUser.AccessFailedCount+1)
                    {
                        currUser.LockoutEndDateUtc = DateTime.UtcNow.AddMinutes(1);
                        await UserManager.UpdateAsync(currUser);
                        UserManager.ResetAccessFailedCount(currUser.Id);
                        ModelState.AddModelError("", $"Ваш аккаунт заблокирован в целях безопасноти, до {currUser.LockoutEndDateUtc.Value}");
                    }
                    else
                    {
                        UserManager.AccessFailed(currUser.Id);
                        ModelState.AddModelError("", $"Некорректный пароль осталось {UserManager.MaxFailedAccessAttemptsBeforeLockout - UserManager.GetAccessFailedCount(currUser.Id)} попытки.");
                    }
                }
                else
                    ModelState.AddModelError("", "Некорректное имя.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);
                await UserManager.ResetAccessFailedCountAsync(user.Id);
                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties
                {
                    IsPersistent = true
                }, ident);
                if (!string.IsNullOrEmpty(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToActionPermanent("Index", "Home");
            }
            return View(details);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogOff()
        {
            AuthManager.SignOut(DefaultAuthenticationTypes.ApplicationCookie);
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    UserManager.AddToRole(user.Id, "Users");
                    return View("SuccessfulRegistration", model);
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View();
        }

        private IAuthenticationManager AuthManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }

        private AppUserManager UserManager
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
            }
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
    }
}