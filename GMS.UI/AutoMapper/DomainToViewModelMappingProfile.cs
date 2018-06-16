using AutoMapper;
using GMS.Domain.Entities;
using GMS.UI.ViewModels;

namespace GMS.UI.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<FriendViewModel, Friend>();
            CreateMap<GameViewModel, Game>();
            CreateMap<LoanViewModel, Loan>();
        }
    }
}