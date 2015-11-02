using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class TypeOfIngredient:BaseModel
    {
        public string Name { get; set; }

        public override object Clone()
        {
            return new TypeOfIngredient()
            {
                Name=this.Name,
                Id=this.Id
            };
        }
    }
}
