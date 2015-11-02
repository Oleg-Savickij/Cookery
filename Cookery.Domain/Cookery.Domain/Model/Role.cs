using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Role:BaseModel
    {
        public string RoleType { get; set; }

        public int UserID { get; set; }
        public override object Clone()
        {
            return new Role
            {
                RoleType = this.RoleType,
                UserID = this.UserID,
                Id = this.Id
            };
        }
    }
}
