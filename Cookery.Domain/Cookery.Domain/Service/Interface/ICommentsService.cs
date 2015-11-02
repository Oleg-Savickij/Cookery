using Cookery.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Service.Interface
{
    public interface ICommentsService
    {
        Comments Add(Comments item);
        Comments Get(int id);
        List<Comments> Get();
        Comments Update(Comments item);
        void Delete(int id);
    }
}
