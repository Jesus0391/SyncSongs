using SongSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongSync.Models;
using RestSharp;
using SongSync.Services.ResponseModels;
using Newtonsoft.Json;

namespace SongSync.Services
{
    public class SpotifyService : IServices
    {
        protected RestClient _client;

        public SpotifyService()
        {
            _client = new RestClient("https://api.spotify.com/v1/");
        }

        public TModel Search<TModel>(string q) where TModel : class
        {
            RestRequest request = new RestRequest("search");
            request.AddParameter("q", q);
            request.AddParameter("type", "album,artist,track");

            //Variables de limites de busqueda o filtros
            //limit, offset
            var model = (TModel)Activator.CreateInstance(typeof(TModel));

            var responseRequest = _client.Execute(request);
            var response = JsonConvert.DeserializeObject<TModel>(responseRequest.Content);
               

            return response;
        }
        
    }
}
