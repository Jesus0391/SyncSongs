using SongSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Services.ResponseModels
{
    //Modelo base con campos comunes
    public class ServiceModel
    {
        public string Id { get; set; }
        public string type { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; }
        public string Href { get; set; }
        public ExternalUrl external_urls { get; set; }
    }
    public class SpotifyModel : ServiceModel
    {
        //public List<Album> Albums { get; set; }
      public TrackSpotify Tracks { get; set; }
      public AlbumSpotify Alumbs { get; set; }
    }
    public class AlbumSpotify : ServiceModel
    {
     public List<ItemsAlbum> Items { get; set; }  
    }
    public class ItemsAlbum : ServiceModel
    {
       public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Image> Images { get; set; }
    }
    public class TrackSpotify : ServiceModel
    {
        public List<ItemsTrack> Items { get; set; }
    }
    public class ItemsTrack : ServiceModel
    {
        public Album Album { get; set; }
        public List<Artist> Artists { get; set; }
        public int Disc_Number { get; set; }
        public long Duration_Ms { get; set; }
        public int Popularity { get; set; }
        public string Preview_Url { get; set; }
        public int Track_Number { get; set; }
    }
    public class Album : ServiceModel
    {
        public string Album_type { get; set; }
        public List<Artist> Artists { get; set; }
        public List<Image> Images { get; set; }
    }
    public class Artist : ServiceModel
    {
       
    }
    public class ExternalUrl
    {
        public string spotify { get; set; }
    }
    //Spotify, Google, etc...
    public class Image
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public string Url { get; set; }
    }
}