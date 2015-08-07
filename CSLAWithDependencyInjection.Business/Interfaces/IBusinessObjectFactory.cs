using Csla;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Business
{
    /// <summary>
    /// An interface to enforce dataportal methods
    /// This will prevent static factory methods in CSLA and use this to be able to do DI
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IBusinessObjectFactory<T> : IDataPortal<T> { }
}
