using HotelProject.WebUI.Dtos.VideoDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class VideoViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VideoViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Video");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var video = JsonConvert.DeserializeObject<ResultVideoDto>(jsonData);
                return View(video);
            }
            return View(responseMessage.StatusCode);
        }
    }
}
