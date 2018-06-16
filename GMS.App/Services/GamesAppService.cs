using GMS.App.Interfaces;
using GMS.Data.Repositories;
using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using GMS.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.App.Services
{
    public class GamesAppService : AppServiceBase<Game>, IGamesAppService
    {
        private readonly IGamesService _gamesService;

        public GamesAppService(IGamesService gamesService)
            : base(gamesService)
        {
            _gamesService = gamesService;
        }

        public IEnumerable<Game> GetActiveGames()
        {
            return _gamesService.GetActiveGames(_gamesService.GetAll());
        }

        public IList<SelectListItem> GetAvailableGames()
        {
            return _gamesService.GetAvailableGames(_gamesService.GetActiveGames(_gamesService.GetAll()));
        }

        public IList<SelectListItem> GetGenres()
        {
            return _gamesService.GetGenres();
        }

        public IList<SelectListItem> GetPlatforms()
        {
            return _gamesService.GetPlatforms();
        }

        public void Lend(Game game, int frienId)
        {
            _gamesService.Lend(game, frienId);
        }

        public void Receive(Game game)
        {
            _gamesService.Receive(game);
        }

        public int Count()
        {
            return _gamesService.Count();
        }
    }
}
