using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceController : ControllerBase
    {
        private readonly IServiceService _serviceService;

        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            var values = await _serviceService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Service service)
        {
            await _serviceService.AddAsync(service);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Service service)
        {
            await _serviceService.UpdateAsync(service);
            return Ok();
        }

        [HttpDelete("{serviceId}")]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var service = await _serviceService.GetByIdAsync(serviceId);
            if (service != null)
            {
                await _serviceService.DeleteAsync(service);
                return Ok(service);
            }
            return NotFound(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var service = await _serviceService.GetByIdAsync(id);
            return Ok(service);
        }
    }
}
