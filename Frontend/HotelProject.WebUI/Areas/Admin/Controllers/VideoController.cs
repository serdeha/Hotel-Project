using HotelProject.WebUI.Areas.Admin.Dtos.VideoDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class VideoController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public VideoController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Update()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Video");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var video = JsonConvert.DeserializeObject<UpdateVideoDto>(jsonData);
                return View(video);
            }
            return BadRequest(responseMessage.StatusCode);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateVideoDto video)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(video);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5208/api/Video", stringContent);
                return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Home", new { area = "Admin" }) : BadRequest(responseMessage.StatusCode);
            }
            return View(video);
        }
    }
}
