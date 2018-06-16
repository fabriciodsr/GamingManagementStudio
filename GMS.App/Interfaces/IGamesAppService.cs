using GMS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.App.Interfaces
{
    public interface IGamesAppService : IAppServiceBase<Game>
    {
        IEnumerable<Game> GetActiveGames();

        IList<SelectListItem> GetAvailableGames();

        IList<SelectListItem> GetGenres();

        IList<SelectListItem> GetPlatforms();

        void Lend(Game game, int friendId);

        void Receive(Game game);

        int Count();
    }
}
