using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.Owin;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Domain.Core.Basic_Models.RegistrationSystemModels;
using PcComponentsShop.Infrastructure.Business.Basic_Models;
using PcComponentsShop.Infrastructure.Data.RegistrationSystemManagment;
using PcComponentsShop.Infrastructure.Data.Units;
using PcComponentsShop.Infrastructure.Business.ActionValidators;
using PcComponentsShop.Infrastructure.Business.Basic_Actions;

namespace PcComponentsShop.UI.Controllers
{
    public class HomeController : Controller
    {
        public PcComponentsUnit pcComponentsUnit;

        public HomeController()
        {
            pcComponentsUnit = new PcComponentsUnit();
        }

        public ActionResult Index()
        {
            return View();
        }
        [Authorize(Roles = "Administrators, Users")]
        public ActionResult Orders()
        {
            return View(pcComponentsUnit.Orders.GetAll().Where(o => o.UserName == User.Identity.Name));

        }

        [Authorize(Roles = "Administrators, Users")]
        public ActionResult CreateRegisteredOrder(int[] goodId, string[] category, int[] goodAmount, string ids=null, string ctgrs=null)
        {
            if(!string.IsNullOrEmpty(ids) && !string.IsNullOrEmpty(ctgrs))
            {
                goodId = Array.ConvertAll(ids.Split(','), int.Parse);
                category = ctgrs.Split(',');
            }

            if(goodAmount==null)
                goodAmount = new int[] { 1};

            int i = 0;
            OrderValidators.UserName = User.Identity.Name;
            while (i < goodId.Length && i < category.Length)// && i < goodAmount.Length
            {
                OrderValidators.AllGoods = pcComponentsUnit.GetGoodsDependsOnCategory(category[i]);

                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                string findItem = string.Format($"{goodId[i]},{category[i]}+");

                if (cookieReq != null && cookieReq["ShoppingBasket"].Contains(findItem))
                {
                    Order order = OrdersManipulator.CreateAndReturnNewOrder(
                        User.Identity.Name,
                        pcComponentsUnit.GetGoodsDependsOnCategory(category[i]).FirstOrDefault(g => g.ID == goodId[i]),
                        OrderValidators.IsValidOrder);//goodAmount: goodAmount[i]
                    if (order != null)
                    {
                        pcComponentsUnit.Orders.Create(order);
                        pcComponentsUnit.Save();
                        cookieReq["ShoppingBasket"] = cookieReq["ShoppingBasket"].Replace(findItem, "");
                        Response.Cookies.Add(cookieReq);
                    }
                }
                i++;
            }
            return View("Orders", pcComponentsUnit.Orders.GetAll().Where(o => o.UserName == User.Identity.Name));
        }

        public ActionResult ShopBasket()
        {
            HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
            ShoppingBasket shoppingBasket = new ShoppingBasket();

            List<Good> goods = new List<Good>();
            if (cookieReq == null)
            {
                HttpCookie cookie = new HttpCookie("ShoppingBasket");
                cookie.Expires = DateTime.Now.AddMonths(6);
                Response.Cookies.Add(cookie);
            }
            else
            {
                shoppingBasket = ShoppingBasket.ReadFromCookie(cookieReq["ShoppingBasket"]);
                foreach (Good g in shoppingBasket.Goods)
                {
                    Good el = pcComponentsUnit.GetGoodsDependsOnCategory(g.Category).FirstOrDefault(e => e.ID == g.ID);
                    if (el != null)
                        goods.Add(el);
                }
            }
            return View(goods);
        }
        [HttpPost]
        public ActionResult ShopBasket(int id, string category, string actionName, string controllerName, bool removeSelected = false, bool buySelected = false, string[] selectedGoods = null, int page = 1, bool isRemoveFromBasket = false)
        {
            if (!isRemoveFromBasket && !removeSelected && !buySelected)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq == null)
                {
                    cookieReq = new HttpCookie("ShoppingBasket");
                    cookieReq.Expires = DateTime.Now.AddMonths(6);
                }
                ShoppingBasket shoppingBasket = new ShoppingBasket() { Goods = { new Good() { ID = id, Category = category } } };
                cookieReq["ShoppingBasket"] += shoppingBasket.ToString();
                Response.Cookies.Add(cookieReq);
            }
            else if (removeSelected)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq != null)
                {
                    if (selectedGoods != null)
                    {
                        string newCookie = cookieReq["ShoppingBasket"];
                        foreach (string s in selectedGoods)
                            newCookie = newCookie.Replace(s, "");
                        cookieReq["ShoppingBasket"] = newCookie;
                        Response.Cookies.Add(cookieReq);
                    }
                }
            }
            else if (isRemoveFromBasket)
            {
                HttpCookie cookieReq = Request.Cookies["ShoppingBasket"];
                if (cookieReq != null)
                {
                    string newCookie = cookieReq["ShoppingBasket"].Replace(string.Format($"{id},{category}+"), "");
                    cookieReq["ShoppingBasket"] = newCookie;
                    Response.Cookies.Add(cookieReq);
                }
            }
            else if (buySelected)
            {
                ShoppingBasket sb = ShoppingBasket.ReadFromCookie(string.Join("", selectedGoods));
                string ids = string.Join(",",sb.Goods.Select(g => g.ID.ToString()));
                string ctgrs = string.Join(",",sb.Goods.Select(g => g.Category));
                return RedirectToActionPermanent("CreateRegisteredOrder", new { ids, ctgrs});
            }
            if (string.IsNullOrEmpty(actionName) || string.IsNullOrEmpty(controllerName))
                return RedirectToActionPermanent("ComponentsCatalog", "Catalog", new { category, page });
            else
                return RedirectToActionPermanent(actionName, controllerName);
        }

    }
}