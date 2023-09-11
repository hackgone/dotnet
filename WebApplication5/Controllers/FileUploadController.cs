using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication5.Controllers
{
    public class FileUploadController:Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;
        public FileUploadController(IHttpClientFactory httpClientFactory )
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        /*public IActionResult Upload(IFormFile file)
        {
            return Content("hello");
        }*/
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if(file == null || file.Length == 0)
            {
                // ViewBag.
                return View();
            }

            using (var client = _httpClientFactory.CreateClient())
            using (var content = new MultipartFormDataContent())
            {
                content.Add(new StreamContent(file.OpenReadStream()), "file", file.FileName);
                var response = await client.PostAsync("http://localhost:5000/file-upload", content);
                //return Content("Hello world");
                return RedirectToAction("Index", "DropDown");

            }
            //return Content("hello");


        }
    }
}
