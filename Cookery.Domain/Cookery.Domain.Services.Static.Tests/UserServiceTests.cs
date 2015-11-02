using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Model;
using System.Linq;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class UserServiceTests
    {
        private readonly IUserService service;
        
        public UserServiceTests()
        {
            this.service = new UserService();
            service.Add(new User { Name = "John" }
                );
            service.Add(new User { Name = "Mike" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();
            var NewUser = new User
                                    {
                                        Name = name
                                    };
            var AddedUser = service.Add(NewUser);
            Assert.IsNotNull(AddedUser);
            Assert.IsTrue(AddedUser.Id > 0);
            Assert.AreEqual(AddedUser.Name, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var user = service.Get(1);
            Assert.IsNotNull(user);
            Assert.AreEqual(user.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var user = service.Get(1);
            var name = user.Name;
            user.Name = Guid.NewGuid().ToString();
            var newUser = service.Get(1);
            Assert.AreEqual(newUser.Name, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var user = service.Get(int.MaxValue);
            Assert.IsNull(user);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var userList = service.Get();
            Assert.IsNotNull(userList);
            Assert.IsTrue(userList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var user = service.Get().First();
            user.Name = user.Name + "1";
            service.Update(user);
            var updatedUser = service.Get(user.Id);
            Assert.IsNotNull(updatedUser);
            Assert.AreEqual(updatedUser.Name,user.Name);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new User { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var user = service.Get().Last();
            service.Delete(user.Id);
            var deletedUser = service.Get(user.Id);
            Assert.IsNull(deletedUser);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
