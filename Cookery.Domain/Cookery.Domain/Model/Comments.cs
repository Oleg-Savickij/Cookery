using Cookery.Domain.Model.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Model
{
    public class Comments:BaseModel
    {
        public string Text { get; set; }
        public DateTime Date { get; set; }
        public int UserID { get; set; }
      

        public override object Clone()
        {
            return new Comments
            {
                Text = this.Text,
                Id = this.Id,
                Date = this.Date
            };
        }
    }
}
