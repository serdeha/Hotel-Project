using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomController(IRoomService roomRoom)
        {
            _roomService = roomRoom;
        }

        [HttpGet]
        public async Task<IActionResult> RoomList()
        {
            var values = await _roomService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Room room)
        {
            await _roomService.AddAsync(room);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Room room)
        {
            await _roomService.UpdateAsync(room);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int roomId)
        {
            var room = await _roomService.GetByIdAsync(roomId);
            if (room != null)
            {
                await _roomService.DeleteAsync(room);
                return Ok(room);
            }
            return NotFound(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var room = await _roomService.GetByIdAsync(id);
            return Ok(room);
        }
    }
}
