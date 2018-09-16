using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkct1.Configuration
{
    public class Connection
    {
        

        public static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["Dbcontext"].ToString();
        }
    }
}
