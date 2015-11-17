using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.CommonInterface
{
    public interface IDomainServiceAsync<T> where T : BaseModel
    {
        Task<T> AddAsync(T entity);

        Task<T> GetAsync(int id);

        Task<List<T>> GetAsync();

        Task<T> UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
