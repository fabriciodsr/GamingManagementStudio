using AutoMapper;
using GMS.Domain.Entities;
using GMS.UI.ViewModels;

namespace GMS.UI.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<Friend, FriendViewModel>();
            CreateMap<Game, GameViewModel>();
            CreateMap<Loan, LoanViewModel>();
        }
    }
}