using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tkc_test1.DomainModel
{
    public class Status
    {
        public bool FlagCalculatedAge { get; set; }
        public Nullable<int> Age { get; set; }
        public Nullable<bool> FlagInvalidAge { get; set; }
        
        public Nullable<bool> Alive { get; set; }
        public Nullable<bool> LabActivity2y { get; set; }
        public Nullable<bool> HospitalActivity{ get; set; }
        
    }
}
