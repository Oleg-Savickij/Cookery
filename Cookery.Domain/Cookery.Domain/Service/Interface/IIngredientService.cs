using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IIngredientService
    {
        Ingredient Add(Ingredient item);
        Ingredient Get(int id);
        List<Ingredient> Get();
        Ingredient Update(Ingredient item);
        void Delete(int id);
    }
}
