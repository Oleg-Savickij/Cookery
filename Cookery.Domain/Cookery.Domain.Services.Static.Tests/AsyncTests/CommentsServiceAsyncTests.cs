using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static.Tests.AsyncTests
{
    [TestClass]
    public class StudentGroupServiceAsyncTests
    {
        private readonly ICommentsServiceAsync service;

        public StudentGroupServiceAsyncTests()
        {
            this.service = new CommentsServiceAsync();

            service.AddAsync(new Comments
            {
                Text = "Tasty!"
            }).Wait();

            service.AddAsync(new Comments
            {
                Text = "Delisious!"
            }).Wait();
        }

        [TestMethod]
        public void AddTest()
        {
            var name = Guid.NewGuid().ToString();

            var newGroup = new Comments
            {
                Text = name
            };

            var addedGroupTask = service.AddAsync(newGroup);

            var addedGroup = addedGroupTask.Result;

            Assert.IsNotNull(addedGroup);
            Assert.IsTrue(addedGroup.Id > 0);
            Assert.AreEqual(addedGroup.Text, name);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var group = service.GetAsync(1).Result;

            Assert.IsNotNull(group);
            Assert.AreEqual(group.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var group = service.GetAsync(1).Result;
            var name = group.Text;
            group.Text = Guid.NewGuid().ToString();
            var newGroup = service.GetAsync(1).Result;
            Assert.AreEqual(newGroup.Text, name);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var group = service.GetAsync(int.MaxValue).Result;

            Assert.IsNull(group);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var groupList = service.GetAsync().Result;

            Assert.IsNotNull(groupList);
            Assert.IsTrue(groupList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var group = service.GetAsync().Result.First();

            group.Text = group.Text + "1";

            service.UpdateAsync(group).Wait();

            var updatedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNotNull(updatedGroup);
            Assert.AreEqual(updatedGroup.Text, group.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void UpdateNotFoundTest()
        {
            service.UpdateAsync(new Comments
            {
                Id = int.MaxValue
            }).Wait();
        }

        [TestMethod]
        public void DeleteTest()
        {
            var group = service.GetAsync().Result.Last();
            service.DeleteAsync(group.Id).Wait();

            var deletedGroup = service.GetAsync(group.Id).Result;

            Assert.IsNull(deletedGroup);
        }

        [TestMethod]
        [ExpectedException(typeof(AggregateException))]
        public void DeleteNotFoundTest()
        {
            service.DeleteAsync(int.MaxValue)
                .Wait();
        }
    }
}
