using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using Cookery.Domain.Services.Static.CSVContext;
using Cookery.Domain.Services.Static.CSVContext.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class IngredientService : DomainService<Ingredient>, IIngredientService
    {
        private readonly ICSVContext<Ingredient> _favorites = new IngredientContext();
        protected override List<Ingredient> GetEntities()
        {
            return _favorites.Get();
        }


    }
}
