using HotelProject.Business.Abstract;
using HotelProject.Entity.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : ControllerBase
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }

        [HttpGet]
        public async Task<IActionResult> StaffList()
        {
            var values = await _staffService.GetAllWithFilterAsync(x => x.IsActive && !x.IsDeleted);
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Staff staff)
        {
            await _staffService.AddAsync(staff);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(Staff staff)
        {
            await _staffService.UpdateAsync(staff);
            return Ok();
        }

        [HttpDelete("{staffId}")]
        public async Task<IActionResult> Delete(int staffId)
        {
            var staff = await _staffService.GetByIdAsync(staffId);
            if (staff != null)
            {
                await _staffService.DeleteAsync(staff);
                return Ok(staff);
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var staff = await _staffService.GetByIdAsync(id);
            return Ok(staff);
        }
    }
}
