using App.Core;
using App.Core.CommandModels;
using App.Core.Contracts;
using App.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class AddToCartController : Controller
    {

        public readonly ICrudService<AddToCart> _add2CartService;
        public readonly IStoreService _storeService;
        public readonly ICartService _cartService;
        public readonly IOrderService _orderService;

        public AddToCartController(ICrudService<AddToCart> add2CartService, IStoreService storeService, ICartService cartService,
            IOrderService orderService)
        {
            _add2CartService = add2CartService;
            _storeService = storeService;
            _cartService = cartService;
            _orderService = orderService;
        }

        //
        // GET: /AddToCart/

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Add(int id)
        {
            if (id > 0)
            {
                _add2CartService.Save(new AddToCart { AlbumId = id, CartId = LoginUserInfo.CartId, UserId = LoginUserInfo.UserId });
            }
            return Json(new { result = "Success" }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CartCount()
        {
            int cartCount = 0;

            if (!string.IsNullOrEmpty(LoginUserInfo.CartId) && LoginUserInfo.UserId > 0)
            {
                cartCount = _cartService.CartCount(LoginUserInfo.UserId, LoginUserInfo.CartId);
            }

            return Json(new { result = cartCount }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewCart()
        {
            return View(_cartService.ViewCart(LoginUserInfo.UserId, LoginUserInfo.CartId));
        }

        public ActionResult RemoveFromCart(int id)
        {
            if (id > 0)
            {
                _cartService.RemoveFromCart(id);
            }
            return RedirectToAction("ViewCart", "AddToCart");
        }


        [HttpGet]
        public ActionResult CheckOut()
        {
            var nameDetails = LoginUserInfo.Name.Split(' ');
            SubmitOrder order = new SubmitOrder
            {
                CartDetails = _cartService.ViewCart(LoginUserInfo.UserId, LoginUserInfo.CartId),
                FirstName = nameDetails[0].ToString(),
                LastName = nameDetails[1].ToString()
            };
            return View(order);
        }

        [HttpPost]
        public ActionResult CheckOut(SubmitOrder order)
        {
            order.CartDetails = _cartService.ViewCart(LoginUserInfo.UserId, LoginUserInfo.CartId);

            if (ModelState.IsValid)
            {
                _orderService.Save(order);
                return RedirectToAction("Order/" + order.OrderId, "AddToCart");
            }

            return View(order);
        }

        [HttpGet]
        public ActionResult Order(int id = 0)
        {
            ViewBag.OrderId = id;
            return View();
        }
    }
}
