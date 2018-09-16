using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.DomainModel;

namespace tkct1.DomainModel
{
    public class Patient
    {
        public int Id { get; set; }
        public int Source_id { get; set; }
        public int Sex { get; set; }
        public int Indigenous_status { get; set; }
        public DateTime Date_of_birth { get; set; }
        public Nullable<DateTime> Date_of_death { get; set; }
        public string Post_code { get; set; }
        public Nullable<int> Age { get; set; }
        

        public Status Status { get; set; }

        public List<Notification> Notifications { get; set; }

        //public List<Result> Results { get; set; }

        public List<TSDataPoint> TSDataPoints { get; set; }

        override public string  ToString()
        {
            return String.Format("Id : {0}, Dob : {1}, Dod : {2}",Id,Date_of_birth,Date_of_death);
        }

        public Patient()
        {
            Status = new Status();
            TSDataPoints = new List<TSDataPoint>();
            Notifications = new List<Notification>();
        }
    }
}
