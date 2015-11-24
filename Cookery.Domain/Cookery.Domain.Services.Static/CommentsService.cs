using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class CommentsService: DomainService<Comments>,ICommentsService
    {
        private readonly List<Comments> entities = new List<Comments>();

        protected override List<Comments> GetEntities()
        {
            return entities;
        }
    }
}
