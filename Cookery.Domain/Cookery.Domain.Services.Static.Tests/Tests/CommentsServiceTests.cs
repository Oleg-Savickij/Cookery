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
    public class CommentsServiceTests
    {
        private readonly ICommentsService service;
        public CommentsServiceTests()
        {
            this.service = new CommentsService();
            service.Add(new Comments { Text = "Nice" }
                );
            service.Add(new Comments { Text = "Delicious" }
                );
        }
        [TestMethod]
        public void AddTest()
        {
            var text = Guid.NewGuid().ToString();
            var NewComment = new Comments
            {
                Text = text
            };
            var AddedComment = service.Add(NewComment);
            Assert.IsNotNull(AddedComment);
            Assert.IsTrue(AddedComment.Id > 0);
            Assert.AreEqual(AddedComment.Text, text);
        }

        [TestMethod]
        public void GetByIdTest()
        {
            var comment = service.Get(1);
            Assert.IsNotNull(comment);
            Assert.AreEqual(comment.Id, 1);
        }

        [TestMethod]
        public void GetByIdEditTest()
        {
            var comment = service.Get(1);
            var text = comment.Text;
            comment.Text = Guid.NewGuid().ToString();
            var newRecipe = service.Get(1);
            Assert.AreEqual(newRecipe.Text, text);
        }

        [TestMethod]
        public void GetByIdNotFoundTest()
        {
            var comment = service.Get(int.MaxValue);
            Assert.IsNull(comment);
        }

        [TestMethod]
        public void GetAllTest()
        {
            var commentsList = service.Get();
            Assert.IsNotNull(commentsList);
            Assert.IsTrue(commentsList.Count > 0);
        }

        [TestMethod]
        public void UpdateTest()
        {
            var comment = service.Get().First();
            comment.Text = comment.Text + "1";
            service.Update(comment);
            var updatedComment = service.Get(comment.Id);
            Assert.IsNotNull(updatedComment);
            Assert.AreEqual(updatedComment.Text, comment.Text);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void UpdateNotFoundtest()
        {
            service.Update(new Comments { Id = int.MaxValue });
        }

        [TestMethod]
        public void DeleteTest()
        {
            var comment = service.Get().Last();
            service.Delete(comment.Id);
            var deletedComment = service.Get(comment.Id);
            Assert.IsNull(deletedComment);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void DeletedNotFoundTest()
        {
            service.Delete(int.MaxValue);

        }
    }
}
