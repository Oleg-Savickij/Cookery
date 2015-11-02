using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Rate:BaseModel
    {
        public string RateInformation { get; set; }
        public int RecipeID { get; set; }
        public int UserID { get; set; }

        public override object Clone()
        {
            return new Rate
            {
                RateInformation = this.RateInformation,
                RecipeID = this.RecipeID,
                UserID = this.UserID,
                Id = this.Id
            };
        }
    }
}
