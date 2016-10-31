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
                //Casting 
                switch (account.Name.ToLower())
                {
                    case "spotify":
                        _service = new SpotifyService();
                        var track = _service.Search<Services
                                .ResponseModels.SpotifyModel>(q).Tracks.Items.Select(r => new SearchResult
                                {
                                    SongName = r.Name,
                                    Artists = r.Album.Artists.Select(a => new Artist
                                    {
                                        Id = a.Id,
                                        Name = a.Name,
                                        Uri = a.Uri,
                                        Url = a.Href
                                    }).ToList(),
                                    AlbumName = r.Album.Name,
                                    Popularity = r.Popularity,
                                    type = r.Album.type,

                                }).ToList();
                        account.Results = track;
                        break;
                }
            }


            return accounts;
        }
    }
}