using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cookery.Domain.Model;

namespace Cookery.Domain.Services.Static
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new List<User>();

        public User Add(User item)
        {
            var newUser = (User)item.Clone();
            newUser.Id = !_users.Any() ? 1 : _users.Max(user => user.Id) + 1;
            _users.Add(newUser);
            return (User)newUser.Clone();
        }

        public void Delete(int id)
        {
            var existUser = _users.SingleOrDefault(user => user.Id == id);
            if (existUser == null)
            {
                throw new NullReferenceException();
            }
            _users.Remove(existUser);
        }

        public List<User> Get()
        {
            return _users.
                Select(item => (User)item.Clone()).ToList();
        }

        public User Get(int id)
        {
            var user = _users.SingleOrDefault(item => item.Id == id);
            return user == null ? null : (User)user.Clone();
        }

        public User Update(User item)
        {
            var existUser = _users.SingleOrDefault(user => user.Id == item.Id);
            if(existUser == null)
            {
                throw new NullReferenceException();
            }
            existUser.Name = item.Name;
            return (User)existUser.Clone();
        }
    }
}
