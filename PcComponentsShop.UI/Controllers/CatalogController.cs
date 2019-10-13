using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PcComponentsShop.Infrastructure.Data.Units;
using PcComponentsShop.Domain.Core.Basic_Models;
using PcComponentsShop.UI.Models.Pagination;
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
        public ActionResult ComputerCases(int page=1, int pageSize = 20)
        {
            return View(CatalogViewModel<ComputerCase>.GetCatalogViewModel(page, pageSize, componentsUnit.ComputerСases.GetAll()));
        }
        [HttpGet]
        public ActionResult MemoryModules(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<MemoryModule>.GetCatalogViewModel(page, pageSize, componentsUnit.MemoryModules.GetAll()));
        }
        [HttpGet]
        public ActionResult Motherboards(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<Motherboard>.GetCatalogViewModel(page, pageSize, componentsUnit.Motherboards.GetAll()));
        }
        [HttpGet]
        public ActionResult PowerSupplies(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<PowerSupply>.GetCatalogViewModel(page, pageSize, componentsUnit.PowerSupplies.GetAll()));
        }
        [HttpGet]
        public ActionResult Processors(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<Processor>.GetCatalogViewModel(page, pageSize, componentsUnit.Processors.GetAll()));
        }
        [HttpGet]
        public ActionResult SSDDrives(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<SSDDrive>.GetCatalogViewModel(page, pageSize, componentsUnit.SSDDrives.GetAll()));
        }
        [HttpGet]
        public ActionResult VideoCards(int page = 1, int pageSize = 20)
        {
            return View(CatalogViewModel<VideoCard>.GetCatalogViewModel(page, pageSize, componentsUnit.VideoCards.GetAll()));
        }
    }
}