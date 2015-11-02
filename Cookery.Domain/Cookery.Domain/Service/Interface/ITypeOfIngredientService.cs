using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface ITypeOfIngredientService
    {
        TypeOfIngredient Add(TypeOfIngredient item);
        TypeOfIngredient Get(int id);
        List<TypeOfIngredient> Get();
        TypeOfIngredient Update(TypeOfIngredient item);
        void Delete(int id);
    }
}
