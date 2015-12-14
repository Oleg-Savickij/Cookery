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
    public class TypeOfIngredientServiceAsync : DomainServiceAsync<TypeOfIngredient>, ITypeOfIngredientServiceAsync
    {
        private readonly List<TypeOfIngredient> entities = new List<TypeOfIngredient>();

        protected override List<TypeOfIngredient> GetEntities()
        {
            return entities;
        }
    }
}
