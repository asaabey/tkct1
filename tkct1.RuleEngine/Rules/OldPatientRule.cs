using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkct1.DomainModel;

namespace tkct1.RuleEngine.Rules
{
    public class OldPatientRule : Rule
    {
        public override void Define()
        {
            Patient p = null;

            When()
                .Match<Patient>(() => p)
                .Exists<Patient>(o => o.Age > 45);
            Then()
                .Do(ctx=> SetIsOldTrue(p));

        }

        private static void SetIsOldTrue(Patient p)
        {
            
        }
    }
}
