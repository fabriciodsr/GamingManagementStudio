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
    public class FriendsAppService : AppServiceBase<Friend>, IFriendsAppService
    {
        private readonly IFriendsService _friendsService;

        public FriendsAppService(IFriendsService friendsService)
            : base(friendsService)
        {
            _friendsService = friendsService;
        }

        public IEnumerable<Friend> GetActiveFriends()
        {
            return _friendsService.GetActiveFriends(_friendsService.GetAll());
        }

        public IList<SelectListItem> FillFriendsDropDown()
        {
            return _friendsService.FillFriendsDropDown(_friendsService.GetActiveFriends(_friendsService.GetAll()));
        }

        public int Count()
        {
            return _friendsService.Count();
        }
    }
}
