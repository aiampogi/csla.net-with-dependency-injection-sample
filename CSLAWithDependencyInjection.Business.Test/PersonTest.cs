using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CSLAWithDependencyInjection.Data.Models;
using Moq;
using CSLAWithDependencyInjection.Bootstrapper;
using CSLAWithDependencyInjection.Data.Interface;
using System.Collections.Generic;
using Microsoft.Practices.Unity;
using Csla;
using CSLAWithDependencyInjection.Bootstrapper.Composers.Interface;
using CSLAWithDependencyInjection.Business.BusinessObjects;
using CS = Csla.Server;

namespace CSLAWithDependencyInjection.Business.Test
{
    [TestClass]
    public class PersonTest
    {
        [TestMethod]
        public void DataPortal_FetchTest()
        {
            int id = 1;
            string name = "Aia";

            PersonEntity mockedPersonEntity = new PersonEntity()
            {
                Id = id,
                Name = name
            };

            // mock the context
            var context = new Mock<IDataContext>(MockBehavior.Strict);
            context.Setup(c => c.Persons).Returns(new List<PersonEntity>() { mockedPersonEntity });
            context.Setup(c => c.Dispose())
                .Callback(() =>
                    {
                        //do nothing;
                    });


            // mock the datacontext composer
            var dataContextComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            dataContextComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IDataContext>(context.Object);
                        });

            // mock the additional services used in the BO
            var justAnotherService = new Mock<IJustAnotherSampleService>(MockBehavior.Strict);
            justAnotherService.Setup(j => j.DoSomething());
            var justAnotherServiceComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            justAnotherServiceComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IJustAnotherSampleService>(justAnotherService.Object);
                        });

            List<IContainerComposer> compositors = new List<IContainerComposer>()
            {
                dataContextComposer.Object,
                justAnotherServiceComposer.Object
            };

            // set the CustomDataPortalActivator to do DI using the mocked objects
            ApplicationContext.DataPortalActivator = new CustomDataPortalActivator(compositors);
            CS.DataPortal.InterceptorType = typeof(CustomDataPortalInterceptor);

            var actual = Person.Fetch(1);

            Assert.AreEqual(name, actual.Name);
        }

        [TestMethod]
        public void DataPortal_InsertTest()
        {
            var personEntities = new List<PersonEntity>();

            // mock the context
            var context = new Mock<IDataContext>(MockBehavior.Strict);
            context.Setup(c => c.Persons).Returns(personEntities);
            context.Setup(c => c.SaveChanges()).Returns(1);
            context.Setup(c => c.Dispose())
                .Callback(() =>
                {
                    //do nothing;
                });

            // mock the datacontext composer
            var dataContextComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            dataContextComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IDataContext>(context.Object);
                        });

            // mock the additional services used in the BO
            var justAnotherService = new Mock<IJustAnotherSampleService>(MockBehavior.Strict);
            justAnotherService.Setup(j => j.DoSomething());
            var justAnotherServiceComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            justAnotherServiceComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IJustAnotherSampleService>(justAnotherService.Object);
                        });

            List<IContainerComposer> compositors = new List<IContainerComposer>()
            {
                dataContextComposer.Object,
                justAnotherServiceComposer.Object
            };

            // set the CustomDataPortalActivator to do DI using the mocked objects
            ApplicationContext.DataPortalActivator = new CustomDataPortalActivator(compositors);
            CS.DataPortal.InterceptorType = typeof(CustomDataPortalInterceptor);

            var actual = Person.Create();
            actual.Id = 2;
            actual.Name = "Aia Patag";

            var savedBO = actual.Save();

            Assert.AreEqual(1, personEntities.Count);
            Assert.AreEqual(2, savedBO.Id);
            Assert.AreEqual("Aia Patag", savedBO.Name);
        }

        [TestMethod]
        public void DataPortal_UpdateTest()
        {
            int id = 1;
            string name = "Aia";

            var mockedPersonEntity = new PersonEntity()
            {
                Id = id,
                Name = name
            };

            var personEntities = new List<PersonEntity>() { mockedPersonEntity };

            // mock the context
            var context = new Mock<IDataContext>(MockBehavior.Strict);
            context.Setup(c => c.Persons).Returns(personEntities);
            context.Setup(c => c.SaveChanges()).Returns(1);
            context.Setup(c => c.Dispose())
                .Callback(() =>
                {
                    //do nothing;
                });

            // mock the datacontext composer
            var dataContextComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            dataContextComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IDataContext>(context.Object);
                        });

            // mock the additional services used in the BO
            var justAnotherService = new Mock<IJustAnotherSampleService>(MockBehavior.Strict);
            justAnotherService.Setup(j => j.DoSomething());
            var justAnotherServiceComposer = new Mock<IContainerComposer>(MockBehavior.Strict);
            justAnotherServiceComposer.Setup(x => x.Compose(It.IsAny<IUnityContainer>()))
                        .Callback((IUnityContainer c) =>
                        {
                            c.RegisterInstance<IJustAnotherSampleService>(justAnotherService.Object);
                        });

            List<IContainerComposer> compositors = new List<IContainerComposer>()
            {
                dataContextComposer.Object,
                justAnotherServiceComposer.Object
            };

            // set the CustomDataPortalActivator to do DI using the mocked objects
            ApplicationContext.DataPortalActivator = new CustomDataPortalActivator(compositors);
            CS.DataPortal.InterceptorType = typeof(CustomDataPortalInterceptor);

            var actual = Person.Fetch(1);
            actual.Name = "Aia Patag";

            var savedBO = actual.Save();

            Assert.AreEqual(1, personEntities.Count);
            Assert.AreEqual("Aia Patag", personEntities[0].Name);
            Assert.AreEqual("Aia Patag", savedBO.Name);
        }
    }
}
