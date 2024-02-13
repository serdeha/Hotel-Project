using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class CarouselViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
