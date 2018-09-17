using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data.SqlClient;
using tkct1.DomainModel;
using tkct1.Configuration;
using tkc_test1.DomainModel;

namespace tkct1.DAL
{
    public class DbMapper
    {
        
        public IEnumerable<Patient> Patients { get; set; }

        public Patient Patient { get; set; }

                       
        public DbMapper()
        {
        
        }
                
        //public Patient GetPatient(int Id)
        //{
        //    using (var con = new SqlConnection(Connection.GetConnectionString()))
        //    {
        //        string sql = @"SELECT p.id,p.sex,p.date_of_birth, p.date_of_death, 
        //                        r.patient_registration_id,
        //                        r.component_id AS Component, 
        //                        r.date_recorded AS Date_recorded, 
        //                        r.numeric_result AS Value
        //                        FROM[TKC1].[tkc_registry].[patient_registrations] p
        //                        INNER JOIN TKC1.tkc_registry.patient_results_numeric r
        //                        ON p.id = r.patient_registration_id
        //                        WHERE p.id = " + Id.ToString() +"";

        //        var patientDictionary = new Dictionary<int, Patient>();


        //        var p = con.Query<Patient, Result, Patient>(
        //                    sql,
        //                    (patient, result) =>
        //                    {

        //                        if (!patientDictionary.TryGetValue(patient.Id, out Patient patientEntry))
        //                        {
        //                            patientEntry = patient;
        //                            patientEntry.Results = new List<Result>();
        //                            patientDictionary.Add(patientEntry.Id, patientEntry);
        //                        }

        //                        patientEntry.Results.Add(result);
        //                        return patientEntry;

        //                    },
        //                    splitOn: "patient_registration_id"
        //            )
        //            .FirstOrDefault();


        //        return p;
        //    }
        //}

        public Patient GetPatientTSD(int Id)
        {
            using (var con = new SqlConnection(Connection.GetConnectionString()))
            {
                string sql = @";WITH cte1 AS(
                                SELECT 
	                                patient_registration_id,
	                                'Numeric' AS ComponentType,
	                                component_id,
	                                date_recorded,
	                                CAST(numeric_result AS nvarchar) AS Value
                                FROM [tkc_registry].[patient_results_numeric]
                                WHERE patient_registration_id = " + Id + "";
                                
                sql +=@"
                                UNION
                                SELECT 
	                                patient_registration_id,
	                                'Coded' AS ComponentType,
	                                component_id,
	                                date_recorded,
	                                code AS Value
                                FROM [tkc_registry].[patient_results_coded]
                                WHERE patient_registration_id = " + Id +")";

                sql += @"       SELECT 
                                    p.id, p.sex,p.date_of_birth, p.date_of_death,
		                            r.patient_registration_id,
                                    r.component_id AS [Component],
		                            r.ComponentType AS [Type],
		                            r.Value AS [Value],
		                            r.date_recorded AS [Date]
                                FROM tkc_registry.patient_registrations as p
                                LEFT JOIN cte1 AS r ON r.patient_registration_id= p.id
                                WHERE p.id=" + Id + " ORDER BY r.date_recorded";
                            


                var patientDictionary = new Dictionary<int, Patient>();


                var p = con.Query<Patient, TSDataPoint, Patient>(
                            sql,
                            (patient, tsd) =>
                            {

                                if (!patientDictionary.TryGetValue(patient.Id, out Patient patientEntry))
                                {
                                    patientEntry = patient;
                                    patientEntry.TSDataPoints= new List<TSDataPoint>();
                                    patientDictionary.Add(patientEntry.Id, patientEntry);
                                }

                                patientEntry.TSDataPoints.Add(tsd);
                                return patientEntry;

                            },
                            splitOn: "patient_registration_id"
                    )
                    .FirstOrDefault();


                return p;
            }
        }

        public List<int> GetPatientIdList()
        {
            using (var con = new SqlConnection(Connection.GetConnectionString()))
            {
                string sql = @"
                        SELECT TOP(100) id FROM tkc_registry.patient_registrations WHERE id>12000
                ";

                var r = con.Query<int>(sql).ToList();

                return r;
            }

        }

        public void InsertPatientReport(Patient p)
        {
            using (var con = new SqlConnection(Connection.GetConnectionString()))
            {
                string sql = @"
                      INSERT INTO [tkc_reporting].[patient]
                                ([id],[Age])
                      VALUES (@id, @Age)      
                ";

                var r = con.Execute(sql, new { id = p.Id, Age = p.Age });
            }
        }
    }
}
