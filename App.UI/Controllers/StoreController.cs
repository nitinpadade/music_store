using App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class StoreController : Controller
    {
        public readonly IStoreService _storeQry;

        public StoreController(IStoreService storeQry)
        {
            _storeQry = storeQry;
        }

        public ActionResult Index(int id = 0)
        {
            return View(_storeQry.GetAlbumList(id));
        }

        public PartialViewResult Genres()
        {
            return PartialView(_storeQry.GetGenreList());
        }

        public ActionResult Album(int id)
        {
            return View(_storeQry.GetAlbum(id));
        }

    }
}
