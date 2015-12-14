using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Model;
using System.Linq;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class RateServiceTests
    {
        private readonly IRateService service;
        public RateServiceTests()
        {
            this.service = new RateService();
            service.Add(new Rate { RateInformation = "5", }
                );
            service.Add(new Rate { RateInformation = "3" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var newRate = new Rate
            {
                RateInformation = name
            };
            var AddedRate = service.Add(newRate);
            Assert.IsNotNull(AddedRate);
            Assert.IsTrue(AddedRate.Id > 0);
            Assert.AreEqual(AddedRate.RateInformation, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var rate = service.Get(1);
            Assert.IsNotNull(rate);
            Assert.AreEqual(rate.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var rate = service.Get(1);
            var name = rate.RateInformation;
            rate.RateInformation = Guid.NewGuid().ToString();
            var newIngredient = service.Get(1);
            Assert.AreEqual(newIngredient.RateInformation, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var rate = service.Get(int.MaxValue);
            Assert.IsNull(rate);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var rateList = service.Get();
            Assert.IsNotNull(rateList);
            Assert.IsTrue(rateList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var rate = service.Get().First();
            rate.RateInformation = rate.RateInformation + "1";
            service.Update(rate);
            var updatedRate = service.Get(rate.Id);
            Assert.IsNotNull(updatedRate);
            Assert.AreEqual(updatedRate.RateInformation, rate.RateInformation);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Rate { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var rate = service.Get().Last();
            service.Delete(rate.Id);
            var deletedRate = service.Get(rate.Id);
            Assert.IsNull(deletedRate);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
