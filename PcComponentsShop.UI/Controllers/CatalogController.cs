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
        public ActionResult ComponentsCatalog(string[] Brands, CommonSort SortByIncreaseName = CommonSort.Нет, CommonSort SortByIncreasePrice = CommonSort.Нет, string category = "Процессоры", int? minPrice = null, int? maxPrice = null, int page = 1, int pageSize = 20)
        {
            if (Session["CurrentFilter"] == null || ((PcComponentsFilter)Session["CurrentFilter"]).Category != category)
                Session["CurrentFilter"] = new PcComponentsFilter();
            PcComponentsFilter curFilter = new PcComponentsFilter { SortByIncreaseName = SortByIncreaseName, SortByIncreasePrice = SortByIncreasePrice, MinPrice = minPrice, MaxPrice = maxPrice, Brands = Brands, Category=category};
            if (curFilter.ValidateInputParameters())
                Session["CurrentFilter"] = curFilter;
            else
                ModelState.AddModelError("CatalogViewModel", curFilter.ErrorMessage);
            switch (category)
            {
                case "Процессоры":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.Processors.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.Processors.GetAll(), category));
                case "Материнские платы":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.Motherboards.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.Motherboards.GetAll(), category));
                case "Видеокарты":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.VideoCards.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.VideoCards.GetAll(), category));
                case "Корпуса":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.ComputerСases.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.ComputerСases.GetAll(), category));
                case "Оперативная память":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.MemoryModules.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.MemoryModules.GetAll(), category));
                case "Блоки питания":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.PowerSupplies.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.PowerSupplies.GetAll(), category));
                case "SSD диски":
                    return View(CatalogViewModel<Good>.GetCatalogViewModel(page, pageSize, componentsUnit.SSDDrives.GetAll((PcComponentsFilter)Session["CurrentFilter"]), componentsUnit.SSDDrives.GetAll(), category));
                default:
                    return new HttpNotFoundResult();
            }
        }
    }
}