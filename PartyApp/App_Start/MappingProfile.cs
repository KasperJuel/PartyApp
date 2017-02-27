using AutoMapper;
using PartyApp.Dtos;
using PartyApp.Models;

namespace PartyApp.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ApplicationUser, UserDto>();
            CreateMap<Party, PartyDto>();
            CreateMap<PartyType, PartyTypeDto>();
            CreateMap<Notification, NotificationDto>();
        }
    }
}
