using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Ingredient:BaseModel
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public TypeOfIngredient Type { get; set; }
        public int RecipeID { get; set; }

        public override object Clone()
        {
            return new Ingredient()
            {
                Id=this.Id,
                Name=this.Name,
                Weight=this.Weight,
                Type=this.Type,
                RecipeID=this.RecipeID
            };
        }
    }
}
