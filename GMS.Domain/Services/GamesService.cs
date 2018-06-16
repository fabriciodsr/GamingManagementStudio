using GMS.Domain.Entities;
using GMS.Domain.Enums;
using GMS.Domain.Interfaces.Repositories;
using GMS.Domain.Interfaces.Services;
using GMS.Domain.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace GMS.App.Services
{
    public class GamesService : ServiceBase<Game>, IGamesService
    {
        private readonly IGamesRepository _gamesRepository;

        public GamesService(IGamesRepository gamesRepository)
            : base(gamesRepository)
        {
            _gamesRepository = gamesRepository;
        }

        public IEnumerable<Game> GetActiveGames(IEnumerable<Game> games)
        {
            return _gamesRepository.GetActiveGames(games);
        }

        public IList<SelectListItem> GetAvailableGames(IEnumerable<Game> games)
        {
            return _gamesRepository.GetAvailableGames(games);
        }

        public IList<SelectListItem> GetGenres()
        {
            return _gamesRepository.GetGenres();
        }

        public IList<SelectListItem> GetPlatforms()
        {
            return _gamesRepository.GetPlatforms();
        }

        public void Lend(Game game, int friendId)
        {
            _gamesRepository.Lend(game, friendId);
        }

        public void Receive(Game game)
        {
            _gamesRepository.Receive(game);
        }

        public int Count()
        {
            return _gamesRepository.Count();
        }
    }
}
