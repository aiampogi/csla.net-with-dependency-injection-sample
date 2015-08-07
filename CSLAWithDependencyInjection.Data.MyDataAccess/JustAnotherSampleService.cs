using CSLAWithDependencyInjection.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Data.MyDataAccess
{
    public class JustAnotherSampleService : IJustAnotherSampleService
    {
        public void DoSomething()
        {
            Console.WriteLine("Doing something!");
        }
    }
}
