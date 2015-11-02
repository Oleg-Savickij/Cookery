using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IRoleService
    {
        Role Add(Role item);
        Role Get(int id);
        List<Role> Get();
        Role Update(Role item);
        void Delete(int id);
    }
}
