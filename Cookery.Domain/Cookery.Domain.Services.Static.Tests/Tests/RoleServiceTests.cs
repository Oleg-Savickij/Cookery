using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Cookery.Domain.Service.Interface;
using Cookery.Domain.Model;
using System.Linq;

namespace Cookery.Domain.Services.Static.Tests
{
    [TestClass]
    public class RoleServiceTests
    {
        private readonly IRoleService service;
        public RoleServiceTests()
        {
            this.service = new RoleService();
            service.Add(new Role { RoleType = "Administrator" }
                );
            service.Add(new Role { RoleType = "Register User" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var type = Guid.NewGuid().ToString();
            var NewRole = new Role
            {
                RoleType = type
            };
            var AddedRole = service.Add(NewRole);
            Assert.IsNotNull(AddedRole);
            Assert.IsTrue(AddedRole.Id > 0);
            Assert.AreEqual(AddedRole.RoleType, type);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var role = service.Get(1);
            Assert.IsNotNull(role);
            Assert.AreEqual(role.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var role = service.Get(1);
            var name = role.RoleType;
            role.RoleType = Guid.NewGuid().ToString();
            var newRole = service.Get(1);
            Assert.AreEqual(newRole.RoleType, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var role = service.Get(int.MaxValue);
            Assert.IsNull(role);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var roleList = service.Get();
            Assert.IsNotNull(roleList);
            Assert.IsTrue(roleList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var role = service.Get().First();
            role.RoleType = role.RoleType + "1";
            service.Update(role);
            var updatedRole = service.Get(role.Id);
            Assert.IsNotNull(updatedRole);
            Assert.AreEqual(updatedRole.RoleType, role.RoleType);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Role { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var role = service.Get().Last();
            service.Delete(role.Id);
            var deletedRole = service.Get(role.Id);
            Assert.IsNull(deletedRole);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
