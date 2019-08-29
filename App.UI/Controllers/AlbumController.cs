using App.Core.CommandModels;
using App.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace App.UI.Controllers
{
    public class AlbumController : Controller
    {

        public readonly ICrudService<AlbumCrud> _albumService;
        public readonly IDropListService _dropListService;

        public AlbumController(ICrudService<AlbumCrud> albumService, IDropListService dropListService)
        {
            _albumService = albumService;
            _dropListService = dropListService;
        }

        //
        // GET: /Album/

        [HttpGet]
        [MusicAuthorize(Roles = "1")]
        public ActionResult Create()
        {
            var model = new AlbumCrud { Artists = _dropListService.Artists(), Genres = _dropListService.Genres() };
            return View(model);
        }

        [HttpPost]
        [MusicAuthorize(Roles = "1")]
        public ActionResult Create(AlbumCrud model)
        {
            if (ModelState.IsValid)
            {
                model.AlbumArtUrl = "/Content/Images/placeholder.gif";
                _albumService.Save(model);
                return RedirectToAction("Index/", "Store");
            }

            model.Artists = _dropListService.Artists();
            model.Genres = _dropListService.Genres();
            return View(model);
        }

    }
}
