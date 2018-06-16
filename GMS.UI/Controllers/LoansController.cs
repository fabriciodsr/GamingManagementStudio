using AutoMapper;
using GMS.App.Interfaces;
using GMS.Domain.Entities;
using GMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GMS.UI.Controllers
{
    [Authorize]
    public class LoansController : Controller
    {
        private readonly IFriendsAppService _friendsApp;
        private readonly IGamesAppService _gamesApp;
        private readonly ILoansAppService _loansApp;

        public LoansController(ILoansAppService loansApp, IFriendsAppService friendsApp, IGamesAppService gamesApp)
        {
            _friendsApp = friendsApp;
            _gamesApp = gamesApp;
            _loansApp = loansApp;
        }

        public ActionResult Index()
        {
            var loansViewModel = _loansApp.GetDetailedLoans();
            return View(loansViewModel);
        }

        public ActionResult Create()
        {
            var viewModel = new LoanViewModel
            {
                Friends = _friendsApp.FillFriendsDropDown(),
                Games = _gamesApp.GetAvailableGames()
            };

            return View(viewModel);
        }

        public ActionResult Details(int id)
        {
            var LoanViewModel = Mapper.Map<Loan, LoanViewModel>(_loansApp.GetById(id));
            return View(LoanViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoanViewModel loan)
        {
            if (ModelState.IsValid)
            {
                 var objLoan = Mapper.Map<LoanViewModel, Loan>(loan);
                _loansApp.Add(objLoan);

                var objGame = _gamesApp.GetById(objLoan.GameId);
                _gamesApp.Lend(objGame, objLoan.FriendId);

                return RedirectToAction("Index");
            }

            loan.Friends = _friendsApp.FillFriendsDropDown();
            loan.Games = _gamesApp.GetAvailableGames();
            return View(loan);
        }

        public ActionResult Receive(int id)
        {
            var objLoan = _loansApp.GetById(id);

            if (objLoan != null)
            {
                try
                {
                    objLoan.DeliveredDate = DateTime.Now;
                    _loansApp.Update(objLoan);

                    var objGame = _gamesApp.GetById(objLoan.GameId);
                    _gamesApp.Receive(objGame);

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

        public ActionResult Delete(int id)
        {
            var objLoan = _loansApp.GetById(id);

            if (objLoan != null)
            {
                try
                {
                    objLoan.Deleted = true;
                    _loansApp.Update(objLoan);

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