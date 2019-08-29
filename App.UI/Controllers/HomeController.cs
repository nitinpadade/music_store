using App.Core;
using App.Core.Contracts;
using App.Core.QueryModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class HomeController : Controller
    {
        public readonly IAuthenticateService _authService;
        public readonly IUserValidate _userValidate;
        public readonly ICartService _cartService;

        public HomeController(IAuthenticateService authService, IUserValidate userValidate, ICartService cartService)
        {
            _authService = authService;
            _userValidate = userValidate;
            _cartService = cartService;
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(ValidationParameters parameterModel)
        {
            if (ModelState.IsValid)
            {
                var result = _userValidate.Execute(parameterModel);
                if (result.IsAuthenticated)
                {
                    _authService.SetUserData(new UserInfo
                    {
                        UserId = result.UserId,
                        Name = result.Name,
                        Role = result.Role,
                        RoleId = result.RoleId,
                        IsAuthenticated = result.IsAuthenticated,
                        Email = result.Email,
                        Roles = result.Roles
                    });
                    return RedirectToAction("Index", "Store");
                }
            }
            return View(parameterModel);
        }

        [HttpGet]
        public ActionResult Logout()
        {
            _cartService.ClearCart(LoginUserInfo.UserId, LoginUserInfo.CartId);
            _authService.ClearUserData();
            return RedirectToAction("Index", "Store");
        }

    }
}
