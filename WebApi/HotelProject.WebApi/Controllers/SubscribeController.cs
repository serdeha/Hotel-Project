using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscribeController : Controller
    {
        private readonly ISubscribeService _subscribeService;

        public SubscribeController(ISubscribeService subscribeService)
        {
            _subscribeService = subscribeService;
        }

        [HttpGet]
        public async Task<IActionResult> SubscribeList()
        {
            var values = await _subscribeService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Subscribe subscribe)
        {
            await _subscribeService.AddAsync(subscribe);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Subscribe subscribe)
        {
            await _subscribeService.UpdateAsync(subscribe);
            return Ok();
        }

        [HttpDelete("{subscribeId}")]
        public async Task<IActionResult> Delete(int subscribeId)
        {
            var subscribe = await _subscribeService.GetByIdAsync(subscribeId);
            if (subscribe != null)
            {
                await _subscribeService.DeleteAsync(subscribe);
                return Ok(subscribe);
            }
            return NotFound(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var subscribe = await _subscribeService.GetByIdAsync(id);
            return Ok(subscribe);
        }
    }
}
