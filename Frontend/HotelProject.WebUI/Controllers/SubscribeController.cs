using HotelProject.WebUI.Dtos.SubscribeDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SubscribeController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpPost]
        public async Task<JsonResult> Add([FromBody] AddSubscribeDto addSubscribeDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(addSubscribeDto);
            StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync("http://localhost:5208/api/Subscribe",stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return Json(JsonConvert.SerializeObject(new {ResultStatus = true, data = addSubscribeDto }));
            }

            return Json(new { ResultStatus = false, StatusCode =  responseMessage.StatusCode});
        }
    }
}
