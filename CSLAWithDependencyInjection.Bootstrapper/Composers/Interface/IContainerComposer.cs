using CSLAWithDependencyInjection.Data.Interface;
using CSLAWithDependencyInjection.Data.MyDataAccess;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Bootstrapper.Composers.Interface
{
    public interface IContainerComposer
    {
        void Compose(IUnityContainer container);
    }
}
