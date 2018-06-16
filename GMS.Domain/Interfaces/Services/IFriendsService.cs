using GMS.Domain.Entities;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.Domain.Interfaces.Services
{
    public interface IFriendsService : IServiceBase<Friend>
    {
        IEnumerable<Friend> GetActiveFriends(IEnumerable<Friend> friends);

        IList<SelectListItem> FillFriendsDropDown(IEnumerable<Friend> friends);

        int Count();
    }
}
