using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Services
{
    public class YoutubeService : IServices
    {
        protected RestClient _client;

        public YoutubeService()
        {
            _client = new RestClient("https://www.googleapis.com/youtube/v3/");
        }
        public TModel Search<TModel>(string q) where TModel : class
        {
            RestRequest request = new RestRequest("search");
            request.AddParameter("q", q);
            request.AddParameter("part", "snippet");
            request.AddParameter("order", "viewCount");
            request.AddParameter("type", "video");
            request.AddParameter("key", "AIzaSyB8sgYMGHPolx92AdDBNVPM0NqimV63x3Q");

            //Variables de limites de busqueda o filtros
            //limit, offset
            var model = (TModel)Activator.CreateInstance(typeof(TModel));

            var responseRequest = _client.Execute(request);
            var response = JsonConvert.DeserializeObject<TModel>(responseRequest.Content);


            return response;
        }
    }
}
