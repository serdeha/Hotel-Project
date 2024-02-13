using AutoMapper;
using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Areas.User.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public RegisterController(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return User.Identity!.IsAuthenticated ? RedirectToAction("Index", "Home", new { area = "Admin" }) : View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserAddDto userAddDto)
        {
            if (!ModelState.IsValid) return View(userAddDto);

            var user = _mapper.Map<AppUser>(userAddDto);
            var result = await _userManager.CreateAsync(user, userAddDto.Password);

            return result.Succeeded ? RedirectToAction("Index", "Login", new { area = "User" }) : View();
        }
    }
}
