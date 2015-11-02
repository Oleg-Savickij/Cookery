using Cookery.Domain.Model;
using Cookery.Domain.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static
{
    public class RoleService: IRoleService
    {
        private readonly List<Role> _roles = new List<Role>();

        public Role Add(Role item)
        {
            var newRole = (Role)item.Clone();
            newRole.Id = !_roles.Any() ? 1 : _roles.Max(rate => rate.Id) + 1;
            _roles.Add(newRole);
            return (Role)newRole.Clone();
        }

        public List<Role> GetByUserID(int id)
        {
            return _roles.Where(item => item.Id == id).ToList();

        }

        public void Delete(int id)
        {
            var existRole = _roles.SingleOrDefault(role => role.Id == id);
            if (existRole == null)
            {
                throw new NullReferenceException();
            }
            _roles.Remove(existRole);
        }

        public List<Role> Get()
        {
            return _roles.
                Select(item => (Role)item.Clone()).ToList();
        }

        public Role Get(int id)
        {
            var role = _roles.SingleOrDefault(item => item.Id == id);
            return role == null ? null : (Role)role.Clone();
        }

        public Role Update(Role item)
        {
            var existRole = _roles.SingleOrDefault(role => role.Id == item.Id);
            if (existRole == null)
            {
                throw new NullReferenceException();
            }
            existRole.RoleType = item.RoleType;
            return (Role)existRole.Clone();
        }
    }
}
