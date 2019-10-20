using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcComponentsShop.Infrastructure.Data.Units;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.Infrastructure.Data.Filters;
using PcComponentsShop.UI.Models;

namespace PcComponentsShop.UI.Controllers
{
    public class CatalogController : Controller
    {
        PcComponentsUnit componentsUnit;
        public CatalogController()
        {
            componentsUnit = new PcComponentsUnit();
        }
        [HttpGet]
        public ActionResult ComponentsCatalog(string[] Brands, string returnUrl, CommonSort SortByIncreaseName = CommonSort.Нет, CommonSort SortByIncreasePrice = CommonSort.Нет, string category = "Процессоры", int? minPrice = null, int? maxPrice = null, int page = 1, int pageSize = 20)
        {
            ViewBag.returnUrl = returnUrl;

            if (Session["CurrentFilter"] == null || ((PcComponentsFilter)Session["CurrentFilter"]).Category != category)
                Session["CurrentFilter"] = new PcComponentsFilter();

            PcComponentsFilter curFilter = new PcComponentsFilter { SortByIncreaseName = SortByIncreaseName, SortByIncreasePrice = SortByIncreasePrice, MinPrice = minPrice, MaxPrice = maxPrice, Brands = Brands, Category=category};

            if (curFilter.ValidateInputParameters())
                Session["CurrentFilter"] = curFilter;
            else
                ModelState.AddModelError("CatalogViewModel", curFilter.ErrorMessage);

            IEnumerable<Good> allGoods = componentsUnit.GetGoodsDependsOnCategory(category) ?? new List<Good>();

            IEnumerable<Good> filteredGoods = componentsUnit.GetGoodsDependsOnFilter(category,(PcComponentsFilter)Session["CurrentFilter"]) ?? new List<Good>();

            if(allGoods != null && filteredGoods != null)
                return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, filteredGoods, allGoods, category));
            return new HttpNotFoundResult();
        }
    }
}