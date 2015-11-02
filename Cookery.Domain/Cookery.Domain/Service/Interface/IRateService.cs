using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface IRateService
    {
        Rate Add(Rate item);
        Rate Get(int id);
        List<Rate> Get();
        Rate Update(Rate item);
        void Delete(int id);
    }
}
