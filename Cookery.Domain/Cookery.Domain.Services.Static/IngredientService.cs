using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class IngredientService:IIngredientService
    {
        private readonly List<Ingredient> _igredients = new List<Ingredient>();

        public Ingredient Add(Ingredient item)
        {
            var newIngredient = (Ingredient)item.Clone();
            newIngredient.Id = !_igredients.Any() ? 1 : _igredients.Max(comment => comment.Id) + 1;
            _igredients.Add(newIngredient);
            return (Ingredient)newIngredient.Clone();
        }

        public List<Ingredient> GetByIngedientID(int id)
        {
            return _igredients.Where(item => item.Id == id).ToList();

        }

        public void Delete(int id)
        {
            var existIngredient = _igredients.SingleOrDefault(ingrediet => ingrediet.Id == id);
            if (existIngredient == null)
            {
                throw new NullReferenceException();
            }
            _igredients.Remove(existIngredient);
        }

        public List<Ingredient> Get()
        {
            return _igredients.
                Select(item => (Ingredient)item.Clone()).ToList();
        }

        public Ingredient Get(int id)
        {
            var ingredient = _igredients.SingleOrDefault(item => item.Id == id);
            return ingredient == null ? null : (Ingredient)ingredient.Clone();
        }

        public Ingredient Update(Ingredient item)
        {
            var existIngredient = _igredients.SingleOrDefault(ingredient => ingredient.Id == item.Id);
            if (existIngredient == null)
            {
                throw new NullReferenceException();
            }
            existIngredient.Name = item.Name;
            return (Ingredient)existIngredient.Clone();
        }
    }
}
