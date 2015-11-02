using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IRecipeService
    {
        Recipe Add(Recipe item);
        Recipe Get(int id);
        List<Recipe> Get();
        Recipe Update(Recipe item);
        void Delete(int id);
    }
}
