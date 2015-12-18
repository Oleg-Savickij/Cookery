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
    public class IngredientContext: ICSVContext<Ingredient>
    {
        private string _path = @"ingredients.csv";
        private string context;
        public void Add(Ingredient item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.Name + ";" + item.Weight;
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

        public List<Ingredient> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Ingredient> ingredients = new List<Ingredient>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                ingredients.Add(new Ingredient
                {
                    Id = int.Parse(record[0]),
                    Name = record[1],
                    Weight = int.Parse(record[2])

                });
            }
            return ingredients;
        }

        public Ingredient Get(int id)
        {
            Ingredient ingredient = new Ingredient();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    ingredient = new Ingredient
                    {
                        Id = int.Parse(record[0]),
                        Name = record[1],
                        Weight = int.Parse(record[2])
                    };
                }
            }
            return ingredient;
        }
    }
}
