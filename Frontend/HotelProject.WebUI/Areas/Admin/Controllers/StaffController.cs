using HotelProject.Core;
using HotelProject.WebUI.Areas.Admin.Models.Staff;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class StaffController : Controller
    {
        public readonly IHttpClientFactory _httpClientFactory;

        public StaffController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            //http://localhost:5208/api/Staff
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Staff");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staffs = JsonConvert.DeserializeObject<List<StaffViewModel>>(jsonData);
                return View(staffs);
            }

            return BadRequest(responseMessage.StatusCode);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(StaffAddViewModel staffAddViewModel,IFormFile? staffImage)
        {
            //http://localhost:5208/api/Staff
            var client = _httpClientFactory.CreateClient();
            staffAddViewModel.StaffImage = staffImage != null ? await ImageHelperExtension.UploadWebpImage(staffImage, "staff") : "defaultStaff.png";
            var jsonData = JsonConvert.SerializeObject(staffAddViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5208/api/Staff", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Staff", new { area = "Admin" });
            }

            return View(responseMessage.StatusCode);
        }


        public async Task<IActionResult> Delete(int staffId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5208/api/Staff/{staffId}");
            if(responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Staff", new { area = "Admin" });
            }

            return View(responseMessage.StatusCode);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int staffId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5208/api/Staff/{staffId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var staff = JsonConvert.DeserializeObject<StaffUpdateViewModel>(jsonData);
                return View(staff);
            }
            return View(responseMessage.StatusCode);
        }

        [HttpPost]
        public async Task<IActionResult> Update(StaffUpdateViewModel staffUpdateViewModel, IFormFile? staffImage)
        {
            var client = _httpClientFactory.CreateClient();
            if(staffImage != null && staffUpdateViewModel.StaffImage != "defaultStaff.png")
            {
                ImageHelperExtension.DeleteImage(staffUpdateViewModel.StaffImage!, "staff");
                staffUpdateViewModel.StaffImage = await ImageHelperExtension.UploadWebpImage(staffImage, "staff");
            }
            var jsonData = JsonConvert.SerializeObject(staffUpdateViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5208/api/Staff/", stringContent);

            return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Staff", new { area = "Admin" }) : View(responseMessage.StatusCode);
        }
    }
}
