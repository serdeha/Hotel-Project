using HotelProject.WebUI.Areas.Admin.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //http://localhost:5208/api/Subscribe
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Subscribe");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var subscribes = JsonConvert.DeserializeObject<List<ResultSubscribeDto>>(jsonData);
                return View(subscribes);
            }
            return BadRequest();
        }

        [HttpGet]
        public async Task<IActionResult> Update(int subscribeId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5208/api/Subscribe/{subscribeId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var subscribe = JsonConvert.DeserializeObject<UpdateSubscribeDto>(jsonData);
                return View(subscribe);
            }
            return BadRequest(404);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateSubscribeDto updateSubscribe)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateSubscribe);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("http://localhost:5208/api/Subscribe/", stringContent);
                return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Subscribe", new { area = "Admin" }) : BadRequest(404);
            }
            return View(updateSubscribe);
        }
    }
}
