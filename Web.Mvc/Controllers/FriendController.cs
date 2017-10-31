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
    public class FriendController : Controller
    {
        IFriendService _friendService;
        public FriendController(IFriendService friendService)
        {
            _friendService = friendService;
        }

        // GET: Friend
        public ActionResult Index()
        {
            return View(_friendService.GetAll());
        }

        // GET: Friend/Games/5
        public ActionResult Games(int id)
        {
            var friend = _friendService.GetFriend(id);
            return View(friend.Games);
        }

        // GET: Friend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Friend/Create
        [HttpPost]
        public ActionResult Create(Friend friend)
        {
            try
            {
                // TODO: Add insert logic here
                _friendService.Add(friend);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_friendService.GetFriend(id));
        }

        // POST: Friend/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Friend friend)
        {
            try
            {
                // TODO: Add update logic here
                _friendService.Update(friend);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Friend/Delete/5
        public ActionResult Delete(int id)
        {
            _friendService.Delete(id);
            return RedirectToAction("Index");
        }

        
    }
}
