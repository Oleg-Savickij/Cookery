using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookery.Domain.Model;
using Cookery.Domain.Services.Static.Common;
using Cookery.Domain.Services.Static.CSVContext.Common;
using Cookery.Domain.Services.Static.CSVContext;

namespace Cookery.Domain.Services.Static
{
    public class UserService : DomainService<User>, IUserService
    {
        private readonly ICSVContext<User> _users = new UserContext();
        protected override List<User> GetEntities()
        {
            return _users.Get();
        }


    }
}
