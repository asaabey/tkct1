using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;

namespace tkc_test1
{
    public class DbMapper
    {
        //public Universe universe { get; set; }

        public IEnumerable<Patient> Patients { get; set; }

        private string conString = ConfigurationManager.ConnectionStrings["Dbcontext"].ToString();

        public DbMapper()
        {
            using (var con = new SqlConnection(conString))
            {
                Patients= con.Query<Patient>("SELECT * FROM [TKC1].[tkc_registry].[patient_registrations]");

                
            }
        }

        

        public int GetUniverseSize()
        {
            using (var con=new SqlConnection(conString))
            {
                var count = con.ExecuteScalar<int>("SELECT COUNT(*) FROM [TKC1].[tkc_registry].[patient_registrations]");

                return count;
            }
        }
        public string GetConnectionString()
        {
            return conString;
        }
    }
}
