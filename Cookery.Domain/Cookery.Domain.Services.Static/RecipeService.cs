using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class RecipeService:IRecipeService
    {
        private readonly List<Recipe> _recipes = new List<Recipe>();

        public Recipe Add(Recipe item)
        {
            var newRecipe = (Recipe)item.Clone();
            newRecipe.Id = !_recipes.Any() ? 1 : _recipes.Max(user => user.Id) + 1;
            _recipes.Add(newRecipe);
            return (Recipe)newRecipe.Clone();
        }

        

        public void Delete(int id)
        {
            var existRecipe = _recipes.SingleOrDefault(recipe => recipe.Id == id);
            if (existRecipe == null)
            {
                throw new NullReferenceException();
            }
            _recipes.Remove(existRecipe);
        }

        public List<Recipe> Get()
        {
            return _recipes.
                Select(item => (Recipe)item.Clone()).ToList();
        }

        public Recipe Get(int id)
        {
            var recipe = _recipes.SingleOrDefault(item => item.Id == id);
            return recipe == null ? null : (Recipe)recipe.Clone();
        }

        public Recipe Update(Recipe item)
        {
            var existRecipe = _recipes.SingleOrDefault(recipe => recipe.Id == item.Id);
            if (existRecipe == null)
            {
                throw new NullReferenceException();
            }
            existRecipe.Name = item.Name;
            return (Recipe)existRecipe.Clone();
        }
    }
}
