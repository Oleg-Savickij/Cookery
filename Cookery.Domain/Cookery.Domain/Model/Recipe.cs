using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Recipe: BaseModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int FavoriteID { get; set; }

        public override object Clone()
        {
            return new Recipe
            {
                Name = this.Name,
                Description = this.Description,
                Id = this.Id
            };
        }
    }
}
