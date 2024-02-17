using AutoMapper;
using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Areas.Admin.Dtos.AboutDto;
using HotelProject.WebUI.Areas.Admin.Dtos.ServiceDto;
using HotelProject.WebUI.Areas.Admin.Dtos.SubscribeDto;
using HotelProject.WebUI.Dtos.SubscribeDto;

namespace HotelProject.WebUI.Areas.Admin.Mappings
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<ResultServiceDto, Service>().ReverseMap();
            CreateMap<AddServiceDto, Service>().ReverseMap();
            CreateMap<UpdateServiceDto, Service>().ReverseMap();
            CreateMap<ResultAboutDto, About>().ReverseMap();
            CreateMap<UpdateAboutDto, About>().ReverseMap();
            CreateMap<ResultSubscribeDto, Subscribe>().ReverseMap();
            CreateMap<AddSubscribeDto, Subscribe>().ReverseMap();
        }
    }
}
