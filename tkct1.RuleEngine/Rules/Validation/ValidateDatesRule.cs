using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkct1.DomainModel;

namespace tkct1.RuleEngine.Rules.Validation
{
    public class ValidateDatesRule : Rule
    {
        public override void Define()
        {
            Patient _p = new Patient();

            When()
                .Match<Patient>(() => _p, p => p.IsValid==true)
                .Or(o => o
                    .Match<Patient>(()=> _p, p=> p.Date_of_birth> DateTime.UtcNow)
                    .Match<Patient>(() => _p, p => p.Date_of_birth>p.Date_of_death)
                    .Match<Patient>(() => _p, p => p.Date_of_death > DateTime.UtcNow)
                );
            Then()
                .Do(ctx => Console.WriteLine("EXCEPTION--> DateTime"))
                .Do(ctx => SetPatientInvaild(_p))
                .Do(ctx => ctx.Update(_p))
                ;

            
        }

        private void  SetPatientInvaild(Patient _p)
        {
            _p.IsValid = false;
        }

    }
}
