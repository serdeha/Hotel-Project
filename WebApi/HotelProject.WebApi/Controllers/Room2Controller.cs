using AutoMapper;
using HotelProject.Business.Abstract;
using HotelProject.Dto.Dtos.RoomDto;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Room2Controller : ControllerBase
    {
        private readonly IRoomService _roomService;
        private readonly IMapper _mapper;

        public Room2Controller(IRoomService roomService, IMapper mapper)
        {
            _mapper = mapper;
            _roomService = roomService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _roomService.GetAllWithFilterAsync());
        }

        [HttpPost]
        public async Task<IActionResult> Add(RoomAddDto roomAddDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var room = _mapper.Map<Room>(roomAddDto);
            await _roomService.AddAsync(room);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(RoomUpdateDto roomUpdateDto)
        {
            if (!ModelState.IsValid) return BadRequest();

            var room = _mapper.Map<Room>(roomUpdateDto);
            await _roomService.UpdateAsync(room);
            return Ok("Başarıyla Güncellendi.");
        }
    }
}
