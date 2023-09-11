using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    public class DropDownController:Controller
    {
        
        public IActionResult Index()
        {
            
            return View();
        }
        /*public async void backgroundTask()
        {
            var csv = new List<string[]>();
            var lines = System.IO.File.ReadAllLines("C:/Users/NIC/Desktop/Data.csv");

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }
            string jsonData = JsonConvert.SerializeObject(listObjResult);
            using (var client = new HttpClient())
            using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("http://localhost:5000/df", content);
            }

            return;
        }*/
        public async Task BackgroundTask()
        {
            var csv = new List<string[]>();
            var lines = System.IO.File.ReadAllLines("C:/Users/NIC/Desktop/Data.csv");

            foreach (string line in lines)
                csv.Add(line.Split(','));

            var properties = lines[0].Split(',');

            var listObjResult = new List<Dictionary<string, string>>();

            for (int i = 1; i < lines.Length; i++)
            {
                var objResult = new Dictionary<string, string>();
                for (int j = 0; j < properties.Length; j++)
                    objResult.Add(properties[j], csv[i][j]);

                listObjResult.Add(objResult);
            }
            string jsonData = JsonConvert.SerializeObject(listObjResult);
            using (var client = new HttpClient())
            using (var content = new StringContent(jsonData, Encoding.UTF8, "application/json"))
            {
                var response = await client.PostAsync("http://localhost:5000/df", content);
            }

            return;
        }
        [HttpPost]
        public IActionResult SubmitForm(string selectedOption)
        {
            _ = BackgroundTask();
            return RedirectToAction("HomeMain","Home",new {departName= selectedOption });
        }

    }
}
