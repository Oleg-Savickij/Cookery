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
    public class RecipeServiceAsync : DomainServiceAsync<Recipe>, IRecipeServiceAsync
    {
        private readonly List<Recipe> entities = new List<Recipe>();

        protected override List<Recipe> GetEntities()
        {
            return entities;
        }
    }
}
