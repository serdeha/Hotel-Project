using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialController : ControllerBase
    {
        private readonly ITestimonialService _testimonialService;

        public TestimonialController(ITestimonialService testimonialService)
        {
            _testimonialService = testimonialService;
        }

        [HttpGet]
        public async Task<IActionResult> TestimonialList()
        {
            var values = await _testimonialService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Testimonial testimonial)
        {
            await _testimonialService.AddAsync(testimonial);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Testimonial testimonial)
        {
            await _testimonialService.UpdateAsync(testimonial);
            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int testimonialId)
        {
            var testimonial = await _testimonialService.GetByIdAsync(testimonialId);
            if (testimonial != null)
            {
                await _testimonialService.DeleteAsync(testimonial);
                return Ok(testimonial);
            }
            return NotFound(404);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var testimonial = await _testimonialService.GetByIdAsync(id);
            return Ok(testimonial);
        }
    }
}
