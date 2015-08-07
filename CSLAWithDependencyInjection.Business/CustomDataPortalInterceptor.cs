using Csla.Core;
using Csla.Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Business
{
    public sealed class CustomDataPortalInterceptor : IInterceptDataPortal
    {
        public void Complete(InterceptArgs e)
        {
            if (e == null)
            {
                throw new ArgumentException("e");
            }
            if (e.Result != null
                && e.Result.ReturnObject != null
                && e.Result.ReturnObject is IDisposable
                && e.Result.ReturnObject is IBusinessObject)
            {
                var qs1CrxBusinessObject = e.Result.ReturnObject as IDisposable;
                qs1CrxBusinessObject.Dispose();

#if DEBUG
                Debug.WriteLine(string.Format("{0} has completed the DataPortal lifecycle. Disposing successful.", e.ObjectType.ToString()));
#endif
            }
        }

        public void Initialize(InterceptArgs e)
        {
            // put any logic that is needed in the first step of a DP lifecycle (not instantiated yet)
#if DEBUG
            Debug.WriteLine(string.Format("{0} has started the DataPortal lifecycle.", e.ObjectType.ToString()));
#endif
        }
    }
}
