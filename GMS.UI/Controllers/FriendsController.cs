using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GMS.App.Services;
using GMS.Domain.Entities;
using GMS.App.Interfaces;
using AutoMapper;
using GMS.UI.ViewModels;

namespace GMS.UI.Controllers
{
    [Authorize]
    public class FriendsController : Controller
    {
        private readonly IFriendsAppService _friendsApp;

        public FriendsController(IFriendsAppService friendsApp)
        {
            _friendsApp = friendsApp;
        }

        public ActionResult Index()
        {
            var friendsViewModel = Mapper.Map<IEnumerable<Friend>, IEnumerable<FriendViewModel>>(_friendsApp.GetActiveFriends());
            return View(friendsViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            var friendViewModel = Mapper.Map<Friend, FriendViewModel>(_friendsApp.GetById(id));
            return View(friendViewModel);
        }

        public ActionResult Edit(int id)
        {
            var friendViewModel = Mapper.Map<Friend, FriendViewModel>(_friendsApp.GetById(id));
            return View(friendViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                var objFriend = Mapper.Map<FriendViewModel, Friend>(friend);
                _friendsApp.Add(objFriend);

                return RedirectToAction("Index");
            }

            return View(friend);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(FriendViewModel friend)
        {
            if (ModelState.IsValid)
            {
                var objFriend = Mapper.Map<FriendViewModel, Friend>(friend);
                _friendsApp.Update(objFriend);

                return RedirectToAction("Index");
            }

            return View(friend);
        }

        public ActionResult Delete(int id)
        {
            var objFriend = _friendsApp.GetById(id);

            if (objFriend != null)
            {
                try
                {
                    objFriend.Deleted = true;
                    _friendsApp.Update(objFriend);

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