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
    [Authorize(Roles = "Administrators")]
    public class OrderAdminController : Controller
    {
        PcComponentsUnit pcComponentsUnit;

        public OrderAdminController()
        {
            pcComponentsUnit = new PcComponentsUnit();
        }
        public ActionResult Orders()
        {
            return View(pcComponentsUnit.Orders.GetAll());
        }
        [HttpPost]
        public ActionResult ChangeOrderStatus(int orderId, string newStatus)
        {
            Order order = pcComponentsUnit.Orders.GetElement(orderId);
            if (order != null) {
                string orderStatus = pcComponentsUnit.Orders.GetElement(orderId).OrderStatus;
                if (newStatus != orderStatus && Enum.GetNames(typeof(OrderStatus)).Contains(newStatus)
                    && !"Registered, Finished".Contains(newStatus))
                {
                    order.OrderStatus = newStatus;
                    pcComponentsUnit.Orders.Update(order);
                    pcComponentsUnit.Save();
                }
            }
            return View("Orders", pcComponentsUnit.Orders.GetAll());
        }
    }
}