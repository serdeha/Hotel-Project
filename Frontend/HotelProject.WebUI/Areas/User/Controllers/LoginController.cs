using HotelProject.Entity.Concrete;
using HotelProject.WebUI.Areas.User.Dtos.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.Areas.User.Controllers
{
    [Area("User")]
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _signInManager;

        public LoginController(SignInManager<AppUser> signInManager)
        {
            _signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return User.Identity!.IsAuthenticated ? RedirectToAction("Index", "Home", new { area = "Admin" }) : View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto userLoginDto)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(userLoginDto.Username, userLoginDto.Password, false, false);
                return result.Succeeded ? RedirectToAction("Index", "Home", new { area = "Admin" }) : View();
            }

            return View(userLoginDto);
        }
    }
}
