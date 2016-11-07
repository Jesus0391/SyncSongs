using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Models
{
    public class SearchResult
    {
        public List<Artist> Artists { get; set; }
        public string Name { get; set; } //Name Song
        public string AlbumName { get; set; }
        public string Type { get; set; }
        public int Popularity { get; set; }
        public List<string> Genres { get; set; }
        public string UrlPreview { get; set; }
        public string Url { get; set; }
        public string Id { get; set; }
        //public List<Image>
    }
}
