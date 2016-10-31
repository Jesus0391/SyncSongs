using SongSync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SongSync.Services
{
    public interface IServices
    {
        TModel Search<TModel>(string q) where TModel : class;
    }
}
