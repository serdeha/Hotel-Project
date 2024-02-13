using AutoMapper;
using HotelProject.Dto.Dtos.RoomDto;
using HotelProject.Entity.Concrete;

namespace HotelProject.WebApi.Mappings
{
    public class AutoMapperConfig:Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Room, RoomAddDto>().ReverseMap();
            CreateMap<Room, RoomUpdateDto>().ReverseMap();
        }
    }
}
