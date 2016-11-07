using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace SongsSync.Controllers
{
    public class SearchController : Controller
    {
        // GET: /<controller>/
        public  IActionResult Index(string q)
        {
           using(var client = new HttpClient())
            {
                var response = client.GetStringAsync($"/Search?q={q}").Result;
                
                var results = JsonConvert.DeserializeObject<List<SongSync.Models.Account>>(response);
            }
            return View();
        }
    }
}
