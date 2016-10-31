using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SongsSync.Models
{
    public class ExternalAccounts
    {
        public Spotify Spotify { get; set; }
        public Youtube Youtube { get; set; }
    }

    public class Spotify
    {
        public string Id { get; set; }
        public string Secret { get; set; }
        public string Redirect { get; set; }
    }

    public class Youtube
    {
        public string Id { get; set; }
        public string Secret { get; set; }
    }
}
