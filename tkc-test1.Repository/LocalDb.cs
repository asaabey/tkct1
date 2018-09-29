using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.DomainModel;
using tkct1.DomainModel;

namespace tkc_test1.Repository
{
    public class LocalDb
    {
        public IEnumerable<Patient> Patients { get; }

        public LocalDb()
        {
            List<Patient> _patients = new List<Patient>
            {
                new Patient
                {
                    Id = 11111111,
                    Date_of_birth = new DateTime(1975, 01, 04),
                    Sex = 1,
                    TSDataPoints = new List<TSDataPoint>() {
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="120.4", Date=new DateTime(2017,06,02)},
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="63.4", Date=new DateTime(2017,08,02)},
                        new TSDataPoint { Component="eGFR", Type="Numeric", Value="65", Date=new DateTime(2017,06,01)},
                        new TSDataPoint { Component="eGFR", Type="Numeric", Value="68", Date=new DateTime(2017,02,01)},
                    }

                },

                new Patient
                {
                    Id = 11111112,
                    Date_of_birth = new DateTime(1976, 04, 04),
                    Sex = 1,
                    TSDataPoints = new List<TSDataPoint>() {
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="3.2", Date=new DateTime(2017,06,02)},
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="1.2", Date=new DateTime(2017,08,03)},
                        new TSDataPoint { Component="eGFR", Type="Numeric", Value="82", Date=new DateTime(2017,08,03)},
                    }

                },

                new Patient
                {
                    Id = 11111113,
                    Date_of_birth = new DateTime(1976, 04, 04),
                    Date_of_death = new DateTime(2017, 04, 04),
                    Sex = 1,
                    TSDataPoints = new List<TSDataPoint>() {
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="3.2", Date=new DateTime(2017,06,02)},
                        new TSDataPoint { Component="ACR", Type="Numeric", Value="1.2", Date=new DateTime(2017,08,03)},
                        new TSDataPoint { Component="eGFR", Type="Numeric", Value="82", Date=new DateTime(2017,08,03)},
                    }

                },
            };

            Patients = _patients;


        }

        public Patient GetPatientTSD(int id)
        {
            return Patients.Where(o => o.Id == id).FirstOrDefault();

        }

        public List<int> GetPatientIdList()
        {
            return Patients.Select(o => o.Id).ToList();
        }
    }
}
