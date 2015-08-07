using CSLAWithDependencyInjection.Business;
using CSLAWithDependencyInjection.Business.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.UI
{
    public class MyExecutionClass
    {
        public MyExecutionClass()
        {

        }

        public void Run()
        {
            // So that Person.Create() can be avoided and now, this MyExecutionClass is now unit testable.
            var person = this.PersonFactory.Create();

            person.Id = 1;
            person.Name = "Aia Patag";
            person.Save();

            // So that Person.Fetch(1) can be avoided and now, this MyExecutionClass is now unit testable.
            person = this.PersonFactory.Fetch(1);
            person.Name = "Vargas Isaias Patag";

            person.Save();
        }

        [Dependency]
        public IBusinessObjectFactory<IPerson> PersonFactory { get; set; }
    }
}
