using Csla.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using CSLAWithDependencyInjection.Data.Interface;
using CSLAWithDependencyInjection.Bootstrapper.Composers.Interface;
using Csla.Reflection;
using System.Diagnostics;

namespace CSLAWithDependencyInjection.Business
{
    /// <summary>
    /// A Custom DataPortalActivator to enable dependency injection in your Business Objects every time a DataPortal invocation is done.
    /// </summary>
    public sealed class CustomDataPortalActivator : IDataPortalActivator
    {
        private IUnityContainer _container;

        /// <summary>
        /// This constructor will need different ContainerComposers to properly register all dependencies used in your business layer.
        /// </summary>
        /// <param name="composers"></param>
        public CustomDataPortalActivator(IEnumerable<IContainerComposer> composers)
        {
            if (composers == null)
            {
                throw new ArgumentNullException("composers");
            }
            this._container = new UnityContainer();
            foreach (var composer in composers)
            {
                // Register dependencies to be used by your business objects
                composer.Compose(this._container);
            }
        }

        public object CreateInstance(Type requestedType)
        {
            if (requestedType == null)
            {
                throw new ArgumentNullException("requestedType");
            }

#if DEBUG
            Debug.WriteLine(string.Format("{0} instance is being created.", requestedType.ToString()));
#endif

            // this is exactly what the default activator does
            return MethodCaller.CreateInstance(getConcreteType(requestedType));
        }

        public void InitializeInstance(object obj)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            Type businessObjectType = obj.GetType();

            // this is where the DI comes into play to inject all your dependencies composed in the constructor
            this._container.BuildUp(businessObjectType, obj);

#if DEBUG
            Debug.WriteLine(string.Format("{0} instance is being initialized and injected with dependencies.", businessObjectType.ToString()));
#endif
        }

        private Type getConcreteType(Type businessObjectInterface)
        {
            if (businessObjectInterface != null && businessObjectInterface.IsInterface)
            {
                var concreteTypeName = string.Concat(businessObjectInterface.Namespace.Replace(".Interfaces", ".BusinessObjects"),
                                                     ".",
                                                     businessObjectInterface.Name.Substring(1), // remove "I". e.g. IPerson -> Person
                                                     ", ",
                                                     businessObjectInterface.Assembly.FullName);

                return Type.GetType(concreteTypeName);
            }
            else
            {
                return businessObjectInterface;
            }
        }


        public void FinalizeInstance(object obj)
        {
            //throw new NotImplementedException();
        }
    }
}
