using SongSync.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SongSync.Models;

namespace SongSync.Services
{
    public abstract class BaseService 
    {
        public virtual IModelService<TModel> Search<TModel>(string q) where TModel : class
        {
            throw new NotImplementedException();
        }
    }
}
