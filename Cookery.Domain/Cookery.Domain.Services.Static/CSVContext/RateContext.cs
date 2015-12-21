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
    public class RateContext : ICSVContext<Rate>
    {
        private string _path = @"rates.csv";
        private string context;
        public void Add(Rate item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.RateInformation + ";" + item.UserID + ";" + item.RecipeID;
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

        public List<Rate> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Rate> users = new List<Rate>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                users.Add(new Rate
                {
                    Id = int.Parse(record[0]),
                    RateInformation = record[1],
                    UserID = int.Parse(record[2]),
                    RecipeID = int.Parse(record[3])
                });
            }
            return users;
        }

        public Rate Get(int id)
        {
            Rate rate = new Rate();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    rate = new Rate
                    {
                        Id = int.Parse(record[0]),
                        RateInformation = record[1],
                        UserID = int.Parse(record[2]),
                        RecipeID = int.Parse(record[3])
                    };
                }
            }
            return rate;
        }

    }
}
