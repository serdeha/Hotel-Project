using HotelProject.WebUI.Dtos.StaffDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace HotelProject.WebUI.ViewComponents.Home
{
    public class StaffViewComponent : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public StaffViewComponent(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staffs = JsonConvert.DeserializeObject<List<ResultStaffDto>>(jsonData);
                return View(staffs);
            }
            return View(responseMessage.StatusCode);
        }
    }
}
