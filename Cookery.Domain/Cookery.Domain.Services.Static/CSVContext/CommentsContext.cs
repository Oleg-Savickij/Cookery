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
    public class CommentsContext : ICSVContext<Comments>
    {
        private string _path = @"comments.csv";
        private string context;
        public void Add(Comments item)
        {
            using (StreamWriter file = new StreamWriter(_path))
            {
                context = item.Id + ";" + item.Text + ";" + item.Date;
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

        public List<Comments> Get()
        {
            string[] _context = File.ReadAllLines(_path);
            List<Comments> users = new List<Comments>();
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                users.Add(new Comments
                {
                    Id = int.Parse(record[0]),
                    Text = record[1],
                    Date = DateTime.Parse(record[2])
                });
            }
            return users;
        }

        public Comments Get(int id)
        {
            Comments comment = new Comments();
            string[] _context = File.ReadAllLines(_path);
            for (int i = 0; i < _context.Length; i++)
            {
                string[] record = _context[i].Split(';');
                if (id == int.Parse(record[0]))
                {
                    comment = new Comments
                    {
                        Id = int.Parse(record[0]),
                        Text = record[1],
                        Date = DateTime.Parse(record[2])
                    };
                }
            }
            return comment;
        }

    }
}
