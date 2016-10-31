using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Models
{
    public class Account
    {
        public string Token { get; set; }
        public string Name { get; set; } //Account
        
        public List<SearchResult> Results { get; set; }
    }

    public class SearchResult
    {
        public List<Artist> Artists { get; set; }
        public string SongName { get; set; } //Name Song
        public string AlbumName { get; set; }   
        public string type { get; set; }
        public int Popularity { get; set; }
        public List<string> Genres { get; set; }
        //public List<Image>
    }

    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; } //Propio de la aplicaion
        public string Url { get; set; } //External Links
    }
}
