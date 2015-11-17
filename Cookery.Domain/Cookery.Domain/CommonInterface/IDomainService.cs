using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model.CommonInterface
{
    public interface IDomainService<T> where T :BaseModel
    {
        T Add(T item);
        T Get(int id);
        List<T> Get();
        T Update(T item);
        void Delete(int id);
    }
}
