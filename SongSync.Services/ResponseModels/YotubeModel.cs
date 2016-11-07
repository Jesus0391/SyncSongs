using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Services.ResponseModels
{
    public class YoutubeAbstractModel
    {
        public string Kind { get; set; }
        public string Etag { get; set; }
        public string NextPageToken { get; set; }
        public string RegionCode { get; set; }
        
    }

    public class YoutubeModel : YoutubeAbstractModel
    {
        public List<ItemYoutube> Items { get; set; }
        public PageInfo PageInfo { get; set; }
    }
    public class PageInfo
    {
        public int TotalResults { get; set; }
        public int ResultPerPage { get; set; }
    }
    public class ItemYoutube : YoutubeAbstractModel
    {
        public Id Id { get; set; }
        public Snippet Snippet { get; set; }
    }
    public class Id
    {
        public string Kind { get; set; }
        public string VideoId { get; set; }
    }
    public class Snippet
    {
        public DateTime PublishedAt { get; set; }
        public string ChannelId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Thumbnails Thumbnails { get; set; }
        public string ChannelTitle { get; set; }
        public string liveBroadCastContent { get; set; }
    }

   
    public class Thumbnails
    {
        public Image Default { get; set; }
        public Image Medium { get; set; }
        public Image High { get; set; }
    }
}
