using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcComponentsShop.Infrastructure.Data.Units;

namespace PcComponentsShop.UI.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        PcComponentsUnit PcComponentsUnit;
        public HomeController()
        {
            PcComponentsUnit = new PcComponentsUnit();
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}