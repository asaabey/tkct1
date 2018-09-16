using NRules.Fluent.Dsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tkc_test1.DomainModel;
using tkct1.DomainModel;

namespace tkct1.RuleEngine.Rules
{
    public class AliveStatusTrue : Rule
    {
        public override void Define()
        {
            Patient p = null;
            When()
                .Match<Patient>(() => p, o => o.Date_of_death == null);
            Then()
                .Do(ctx => SetAliveStatusTrue(p))
                .Do(ctx => SetAge(p))
                .Do(ctx => SetFlagCalculatedAge(p));
        }

        private static void SetAliveStatusTrue(Patient p)
        {
            p.Status.Alive = true;
        }
        private static void SetAge(Patient p)
        {
            p.Age = (int)(DateTime.Today.Subtract(p.Date_of_birth).TotalDays / 365.25);
        }
        private static void SetFlagCalculatedAge(Patient p)
        {
            p.Status.FlagCalculatedAge = true;
            p.Notifications.Add(new Notification() { Message ="Age Calculated", TimeStamp=DateTime.Now });
        }
    }

    public class AliveStatusFalse : Rule
    {
        public override void Define()
        {
            Patient p = null;
            When()
                .Match<Patient>(() => p, o => o.Date_of_death != null);
            Then()
                .Do(ctx => SetAliveStatusFalse(p));
                //.Do(ctx =>  );
        }
        private static void SetAliveStatusFalse(Patient p)
        {
            p.Status.Alive = false;
        }


    }

    //Not working
    public class ValidateAge : Rule
    {
        public override void Define()
        {
            Patient p = null;
            When()
                .Match<Patient>(() => p, o => o.Status.FlagCalculatedAge==true)
                .Match<Patient>(() => p, o => o.Age < 0);

            Then()
                .Do(ctx => SetFlagInvalidAge(p));
        }
        private static void SetFlagInvalidAge(Patient p)
        {
            p.Status.FlagInvalidAge = true;
        }

    }
}
