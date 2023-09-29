using AutoMapper;
using RankingAppTT.Models;
using RankingAppTT.ViewModel;


namespace RankingAppTT
{
    public class UserProfile : Profile
    {

        public UserProfile()
        {
            CreateMap<User, UserViewModel>()
            .ForMember(dest => 
                dest.FName, 
                opt => opt.MapFrom(src => src.FirstName))
            .ForMember(dest =>
                dest.LName,
                opt => opt.MapFrom(src => src.LastName));
        }

    }

}