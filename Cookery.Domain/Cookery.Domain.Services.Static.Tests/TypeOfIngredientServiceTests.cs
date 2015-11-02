using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Model;
using System.Linq;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class TypeOfIngredientServiceTests
    {
        private readonly ITypeOfIngredientService service;
        public TypeOfIngredientServiceTests()
        {
            this.service = new TypeOfIngredientService();
            service.Add(new TypeOfIngredient { Name = "groats" }
                );
            service.Add(new TypeOfIngredient { Name = "spice" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var newTypeOfIngredient = new TypeOfIngredient
            {
                Name = name
            };
            var AddedTypeOfIngredient = service.Add(newTypeOfIngredient);
            Assert.IsNotNull(AddedTypeOfIngredient);
            Assert.IsTrue(AddedTypeOfIngredient.Id > 0);
            Assert.AreEqual(AddedTypeOfIngredient.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var typeOfIngredient = service.Get(1);
            Assert.IsNotNull(typeOfIngredient);
            Assert.AreEqual(typeOfIngredient.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var typeOfIngredient = service.Get(1);
            var name = typeOfIngredient.Name;
            typeOfIngredient.Name = Guid.NewGuid().ToString();
            var newTypeOfIngredient = service.Get(1);
            Assert.AreEqual(newTypeOfIngredient.Name, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var typeOfIngredient = service.Get(int.MaxValue);
            Assert.IsNull(typeOfIngredient);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var typeOfIngredientList = service.Get();
            Assert.IsNotNull(typeOfIngredientList);
            Assert.IsTrue(typeOfIngredientList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var typeOfIngredient = service.Get().First();
            typeOfIngredient.Name = typeOfIngredient.Name + "1";
            service.Update(typeOfIngredient);
            var updatedTypeOfIngredient = service.Get(typeOfIngredient.Id);
            Assert.IsNotNull(updatedTypeOfIngredient);
            Assert.AreEqual(updatedTypeOfIngredient.Name, typeOfIngredient.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new TypeOfIngredient { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var typeOfIngredient = service.Get().Last();
            service.Delete(typeOfIngredient.Id);
            var deletedTypeOfIngredient = service.Get(typeOfIngredient.Id);
            Assert.IsNull(deletedTypeOfIngredient);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
