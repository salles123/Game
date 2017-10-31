using Core.Base.Interface.Service;
using Core.Base.Model;
using Core.Base.Service;
using Infra.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Mvc.Controllers
{
    [Authorize]
    public class GameController : Controller
    {

        IGameService _gameService;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
        }
        // GET: Game
        public ActionResult Index()
        {
            return View(_gameService.GetAll());
        }

        // GET: Friend/Devolve/5
        public ActionResult Devolve(int id)
        {
            var game = _gameService.GetGame(id);
            _gameService.Devolve(game);
            return RedirectToAction("Index");
        }

        // GET: Game/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Game/Create
        [HttpPost]
        public ActionResult Create(Game game)
        {
            try
            {
                // TODO: Add insert logic here
                _gameService.Add(game);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_gameService.GetGame(id));
        }

        // POST: Game/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Game game)
        {
            try
            {
                // TODO: Add update logic here
                _gameService.Update(game);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Game/Delete/5
        public ActionResult Delete(int id)
        {
            _gameService.Delete(id);
            return RedirectToAction("Index");
        }

    }
}
