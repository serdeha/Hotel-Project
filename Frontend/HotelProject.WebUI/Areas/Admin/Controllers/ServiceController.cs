using AutoMapper;
using HotelProject.Core;
using HotelProject.WebUI.Areas.Admin.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServiceController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IMapper _mapper;

        public ServiceController(IHttpClientFactory httpClientFactory, IMapper mapper)
        {
            _httpClientFactory = httpClientFactory;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index()
        {
            // http://localhost:5208/api/Staff
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Service");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var services = JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View(services);
            }

            return BadRequest();
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddServiceDto addServiceDto, IFormFile? iconImage)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                addServiceDto.ServiceIcon = iconImage == null ? "defaultService.png" : await ImageHelperExtension.UploadWebpImage(iconImage, "service");
                var jsonData = JsonConvert.SerializeObject(addServiceDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5208/api/Service", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "Service", new { area = "Admin" });
                }
            }
            return View(addServiceDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int serviceId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5208/api/Service/{serviceId}");
            return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Service", new { area = "Admin" }) : View(responseMessage.StatusCode);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int serviceId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5208/api/Service/{serviceId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var service = JsonConvert.DeserializeObject<UpdateServiceDto>(jsonData);
                return View(service);
            }

            return BadRequest(404);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateServiceDto updateServiceDto, IFormFile? iconImage)
        {
            if(!ModelState.IsValid) return View(updateServiceDto);

            var client = _httpClientFactory.CreateClient();
            if(iconImage != null && updateServiceDto.ServiceIcon != "defaultService.png")
            {
                ImageHelperExtension.DeleteImage(updateServiceDto.ServiceIcon!, "service");
                updateServiceDto.ServiceIcon = await ImageHelperExtension.UploadWebpImage(iconImage, "service");
            }
            var jsonData = JsonConvert.SerializeObject(updateServiceDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5208/api/Service/", stringContent);
            return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Service", new { area = "Admin" }) : BadRequest(responseMessage.StatusCode);
        }
    }
}
