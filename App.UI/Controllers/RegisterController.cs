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
    public class RegisterController : Controller
    {
        public readonly ICrudService<RegisterUser> _regUserService;
        public readonly IAuthenticateService _authService;
        public readonly IUserValidate _userValidate;

        public RegisterController(ICrudService<RegisterUser> regUserService, IAuthenticateService authService, IUserValidate userValidate)
        {
            _regUserService = regUserService;
            _authService = authService;
            _userValidate = userValidate;
        }

        //
        // GET: /Register/

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [MusicStoreError]
        public ActionResult Create(RegisterUser model)
        {
            if (ModelState.IsValid)
            {
                _regUserService.Save(model);
                var result = _userValidate.Execute(new ValidationParameters { Email = model.Email, Password = model.Password });
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
            return RedirectToAction("Create", "Register");
        }

    }
}
