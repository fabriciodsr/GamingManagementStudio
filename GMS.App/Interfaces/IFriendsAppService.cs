using GMS.Domain.Entities;
using GMS.App.Services;
using System.Collections.Generic;
using System.Web.Mvc;

namespace GMS.App.Interfaces
{
    public interface IFriendsAppService : IAppServiceBase<Friend>
    {
        IEnumerable<Friend> GetActiveFriends();

        IList<SelectListItem> FillFriendsDropDown();

        int Count();
    }
}
