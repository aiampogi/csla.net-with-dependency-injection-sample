using Csla;
using CS = Csla.Server;
using CSLAWithDependencyInjection.Bootstrapper.Composers;
using CSLAWithDependencyInjection.Bootstrapper.Composers.Interface;
using CSLAWithDependencyInjection.Business;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace CSLAWithDependencyInjection.WCFPortal
{
    public class Global : System.Web.HttpApplication
    {
        // this will only be executed once during the startup of the CSLA WCF DataPortal server
        protected void Application_Start(object sender, EventArgs e)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IContainerComposer), typeof(DataContextComposer), typeof(DataContextComposer).ToString());
            container.RegisterType(typeof(IContainerComposer), typeof(JustAnotherSampleServiceComposer), typeof(JustAnotherSampleServiceComposer).ToString());

            ApplicationContext.DataPortalActivator = new CustomDataPortalActivator(container.ResolveAll<IContainerComposer>());
            CS.DataPortal.InterceptorType = typeof(CustomDataPortalInterceptor);
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {

        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}