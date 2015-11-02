using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class IngredientServiceTests
    {
        private readonly IIngredientService service;
        public IngredientServiceTests()
        {
            this.service = new IngredientService();
            service.Add(new Ingredient { Name = "Sugar" }
                );
            service.Add(new Ingredient { Name = "Milk" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var newIngredient = new Ingredient
            {
                Name = name
            };
            var AddedIngredient = service.Add(newIngredient);
            Assert.IsNotNull(AddedIngredient);
            Assert.IsTrue(AddedIngredient.Id > 0);
            Assert.AreEqual(AddedIngredient.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var ingredient = service.Get(1);
            Assert.IsNotNull(ingredient);
            Assert.AreEqual(ingredient.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var ingredient = service.Get(1);
            var name = ingredient.Name;
            ingredient.Name = Guid.NewGuid().ToString();
            var newIngredient = service.Get(1);
            Assert.AreEqual(newIngredient.Name, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var ingredient = service.Get(int.MaxValue);
            Assert.IsNull(ingredient);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var ingredientList = service.Get();
            Assert.IsNotNull(ingredientList);
            Assert.IsTrue(ingredientList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var ingredient = service.Get().First();
            ingredient.Name = ingredient.Name + "1";
            service.Update(ingredient);
            var updatedIngredient = service.Get(ingredient.Id);
            Assert.IsNotNull(updatedIngredient);
            Assert.AreEqual(updatedIngredient.Name, ingredient.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Ingredient { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var ingredient = service.Get().Last();
            service.Delete(ingredient.Id);
            var deletedIngredient = service.Get(ingredient.Id);
            Assert.IsNull(deletedIngredient);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
