using GMS.App.Interfaces;
using GMS.App.Services;
using GMS.UI.ViewModels;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.UI.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IFriendsAppService _friendsApp;
        private readonly IGamesAppService _gamesApp;
        private readonly ILoansAppService _loansApp;

        public HomeController(ILoansAppService loansApp, IFriendsAppService friendsApp, IGamesAppService gamesApp)
        {
            _friendsApp = friendsApp;
            _gamesApp = gamesApp;
            _loansApp = loansApp;
        }

        public ActionResult Index()
        {
            var viewModel = new DashboardViewModel()
            {
                FriendsCount = _friendsApp.Count(),
                GamesCount = _gamesApp.Count(),
                PendingLoans = _loansApp.PendingCount(),
                FinishedLoans = _loansApp.FinishedCount()
            };

            return View(viewModel);
        }
    }
}