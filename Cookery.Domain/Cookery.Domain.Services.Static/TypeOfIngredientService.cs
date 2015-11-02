using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class TypeOfIngredientService:ITypeOfIngredientService
    {
        private readonly List<TypeOfIngredient> _types = new List<TypeOfIngredient>();

        public TypeOfIngredient Add(TypeOfIngredient item)
        {
            var newTypeOfIngredient = (TypeOfIngredient)item.Clone();
            newTypeOfIngredient.Id = !_types.Any() ? 1 : _types.Max(rate => rate.Id) + 1;
            _types.Add(newTypeOfIngredient);
            return (TypeOfIngredient)newTypeOfIngredient.Clone();
        }

        public List<TypeOfIngredient> GetByUserID(int id)
        {
            return _types.Where(item => item.Id == id).ToList();

        }

        public void Delete(int id)
        {
            var existTypeOfIngredient = _types.SingleOrDefault(type => type.Id == id);
            if (existTypeOfIngredient == null)
            {
                throw new NullReferenceException();
            }
            _types.Remove(existTypeOfIngredient);
        }

        public List<TypeOfIngredient> Get()
        {
            return _types.
                Select(item => (TypeOfIngredient)item.Clone()).ToList();
        }

        public TypeOfIngredient Get(int id)
        {
            var typeOfIngredient = _types.SingleOrDefault(item => item.Id == id);
            return typeOfIngredient == null ? null : (TypeOfIngredient)typeOfIngredient.Clone();
        }

        public TypeOfIngredient Update(TypeOfIngredient item)
        {
            var existTypeOfIngredient = _types.SingleOrDefault(type => type.Id == item.Id);
            if (existTypeOfIngredient == null)
            {
                throw new NullReferenceException();
            }
            existTypeOfIngredient.Name = item.Name;
            return (TypeOfIngredient)existTypeOfIngredient.Clone();
        }
    }
}
