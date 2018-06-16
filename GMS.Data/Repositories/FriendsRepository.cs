using GMS.Data.Repositories;
using GMS.Domain.Entities;
using GMS.Domain.Interfaces;
using GMS.Domain.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GMS.Data.Repositories
{
    public class FriendsRepository : RepositoryBase<Friend>, IFriendsRepository
    {
        public int Count()
        {
            return Db.Friends.Where(f => !f.Deleted).Count();
        }

        public IEnumerable<Friend> GetActiveFriends(IEnumerable<Friend> friends)
        {
            return friends.Where(f => !f.Deleted);
        }

        public IList<SelectListItem> FillFriendsDropDown(IEnumerable<Friend> friends)
        {
            return friends.Select(friend => new SelectListItem { Value = friend.Id.ToString(), Text = friend.Fullname }).ToList();
        }
    }
}
