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
    public class TypeOfIngredientContext : ICSVContext<TypeOfIngredient>
    {
        private string _path = @"ingredients.csv";
        private string context;
        public void Add(TypeOfIngredient item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.Name;
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

        public List<TypeOfIngredient> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<TypeOfIngredient> type = new List<TypeOfIngredient>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                type.Add(new TypeOfIngredient
                {
                    Id = int.Parse(record[0]),
                    Name = record[1]

                });
            }
            return type;
        }

        public TypeOfIngredient Get(int id)
        {
            TypeOfIngredient type = new TypeOfIngredient();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    type = new TypeOfIngredient
                    {
                        Id = int.Parse(record[0]),
                        Name = record[1]
                    };
                }
            }
            return type;
        }
    }
}
