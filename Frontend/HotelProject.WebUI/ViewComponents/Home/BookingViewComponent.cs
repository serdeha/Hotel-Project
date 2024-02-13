using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class BookingViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
