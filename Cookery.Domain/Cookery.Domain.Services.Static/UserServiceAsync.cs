using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookery.Domain.Model;
using Cookery.Domain.Services.Static.Common;

namespace Cookery.Domain.Services.Static
{
    public class UserServiceAsync : DomainServiceAsync<User>, IUserServiceAsync
    {
        private readonly List<User> entities = new List<User>();

        protected override List<User> GetEntities()
        {
            return entities;
        }
    }
}
