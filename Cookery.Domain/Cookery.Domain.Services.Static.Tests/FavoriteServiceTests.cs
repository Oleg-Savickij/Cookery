using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Model;
using System.Linq;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class FavoriteServiceTests
    {
        private readonly IFavoriteService service;
        public FavoriteServiceTests()
        {
            this.service = new FavoriteService();
            service.Add(new Favorite { Name = "Pie" }
                );
            service.Add(new Favorite { Name = "Cake" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var NewFavorite = new Favorite
            {
                Name = name
            };
            var AddedFavorite = service.Add(NewFavorite);
            Assert.IsNotNull(AddedFavorite);
            Assert.IsTrue(AddedFavorite.Id > 0);
            Assert.AreEqual(AddedFavorite.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var favorite = service.Get(1);
            Assert.IsNotNull(favorite);
            Assert.AreEqual(favorite.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var favorite = service.Get(1);
            var name = favorite.Name;
            favorite.Name = Guid.NewGuid().ToString();
            var newFavorite = service.Get(1);
            Assert.AreEqual(newFavorite.Name, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var favorite = service.Get(int.MaxValue);
            Assert.IsNull(favorite);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var favoritesList = service.Get();
            Assert.IsNotNull(favoritesList);
            Assert.IsTrue(favoritesList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var favorite = service.Get().First();
            favorite.Name = favorite.Name + "1";
            service.Update(favorite);
            var updatedFavorite = service.Get(favorite.Id);
            Assert.IsNotNull(updatedFavorite);
            Assert.AreEqual(updatedFavorite.Name, favorite.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Favorite { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var favorite = service.Get().Last();
            service.Delete(favorite.Id);
            var deletedFavorite = service.Get(favorite.Id);
            Assert.IsNull(deletedFavorite);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
