using RestSharp;
using SongSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoundMusic.Controllers
{
    public class SearchController : BaseController
    {

        public SearchController()
        {
            _client = new RestSharp.RestClient(_apiRequest + "/Search?");
        }
        // GET: Search
        public ActionResult Index(string q)
        {
            var request = new RestRequest(Method.GET);
            request.AddParameter("q", q);

            var response = _client.Execute<List<Account>>(request);
            var result = response.Data;

            return View(result);
        }
    }
}