using AutoMapper;
using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Areas.User.Dtos.User;

namespace HotelProject.WebUI.Areas.User.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<UserAddDto, AppUser>().ReverseMap();
            CreateMap<UserLoginDto, AppUser>().ReverseMap();
        }
    }
}
