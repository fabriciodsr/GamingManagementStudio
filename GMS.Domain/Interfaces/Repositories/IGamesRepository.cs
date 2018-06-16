using GMS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.Domain.Interfaces.Repositories
{
    public interface IGamesRepository : IRepositoryBase<Game>
    {
        int Count();

        IEnumerable<Game> GetActiveGames(IEnumerable<Game> games);

        IList<SelectListItem> GetAvailableGames(IEnumerable<Game> games);

        IList<SelectListItem> GetGenres();

        IList<SelectListItem> GetPlatforms();

        void Lend(Game game, int friendId);

        void Receive(Game game);
    }
}
