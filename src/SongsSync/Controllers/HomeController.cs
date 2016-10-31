using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using SongsSync.Models;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;

namespace SongsSync.Controllers
{
    public class HomeController : Controller
    {
        private readonly IOptions<ExternalAccounts> _externalAccount;

        public HomeController(IOptions<ExternalAccounts> options)
        {
            _externalAccount = options;
        }

        public IActionResult Index()
        {
            return View();
        }
        
        [Authorize]
        public async Task<IActionResult> Search()
        {
            //var url = "https://api.spotify.com/v1/me";
            //var accessToken = "BQCnwMh8GofOzVNt_0h1lmLplgY0X8Mzi-8Wyd6jkd4sMhSi-Z1yPnMwQnh8dXrBPghpRTQXTIM9cQ5EgZ_Cw4iCG5F0W4XAujH3qRnB-cCPEemR4F_-Pv-L5Fhe4dfEdiKqtO8wZ2FxLdmQBQ-ulFaPEZugE2qC";
            //using(HttpClient client = new HttpClient())
            //{ 
            //    //client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", $"Bearer {accessToken}");
            //    var response =
            //            await client.GetStringAsync(url);
            //    ViewData["response"] = response;
            //}

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
