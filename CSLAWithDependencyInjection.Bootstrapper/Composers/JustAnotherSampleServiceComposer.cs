using CSLAWithDependencyInjection.Bootstrapper.Composers.Interface;
using CSLAWithDependencyInjection.Data.Interface;
using CSLAWithDependencyInjection.Data.MyDataAccess;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Bootstrapper.Composers
{
    public class JustAnotherSampleServiceComposer : IContainerComposer
    {
        public void Compose(IUnityContainer container)
        {
            container.RegisterType(typeof(IJustAnotherSampleService), typeof(JustAnotherSampleService));
        }
    }
}
