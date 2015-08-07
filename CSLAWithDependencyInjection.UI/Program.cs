using Csla;
using CS = Csla.Server;
using CSLAWithDependencyInjection.Bootstrapper.Composers;
using CSLAWithDependencyInjection.Bootstrapper.Composers.Interface;
using CSLAWithDependencyInjection.Business;
using CSLAWithDependencyInjection.Business.BusinessObjects;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.UI
{
    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();

            // only do this if CSLA DataPortal is NOT deployed on a physical server
            // if this Appsetting has value, it means that DataPortal is on a separate physical server
            if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["CslaDataPortalProxy"]))
            {
                // register all the composers you need to properly register dependencies that are used in your business objects
                // add a name to properly distinguish each belonging to type IContainerComposer
                // so that ResolveAll<IContainerComposer>() will actually return a value
                container.RegisterType(typeof(IContainerComposer), typeof(DataContextComposer), typeof(DataContextComposer).ToString());
                container.RegisterType(typeof(IContainerComposer), typeof(JustAnotherSampleServiceComposer), typeof(JustAnotherSampleServiceComposer).ToString());

                ApplicationContext.DataPortalActivator = new CustomDataPortalActivator(container.ResolveAll<IContainerComposer>());
                CS.DataPortal.InterceptorType = typeof(CustomDataPortalInterceptor);
            }

            // call your bootstrapper for your UI dependencies
            bootstrapUIDependencies(container);


            MyExecutionClass runner = container.Resolve<MyExecutionClass>();
            runner.Run();
        }

        static void bootstrapUIDependencies(IUnityContainer container)
        {
            // register all your dependencies that will be needed in the UI
            container.RegisterType(typeof(IBusinessObjectFactory<>), typeof(BusinessObjectFactory<>));
        }
    }
}
