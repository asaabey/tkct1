using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkc_test1.DomainModel
{
    public class TSDataPoint
    {
        public string Component { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return String.Format("Component:{0}, Type:{3}, Date:{1}, value:{2}", Component, Date, Value, Type);
        }
    }
}
