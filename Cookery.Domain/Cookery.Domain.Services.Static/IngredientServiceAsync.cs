﻿using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Services.Static.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class IngredientServiceAsync : DomainServiceAsync<Ingredient>, IIngredientServiceAsync
    {
        private readonly List<Ingredient> entities = new List<Ingredient>();

        protected override List<Ingredient> GetEntities()
        {
            return entities;
        }
    }
}
