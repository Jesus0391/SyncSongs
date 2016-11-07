using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SongSync.Models
{
    public class Artist
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Uri { get; set; } //Propio de la aplicaion
        public string Url { get; set; } //External Links
    }
}

