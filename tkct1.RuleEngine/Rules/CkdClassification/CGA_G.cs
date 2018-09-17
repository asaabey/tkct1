using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.DomainModel;
using tkct1.DomainModel;

namespace tkct1.RuleEngine.Rules.CkdClassification
{
    public class LastEgfrTSD : Rule
    {
        public override void Define()
        {
            Patient patient = null;

            TSDataPoint tsdp = null;

            When()                
                //.Match(() => patient, o => o.Status.Alive == true, o => o.HasComponent("eGFR"))
                .Match(() => patient, o => o.IsValid == true, o => o.Status.Alive == true, o => o.HasComponent("eGFR"))
                .Let(() => tsdp, () => patient.GetLastTimeSeriesDataPoint("eGFR"))
                ;

            Then()

                .Do(ctx => LasteGFR(tsdp))
                ;
        }

        private static void LasteGFR(TSDataPoint tsdp)
        {
            if (tsdp != null)
            {
                Console.WriteLine("--------------->{0}", tsdp.ToString());
            }


        }




    }

    public class D90EgfrTSD : Rule
    {
        public override void Define()
        {

            Patient patient = null;

            TSDataPoint tsdp = null;

            When()
                
                .Match(() => patient, o => o.IsValid == true, o => o.Status.Alive == true, o => o.HasComponent("eGFR"))
                .Let(() => tsdp, () => patient.GetNthTimeSeriesDataPointWithOffset("eGFR",90, 1))
                ;

            Then()

                .Do(ctx => D90Egfr(tsdp))
                ;

           
        }

        private static void D90Egfr(TSDataPoint tsdp)
        {
            if (tsdp != null)
            {
                Console.WriteLine("--D90 >{0}", tsdp.ToString());
            }


        }
    }
}
