using Csla;
using Csla.Core;
using CSLAWithDependencyInjection.Data.Interface;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Business.BaseClasses
{
    /// <summary>
    /// A base class that has the dependencies used by all the derived businessbase classes.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [Serializable]
    public abstract class CustomBusinessBase<T> : BusinessBase<T>, IDisposable
        where T : BusinessBase<T>
    {
        protected CustomBusinessBase()
        {

        }

        [NonSerialized]
        private IDataContext _context;

        [Dependency]
        protected IDataContext Context
        {
            get { return this._context; }
            set { this._context = value; }
        }

        [NonSerialized]
        private IJustAnotherSampleService _jasService;

        [Dependency]
        protected IJustAnotherSampleService JASService
        {
            get { return this._jasService; }
            set { this._jasService = value; }
        }

        public void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
    }
}
