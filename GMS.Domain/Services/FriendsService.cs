using GMS.Domain.Entities;
using GMS.Domain.Interfaces.Services;
using GMS.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace GMS.Domain.Services
{
    public class FriendsService : ServiceBase<Friend>, IFriendsService
    {
        private readonly IFriendsRepository _friendsRepository;

        public FriendsService(IFriendsRepository friendsRepository)
            : base(friendsRepository)
        {
            _friendsRepository = friendsRepository;
        }

        public IList<SelectListItem> FillFriendsDropDown(IEnumerable<Friend> friends)
        {
            return _friendsRepository.FillFriendsDropDown(friends);
        }

        public int Count()
        {
            return _friendsRepository.Count();
        }

        public IEnumerable<Friend> GetActiveFriends(IEnumerable<Friend> friends)
        {
            return _friendsRepository.GetActiveFriends(friends);
        }
    }
}
