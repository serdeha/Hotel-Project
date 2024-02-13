using HotelProject.Core;
using HotelProject.WebUI.Areas.Admin.Models.Testimonial;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace HotelProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TestimonialController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public TestimonialController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5208/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var testimonials = JsonConvert.DeserializeObject<List<TestimonialViewModel>>(jsonData);
                return View(testimonials);
            }

            return BadRequest(responseMessage.StatusCode);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(TestimonialAddViewModel testimonial, IFormFile testimonialImage)
        {
            var client = _httpClientFactory.CreateClient();
            testimonial.Image = testimonialImage == null ? "testimonial.png" : await ImageHelperExtension.UploadWebpImage(testimonialImage, "testimonial");
            var jsonData = JsonConvert.SerializeObject(testimonial);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("http://localhost:5208/api/Testimonial", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }

            return BadRequest(responseMessage.StatusCode);
        }


        public async Task<IActionResult> Delete(int testimonialId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"http://localhost:5208/api/Testimonial/{testimonialId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }

            return BadRequest(responseMessage.StatusCode);
        }

        [HttpGet]
        public async Task<IActionResult> Update(int testimonialId)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"http://localhost:5208/api/Testimonial/{testimonialId}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var testimonial = JsonConvert.DeserializeObject<TestimonialUpdateViewModel>(jsonData);
                return View(testimonial);
            }

            return BadRequest(responseMessage.StatusCode);
        }

        [HttpPost]
        public async Task<IActionResult> Update(TestimonialUpdateViewModel testimonialUpdateViewModel, IFormFile testimonialImage)
        {
            var client = _httpClientFactory.CreateClient();
            if (testimonialImage != null && testimonialUpdateViewModel.Image != "testimonial.png")
            {
                ImageHelperExtension.DeleteImage(testimonialUpdateViewModel.Image!,"testimonial");
                testimonialUpdateViewModel.Image = await ImageHelperExtension.UploadWebpImage(testimonialImage, "testimonial");
            }
            var jsonData = JsonConvert.SerializeObject(testimonialUpdateViewModel);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("http://localhost:5208/api/Testimonial/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Testimonial", new { area = "Admin" });
            }

            return BadRequest(responseMessage.StatusCode);
        }
    }
}
