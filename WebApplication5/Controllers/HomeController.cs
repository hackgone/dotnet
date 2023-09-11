using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Microsoft.Extensions.Logging;
using WebApplication5.Models;
using Newtonsoft.Json;
using System.Text;
using Newtonsoft.Json.Linq;


namespace WebApplication5.Controllers
{
    public class HomeController:Controller
    {
         /*public IActionResult Index()
         {
            //return Content("Hello world");
            return View();
         }*/
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<HomeController> _logger;

        public HomeController(IHttpClientFactory httpClientFactory, ILogger<HomeController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;
        }
        public async Task<IActionResult> HomeMain(String departName )
        {
            int[] employee_data = { 74430, 8724, 67269, 42996, 29793, 5677, 34085, 73870, 60699, 70734,48529,76303,5677,60889,11824};
            string[] columnsName = { "employee_id","education", "age", "gender", "department", "avg_training_score" };

            var httpClient = _httpClientFactory.CreateClient();
            var requestModel = new RequestModel {
                employee_id = employee_data,
                columns = columnsName,
                depart_name = departName
            };
            var jsonContent = new StringContent(JsonConvert.SerializeObject(requestModel), Encoding.UTF8, "application/json");
            var apiResponse = await httpClient.PostAsync("http://localhost:5000/api", jsonContent);
            var responseContent = await apiResponse.Content.ReadAsStringAsync();
            JObject jsonObject = JObject.Parse(responseContent);
            JArray first_5_array = (JArray)jsonObject["top_5"];
            JArray last_5_array = (JArray)jsonObject["last_5"];
            ViewBag.first_5_array = first_5_array;
            ViewBag.last_5_array = last_5_array;
            ViewBag.columns = columnsName;
            return View("Data_show");
           // return Content();
            //return Content(responseContent);
        }

    }
}
