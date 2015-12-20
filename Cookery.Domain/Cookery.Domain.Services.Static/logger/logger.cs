using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cookery.Domain.Services.Static.logger
{
    public static class logger
    {     

        public static void OnAddInfo (object sender, int id)
        {
            using (StreamWriter logFile = new StreamWriter("log.txt",true))
            {
                logFile.WriteLine("{0} {1}", "Add new entity with id ",id);
            }
            
        }

        public static void OnDeleteInfo(object sender, int id)
        {
            using (StreamWriter logFile = new StreamWriter("log.txt",true))
            {
                logFile.WriteLine("{0} {1}", "Delete entity with id ",id);
            }

        }

    }
}
