using Cookery.Domain;
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
    public class RecipeServiceTests
    {
        private readonly IRecipeService service;
        public RecipeServiceTests()
        {
            this.service = new RecipeService();
            service.Add(new Recipe { Name = "Pie" }
                );
            service.Add(new Recipe { Name = "Cake" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var NewRecipe = new Recipe
            {
                Name = name
            };
            var AddedRecipe = service.Add(NewRecipe);
            Assert.IsNotNull(AddedRecipe);
            Assert.IsTrue(AddedRecipe.Id > 0);
            Assert.AreEqual(AddedRecipe.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var recipe = service.Get(1);
            Assert.IsNotNull(recipe);
            Assert.AreEqual(recipe.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var recipe = service.Get(1);
            var name = recipe.Name;
            recipe.Name = Guid.NewGuid().ToString();
            var newRecipe = service.Get(1);
            Assert.AreEqual(newRecipe.Name, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var recipe = service.Get(int.MaxValue);
            Assert.IsNull(recipe);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var recipeList = service.Get();
            Assert.IsNotNull(recipeList);
            Assert.IsTrue(recipeList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var recipe = service.Get().First();
            recipe.Name = recipe.Name + "1";
            service.Update(recipe);
            var updatedRecipe = service.Get(recipe.Id);
            Assert.IsNotNull(updatedRecipe);
            Assert.AreEqual(updatedRecipe.Name, recipe.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Recipe { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var recipe = service.Get().Last();
            service.Delete(recipe.Id);
            var deletedRecipe = service.Get(recipe.Id);
            Assert.IsNull(deletedRecipe);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    

}

}