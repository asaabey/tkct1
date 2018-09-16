using NRules;
using NRules.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using tkct1.DomainModel;
using tkct1.RuleEngine.Rules;

namespace tkct1.RuleEngine
{
    public class RuleStack
    {
        public void Execute(Patient patient)
        {
            var repository = new RuleRepository();
            
            repository.Load(x => x.From(Assembly.GetExecutingAssembly()));

            var factory = repository.Compile();

            var session = factory.CreateSession();

            //Load Domain

            session.Insert(patient);

            session.Fire();
        }
    }
}
