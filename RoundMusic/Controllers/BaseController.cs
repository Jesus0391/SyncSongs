using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RoundMusic.Controllers
{
    public class BaseController : Controller
    {
        protected string _apiRequest = "";
        protected RestClient _client;
        public BaseController()
        {
            _apiRequest = ConfigurationManager.AppSettings["ApiRequest"].ToString();

        }
    }
}