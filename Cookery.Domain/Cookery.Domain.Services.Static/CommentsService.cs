using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class CommentsService:ICommentsService
    {
        private readonly List<Comments> _comments = new List<Comments>();

        public Comments Add(Comments item)
        {
            var newComment = (Comments)item.Clone();
            newComment.Id = !_comments.Any() ? 1 : _comments.Max(comment => comment.Id) + 1;
            _comments.Add(newComment);
            return (Comments)newComment.Clone();
        }

        public List<Comments> GetByUserID(int id)
        {
            return _comments.Where(item => item.Id == id).ToList();

        }

        public void Delete(int id)
        {
            var existComment = _comments.SingleOrDefault(comment => comment.Id == id);
            if (existComment == null)
            {
                throw new NullReferenceException();
            }
            _comments.Remove(existComment);
        }

        public List<Comments> Get()
        {
            return _comments.
                Select(item => (Comments)item.Clone()).ToList();
        }

        public Comments Get(int id)
        {
            var comment = _comments.SingleOrDefault(item => item.Id == id);
            return comment == null ? null : (Comments)comment.Clone();
        }

        public Comments Update(Comments item)
        {
            var existComment = _comments.SingleOrDefault(comment => comment.Id == item.Id);
            if (existComment == null)
            {
                throw new NullReferenceException();
            }
            existComment.Text = item.Text;
            return (Comments)existComment.Clone();
        }
    }
}
