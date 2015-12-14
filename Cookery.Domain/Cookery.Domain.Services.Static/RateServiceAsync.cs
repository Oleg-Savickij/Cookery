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
    public class RateServiceAsync : DomainServiceAsync<Rate>, IRateServiceAsync
    {
        private readonly List<Rate> entities = new List<Rate>();

        protected override List<Rate> GetEntities()
        {
            return entities;
        }
    }
}
