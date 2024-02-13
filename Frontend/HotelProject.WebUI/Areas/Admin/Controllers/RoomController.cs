using HotelProject.Core;
using HotelProject.WebUI.Areas.Admin.Dtos.RoomDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RoomController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Room");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var rooms = JsonConvert.DeserializeObject<List<ResultRoomDto>>(jsonData);
                return View(rooms);
            }
            return BadRequest(404);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddRoomDto addRoomDto, IFormFile? roomImage)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                addRoomDto.RoomCoverImage = roomImage == null ? "defaultRoom.png" : await ImageHelperExtension.UploadWebpImage(roomImage, "room");
                var jsonData = JsonConvert.SerializeObject(addRoomDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("http://localhost:5208/api/Room", stringContent);
                return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Room", new { area = "Admin" }) : BadRequest(responseMessage.StatusCode);
            }

            return View(addRoomDto);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int roomId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5208/api/Room/{roomId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var room = JsonConvert.DeserializeObject<UpdateRoomDto>(jsonData);
                return View(room);
            }
            return BadRequest(404);
        }

        [HttpPost]
        public async Task<IActionResult> Update(UpdateRoomDto updateRoomDto, IFormFile? roomImage)
        {
            if (ModelState.IsValid)
            {
                var client = _httpClientFactory.CreateClient();
                if(roomImage != null && updateRoomDto.RoomCoverImage != "defaultRoom.png")
                {
                    ImageHelperExtension.DeleteImage(updateRoomDto.RoomCoverImage!, "room");
                    updateRoomDto.RoomCoverImage = await ImageHelperExtension.UploadWebpImage(roomImage, "room");
                }
                var jsonData = JsonConvert.SerializeObject(updateRoomDto);
                StringContent stringContent = new StringContent(jsonData,Encoding.UTF8,"application/json");
                var responseMessage = await client.PutAsync("http://localhost:5208/api/Room/", stringContent);
                return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Room", new {area="Admin"}) : BadRequest(responseMessage.StatusCode);
            }

            return View(updateRoomDto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int roomId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5208/api/Room/{roomId}");
            return responseMessage.IsSuccessStatusCode ? RedirectToAction("Index", "Room", new { area = "Admin" }) : BadRequest(responseMessage.StatusCode);
        }
    }
}
