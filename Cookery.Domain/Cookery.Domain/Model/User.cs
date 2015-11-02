using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class User:BaseModel
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public DateTime DateOfAdd { get; set; }
        public DateTime LastVisit { get; set; }
        public int FavoriteID { get; set; }

        public override object Clone()
        {
            return new User
            {
                Id = this.Id,
                Name = this.Name,
                Password = this.Password,
                DateOfAdd = this.DateOfAdd,
                LastVisit = this.LastVisit                
            };
        }
    }
}
