using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static.CSVContext.Common
{
    public interface ICSVContext<T> where T :BaseModel
    {
        void Add(T item);
        T Get(int id);
        List<T> Get();
        void Delete(int id);
    }
}
