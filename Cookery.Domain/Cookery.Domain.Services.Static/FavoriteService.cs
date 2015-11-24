using Cookery.Domain.Model;
using Cookery.Domain.Model.CommonInterface;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class FavoriteService:DomainService<Favorite>,IFavoriteService
    {
        private readonly List<Favorite> _favorites = new List<Favorite>();
        protected override List<Favorite> GetEntities()
        {
            return _favorites;
        }


    }
}
