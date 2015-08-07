using Csla;
using Csla.Serialization.Mobile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLAWithDependencyInjection.Business
{
    /// <summary>
    /// An object factory to call dataportal methods
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BusinessObjectFactory<T>: IBusinessObjectFactory<T>
        where T : class, IMobileObject
    {
        public void BeginCreate(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginCreate(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginCreate()
        {
            throw new NotImplementedException();
        }

        public void BeginDelete(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginDelete(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginExecute(T command, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginExecute(T command)
        {
            throw new NotImplementedException();
        }

        public void BeginFetch(object criteria, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginFetch(object criteria)
        {
            throw new NotImplementedException();
        }

        public void BeginFetch()
        {
            throw new NotImplementedException();
        }

        public void BeginUpdate(T obj, object userState)
        {
            throw new NotImplementedException();
        }

        public void BeginUpdate(T obj)
        {
            throw new NotImplementedException();
        }

        public T Create()
        {
            return DataPortal.Create<T>();
        }

        public T Create(object criteria)
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateAsync(object criteria)
        {
            throw new NotImplementedException();
        }

        public Task<T> CreateAsync()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Csla.DataPortalResult<T>> CreateCompleted;

        public void Delete(object criteria)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(object criteria)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Csla.DataPortalResult<T>> DeleteCompleted;

        public T Execute(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> ExecuteAsync(T command)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Csla.DataPortalResult<T>> ExecuteCompleted;

        public T Fetch()
        {
            throw new NotImplementedException();
        }

        public T Fetch(object criteria)
        {
            return DataPortal.Fetch<T>(criteria);
        }

        public Task<T> FetchAsync(object criteria)
        {
            throw new NotImplementedException();
        }

        public Task<T> FetchAsync()
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Csla.DataPortalResult<T>> FetchCompleted;

        public Csla.Core.ContextDictionary GlobalContext
        {
            get { throw new NotImplementedException(); }
        }

        public T Update(T obj)
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateAsync(T obj)
        {
            throw new NotImplementedException();
        }

        public event EventHandler<Csla.DataPortalResult<T>> UpdateCompleted;
    }
}
