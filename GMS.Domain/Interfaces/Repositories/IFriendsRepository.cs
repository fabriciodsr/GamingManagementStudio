using GMS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.Domain.Interfaces.Repositories
{
    public interface IFriendsRepository : IRepositoryBase<Friend>
    {
        int Count();

        IEnumerable<Friend> GetActiveFriends(IEnumerable<Friend> friends);

        IList<SelectListItem> FillFriendsDropDown(IEnumerable<Friend> friends);
    }
}
