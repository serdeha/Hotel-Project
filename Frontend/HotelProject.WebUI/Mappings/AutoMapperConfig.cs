using AutoMapper;
using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Areas.Admin.Dtos.RoomDto;
using HotelProject.WebUI.Dtos.AboutDto;

namespace HotelProject.WebUI.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<ResultRoomDto, Room>().ReverseMap();
        }
    }
}
