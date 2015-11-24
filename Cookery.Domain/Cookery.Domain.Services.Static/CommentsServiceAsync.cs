using Cookery.Domain.Model;
using Cookery.Domain.Services.Static.Common;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class CommentsServiceAsync:DomainServiceAsync<Comments>, ICommentsServiceAsync
    {
        private readonly List<Comments> entities = new List<Comments>();

        protected override List<Comments> GetEntities()
        {
            return entities;
        }
    }
}
