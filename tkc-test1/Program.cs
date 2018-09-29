using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.Repository;
using tkct1.DAL;
using tkct1.DomainModel;
using tkct1.RuleEngine;

namespace tkct1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProcessSinglePatient();

            PatientList();

            Console.ReadKey();

        }

        static void PatientList()
        {
            //DbMapper db = new DbMapper();

            LocalDb db = new LocalDb();

            //var plist = db.GetPatientIdList();

            var plist = db.GetPatientIdList();
            
            foreach (var id in plist)
            {
                Console.WriteLine("id:{0}",id);
                ProcessSinglePatient(id);
            }

        }

        static void ProcessSinglePatient(int id)
        {
            //DbMapper db = new DbMapper();

            LocalDb db = new LocalDb();

            Patient p = new Patient();

            p = db.GetPatientTSD(id);

            Console.WriteLine("Patient : {0}", p.ToString());

            Console.WriteLine("Patient result count: {0}", p.TSDataPoints.Count());

    

            RuleStack rs = new RuleStack();
            
            rs.Execute(p);
            Console.WriteLine("Age calc done: {3},Patient Age: {0},  Invalid Age Flag:{1}, Alive: {2}", p.Age,p.Status.FlagInvalidAge, p.Status.Alive, p.Status.FlagCalculatedAge);

           



            foreach (var n in p.Notifications)
            {
                Console.WriteLine("--> {0}: {1} |",n.TimeStamp,n.Message);
            }
            Console.WriteLine("--------------------------------------------------");
            // rules 


            //write back to reporting
            //db.InsertPatientReport(p);
        }
    }
}
