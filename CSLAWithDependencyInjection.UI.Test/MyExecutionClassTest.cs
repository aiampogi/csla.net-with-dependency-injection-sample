using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using CSLAWithDependencyInjection.Business.Interfaces;
using CSLAWithDependencyInjection.Business;

namespace CSLAWithDependencyInjection.UI.Test
{
    [TestClass]
    public class MyExecutionClassTest
    {
        [TestMethod]
        public void RunTest()
        {
            try
            {
                var person = new Mock<IPerson>();
                person.Setup(p => p.Id).Returns(1);
                person.Setup(p => p.Name).Returns("Aia");
                person.Setup(p => p.Save()).Callback(() =>
                    {
                        // do nothing
                    });

                var personFactory = new Mock<IBusinessObjectFactory<IPerson>>();
                personFactory.Setup(p => p.Create()).Returns(Mock.Of<IPerson>());
                personFactory.Setup(p => p.Fetch(It.IsAny<int>())).Returns(person.Object);

                MyExecutionClass actual = new MyExecutionClass();
                actual.PersonFactory = personFactory.Object;

                actual.Run();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }
    }
}
