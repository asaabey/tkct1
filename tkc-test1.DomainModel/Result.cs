using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkc_test1.DomainModel
{
    public class Result
    {
        public string Component { get; set; }
        public DateTime Date_Recorded { get; set; }
        public decimal Value { get; set; }

        public override string ToString()
        {
            return String.Format("Component:{0}, Date:{1}, value:{2}", Component, Date_Recorded, Value);
        }

    }
}
