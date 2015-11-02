using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IFavoriteService
    {
        Favorite Add(Favorite item);
        Favorite Get(int id);
        List<Favorite> Get();
        Favorite Update(Favorite item);
        void Delete(int id);
    }
}
