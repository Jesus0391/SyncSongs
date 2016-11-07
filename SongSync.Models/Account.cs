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

}
