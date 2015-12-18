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
    public class FavoriteContext : ICSVContext<Favorite>
    {
        private string _path = @"favorites.csv";
        private string context;
        public void Add(Favorite item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.Name + ";" + item.DateOfAdd;
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

        public List<Favorite> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Favorite> users = new List<Favorite>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                users.Add(new Favorite
                {
                    Id = int.Parse(record[0]),
                    Name = record[1],
                    DateOfAdd = DateTime.Parse(record[2])
                });
            }
            return users;
        }

        public Favorite Get(int id)
        {
            Favorite comment = new Favorite();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    comment = new Favorite
                    {
                        Id = int.Parse(record[0]),
                        Name = record[1],
                        DateOfAdd = DateTime.Parse(record[2])
                    };
                }
            }
            return comment;
        }

    }
}
