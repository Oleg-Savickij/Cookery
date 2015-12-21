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
    public class RecipeContext : ICSVContext<Recipe>
    {
        private string _path = @"comments.csv";
        private string context;
        public void Add(Recipe item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.Name + ";" + item.Description + ";" + item.FavoriteID;
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

        public List<Recipe> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Recipe> recipes = new List<Recipe>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                recipes.Add(new Recipe
                {
                    Id = int.Parse(record[0]),
                    Name = record[1],
                    Description = record[2],
                    FavoriteID = int.Parse(record[3])
                });
            }
            return recipes;
        }

        public Recipe Get(int id)
        {
            Recipe recipe = new Recipe();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    recipe = new Recipe
                    {
                        Id = int.Parse(record[0]),
                        Name = record[1],
                        Description = record[2],
                        FavoriteID = int.Parse(record[3])
                    };
                }
            }
            return recipe;
        }

    }
}
