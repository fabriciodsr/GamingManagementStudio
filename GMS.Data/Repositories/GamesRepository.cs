using System.Collections.Generic;
using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using System.Linq;
using GMS.Domain.Interfaces.Repositories;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using GMS.Domain.Enums;

namespace GMS.Data.Repositories
{
    public class GamesRepository : RepositoryBase<Game>, IGamesRepository
    {
        public GamesRepository() 
            : base()
        {
        }

        public int Count()
        {
            return Db.Games.Where(g => !g.Deleted).Count();
        }

        public IEnumerable<Game> GetActiveGames(IEnumerable<Game> games)
        {
            return games.Where(f => !f.Deleted);
        }

        public IList<SelectListItem> GetAvailableGames(IEnumerable<Game> games)
        {
            return games.Where(game => !game.Unavailable).Select(game => new SelectListItem { Value = game.Id.ToString(), Text = game.Name }).ToList();
        }

        public IList<SelectListItem> GetGenres()
        {
            var genreList = EnumHelper.GetSelectList(typeof(Genre));
            genreList.Add(new SelectListItem { Text = "Nenhum", Value = "", Selected = true });

            return genreList;
        }

        public IList<SelectListItem> GetPlatforms()
        {
            var platformList = EnumHelper.GetSelectList(typeof(Platform));
            platformList.Add(new SelectListItem { Text = "Nenhuma", Value = "", Selected = true });

            return platformList;
        }

        public void Lend(Game game, int friendId)
        {
            game.Unavailable = true;
            game.FriendId = friendId;

            Update(game);
        }

        public void Receive(Game game)
        {
            game.FriendId = null;
            game.Unavailable = false;

            Update(game);
        }
    }
}
