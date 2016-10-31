using SongSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SongSync.Api.Controllers
{
    public class UnitOfWork
    {
        private SpotifyService _spotifyService;

        public SpotifyService Spotify
        {
            get
            {
                if (_spotifyService == null)
                {
                    _spotifyService = new SpotifyService();
                }
                return _spotifyService;
            }
        }
    }
}