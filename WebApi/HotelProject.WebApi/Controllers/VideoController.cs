using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoService _videoService;

        public VideoController(IVideoService videoService)
        {
            _videoService = videoService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _videoService.GetWithFilterAsync(x=>x.IsActive && !x.IsDeleted));
        }

        [HttpPost]
        public async Task<IActionResult> Add(Video video)
        {
            await _videoService.AddAsync(video);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Video video)
        {
            await _videoService.UpdateAsync(video);
            return Ok();
        }

        [HttpDelete("{videoId}")]
        public async Task<IActionResult> Delete(int videoId)
        {
            var video = await _videoService.GetByIdAsync(videoId);
            if(video != null)
            {
                await _videoService.DeleteAsync(video);
                return Ok();
            }

            return BadRequest(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var video = await _videoService.GetByIdAsync(id);
            return video != null ? Ok(video) : BadRequest(404);
        }
    }
}
