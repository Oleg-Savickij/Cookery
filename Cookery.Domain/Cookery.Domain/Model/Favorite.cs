using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Favorite:BaseModel
    {
        public string Name { get; set; }
        public DateTime DateOfAdd { get; set; }
        public int RecipeID { get; set; }

        public override object Clone()
        {
            return new Favorite()
            {
                Id = this.Id,
                Name=this.Name,
                RecipeID=this.RecipeID,
                DateOfAdd=this.DateOfAdd
            };
        }
    }
}
