using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkc_test1
{
    public class Patient
    {
        public int Id { get; set; }
        public int Source_id { get; set; }
        public int Sex { get; set; }
        public int Indigenous_status { get; set; }
        public DateTime Date_of_birth { get; set; }
        public DateTime Date_of_death { get; set; }
        public string Post_code { get; set; }

        override public string  ToString()
        {
            return String.Format("Id : {0}, Dob : {1}, Dod : {2}",Id,Date_of_birth,Date_of_death);
        }
    }
}
