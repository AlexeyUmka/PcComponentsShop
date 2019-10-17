using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;
using PcComponentsShop.Infrastructure.Data.Units;

namespace PcComponentsShop.UI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        
    }
}