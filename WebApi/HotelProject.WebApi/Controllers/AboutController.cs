using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return Ok(await _aboutService.GetWithFilterAsync(x=>x.IsActive && !x.IsDeleted));
        }

        [HttpPost]
        public async Task<IActionResult> Add(About about)
        {
            await _aboutService.AddAsync(about);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(About about)
        {
            await _aboutService.UpdateAsync(about);
            return Ok();
        }

        [HttpDelete("{aboutId}")]
        public async Task<IActionResult> Delete(int aboutId)
        {
            var about = await _aboutService.GetByIdAsync(aboutId);
            if(about != null)
            {
                await _aboutService.DeleteAsync(about);
                return Ok();
            }

            return BadRequest(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var about = await _aboutService.GetByIdAsync(id);
            return about != null ? Ok(about) : BadRequest(404);
        }
    }
}
