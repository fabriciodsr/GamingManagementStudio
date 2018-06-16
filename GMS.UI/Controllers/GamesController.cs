using AutoMapper;
using GMS.App.Interfaces;
using GMS.Domain.Entities;
using GMS.Helpers;
using GMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.UI.Controllers
{
    [Authorize]
    public class GamesController : Controller
    {
        private readonly IGamesAppService _gamesApp;
        private readonly string filePath = "~/Content/Images/Games";

        public GamesController(IGamesAppService gamesApp)
        {
            _gamesApp = gamesApp;
        }

        public ActionResult Index()
        {
            var gamesViewModel = Mapper.Map<IEnumerable<Game>, IEnumerable<GameViewModel>>(_gamesApp.GetActiveGames());
            return View(gamesViewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new GameViewModel
            {
                Genres = _gamesApp.GetGenres(),
                Platforms = _gamesApp.GetPlatforms()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gamesApp.GetById(id));
            return View(gameViewModel);
        }

        public ActionResult Edit(int id)
        {
            var gameViewModel = Mapper.Map<Game, GameViewModel>(_gamesApp.GetById(id));
            return View(gameViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                if (game.File != null)
                {
                    var folder = Server.MapPath(filePath);
                    game.Image = FileHelper.Save(folder, game.File);
                }

                var objGame = Mapper.Map<GameViewModel, Game>(game);
                _gamesApp.Add(objGame);

                return RedirectToAction("Index");
            }

            game.Genres = _gamesApp.GetGenres();
            game.Platforms = _gamesApp.GetPlatforms();
            return View(game);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GameViewModel game)
        {
            if (ModelState.IsValid)
            {
                if (game.File != null)
                {
                    var folder = Server.MapPath(filePath);
                    game.Image = FileHelper.Save(folder, game.File);
                }

                var objGame = Mapper.Map<GameViewModel, Game>(game);
                _gamesApp.Update(objGame);

                return RedirectToAction("Index");
            }

            game.Genres = _gamesApp.GetGenres();
            game.Platforms = _gamesApp.GetPlatforms();
            return View(game);
        }

        public ActionResult Delete(int id)
        {
            var objGame = _gamesApp.GetById(id);

            if (objGame != null && !objGame.Unavailable)
            {
                try
                {
                    objGame.Deleted = true;
                    _gamesApp.Update(objGame);

                    return Json(new { status = "success" });
                }
                catch (Exception)
                {
                    return Json(new { status = "error" });
                }
            }
            else
            {
                return Json(new { status = "error" });
            }
        }
    }
}