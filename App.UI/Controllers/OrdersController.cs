using App.Core;
using App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class OrdersController : Controller
    {
        public readonly IOrdersQuery _ordersService;

        public OrdersController(IOrdersQuery ordersService)
        {
            _ordersService = ordersService;
        }

        //
        // GET: /Orders/

        [HttpGet]
        public ActionResult Index()
        {
            return View(_ordersService.GetOrders(LoginUserInfo.UserId));
        }

        [HttpGet]
        public ActionResult ViewOrder(int id)
        {
            //ViewOrder
            return View(_ordersService.OrderView(id));
        }

    }
}
