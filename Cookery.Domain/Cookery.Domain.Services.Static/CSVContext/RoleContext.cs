using Cookery.Domain.Model;
using Cookery.Domain.Services.Static.CSVContext.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static.CSVContext
{
    public class RoleContext : ICSVContext<Role>
    {
        private string _path = @"comments.csv";
        private string context;
        public void Add(Role item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.RoleType + ";" + item.UserID;
                file.WriteLine(context);
            }

        }

        public void Delete(int id)
        {
            using (StreamWriter file = new StreamWriter(_path, false))
            {
                string[] _context = File.ReadAllLines(_path);
                for (int i = 0; i < _context.Length; i++)
                {
                    string[] record = _context[i].Split(';');

                    if (int.Parse(record[0]) == id)
                    {
                        _context[i] = "";
                    }
                    if (_context[i] != "") file.WriteLine(_context[i]);
                }
            }


        }

        public List<Role> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Role> role = new List<Role>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                role.Add(new Role
                {
                    Id = int.Parse(record[0]),
                    RoleType = record[1],
                    UserID = int.Parse(record[2])
                });
            }
            return role;
        }

        public Role Get(int id)
        {
            Role role = new Role();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    role = new Role
                    {
                        Id = int.Parse(record[0]),
                        RoleType = record[1],
                        UserID = int.Parse(record[2])
                    };
                }
            }
            return role;
        }

    }
}
