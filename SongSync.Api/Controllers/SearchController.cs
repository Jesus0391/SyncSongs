using SongSync.Models;
using SongSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SongSync.Api.Controllers
{
    public class SearchController : ApiController
    {
        public List<Account> Get([FromUri]string q, 
                [FromBody]List<Account> accounts)
        {
            var accountsAvailables = new List<Account>();
            if (accounts == null)
            {
                accounts = new List<Account>()
                {
                    new Account()
                    {
                        Name = "Spotify"
                    },
                    new Account()
                    {
                        Name = "Youtube"
                    }
                };
            }
            IServices _service;

            foreach (var account in accounts)
            {
                account.Results = new List<SearchResult>();
                //Casting 
                switch (account.Name.ToLower())
                {
                    case "spotify":
                        _service = new SpotifyService();
                        var track = _service.Search<Services
                                .ResponseModels.SpotifyModel>(q).Tracks.Items.Select(r => new SearchResult
                                {
                                    Name = r.Name,
                                    Artists = r.Album.Artists.Select(a => new Artist
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        Uri = a.Uri,
                                        Url = a.Href
                                    }).ToList(),
                                    AlbumName = r.Album.Name,
                                    Popularity = r.Popularity,
                                    Type = r.Album.type,
                                    Url = $"https://embed.spotify.com/?uri={r.Uri}",
                                    UrlPreview = r.Preview_Url
                                }).ToList();
                        account.Results.AddRange(track);
                        break;
                    case "youtube":
                        _service = new YoutubeService();
                        var response = _service.Search<Services.ResponseModels.YoutubeModel>(q);
                        var videos = response.Items.Select(r => new SearchResult
                        {
                            Name = r.Snippet.Title,
                            Id  = r.Id.VideoId,
                            Url = $"https://www.youtube.com/embed/{r.Id.VideoId}?autoplay=1",
                            Type = "Video"
                        }).ToList();
                        account.Results.AddRange(videos);
                        break;
                }
            }


            return accounts;
        }
    }
}