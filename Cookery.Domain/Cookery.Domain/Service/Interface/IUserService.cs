using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IUserService
    {
        User Add(User item);
        User Get(int id);
        List<User> Get();
        User Update(User item);
        void Delete(int id);
    }
}
