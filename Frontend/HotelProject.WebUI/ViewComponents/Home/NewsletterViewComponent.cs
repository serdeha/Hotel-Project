using Microsoft.AspNetCore.Mvc;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class NewsletterViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
