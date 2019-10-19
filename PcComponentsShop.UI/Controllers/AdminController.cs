using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using PcComponentsShop.Infrastructure.Data.Contexts;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;

namespace PcComponentsShop.UI.Controllers
{
    [Authorize(Roles = "Administrators")]
    public class AdminController : Controller
    {
        public string DangerRoleName { get; } = "Administrators";

        public ActionResult Index()
        {
            ViewBag.DangerRoleId = GetDangerRoleId(RoleManager.Roles);
            return View(UserManager.Users);
        }
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.Name, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    AddErrorsFromResult(result);
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            
            if (user != null && !IsTryToDeleteAdmin(user))
            {
                IdentityResult result = await UserManager.DeleteAsync(user);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    return View("Error", result.Errors);
                }
            }
            else
            {
                return View("Error", new string[] { "Пользователь не найден, либо его невозможно удалить" });
            }
        }
        public async Task<ActionResult> Edit(string id)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public async Task<ActionResult> Edit(string id, string email, string password, string userName)
        {
            AppUser user = await UserManager.FindByIdAsync(id);
            
            if (user != null)
            {
                user.Email = email;
                IdentityResult validEmail
                    = await UserManager.UserValidator.ValidateAsync(user);

                if (!validEmail.Succeeded)
                {
                    AddErrorsFromResult(validEmail);
                }

                user.UserName = userName;
                IdentityResult validName
                    = await UserManager.UserValidator.ValidateAsync(user);

                if(!validName.Succeeded)
                {
                    AddErrorsFromResult(validName);
                }

                IdentityResult validPass = null;
                if (password != string.Empty)
                {
                    validPass
                        = await UserManager.PasswordValidator.ValidateAsync(password);

                    if (validPass.Succeeded)
                    {
                        user.PasswordHash =
                            UserManager.PasswordHasher.HashPassword(password);
                    }
                    else
                    {
                        AddErrorsFromResult(validPass);
                    }
                }

                if ((validEmail.Succeeded && validPass == null && validName.Succeeded) ||
                        (validEmail.Succeeded && password != string.Empty && validPass.Succeeded && validName.Succeeded))
                {
                    IdentityResult result = await UserManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        AddErrorsFromResult(result);
                    }
                }
            }
            else
            {
                ModelState.AddModelError("", "Пользователь не найден");
            }
            return View(user);
        }

        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }
        private bool IsTryToDeleteAdmin(AppUser user)
        {
            foreach (var role in RoleManager.Roles)
                if (role.Name == DangerRoleName)
                    foreach (var u in role.Users)
                        if (u.UserId == user.Id)
                            return true;
            return false;
        }
        private string GetDangerRoleId(IEnumerable<AppRole> roles)
        {
            foreach (var role in roles)
                if (role.Name == DangerRoleName)
                    return role.Id;
            return "";
        }
        private AppUserManager UserManager => HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
        private AppRoleManager RoleManager => HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
    }
}