using HotelProject.WebUI.Dtos.TestimonialDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class TestimonialViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            //http://localhost:5208/api/About
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var testimonals = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(testimonals);
            }
            return View(responseMessage.StatusCode);
        }
    }
}
