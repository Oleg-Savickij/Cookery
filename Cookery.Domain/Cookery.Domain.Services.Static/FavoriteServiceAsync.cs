using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class FavoriteServiceAsync:DomainServiceAsync<Favorite>,IFavoriteServiceAsync
    {
        private readonly List<Favorite> entities = new List<Favorite>();

        protected override List<Favorite> GetEntities()
        {
            return entities;
        }
    }
}
