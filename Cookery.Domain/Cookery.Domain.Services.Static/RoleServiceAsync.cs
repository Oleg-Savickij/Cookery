using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class RoleServiceAsync : DomainServiceAsync<Role>, IRoleServiceAsync
    {
        private readonly List<Role> entities = new List<Role>();

        protected override List<Role> GetEntities()
        {
            return entities;
        }
    }
}

