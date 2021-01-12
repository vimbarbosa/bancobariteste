using Autofac;
using FluentValidation.Results;
using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Vini.Application.Testing.Factories;
using Vini.Application.ViewModels;

namespace Vini.Application.Testing.UnitTest
{
    [TestFixture]
    public class HelloDomainUnitTest : BaseDomainTest
    {
        private readonly HelloAppFactory factory;

        public HelloDomainUnitTest()
        {
            factory = container.Resolve<HelloAppFactory>();
        }

        [Test]
        public async Task Say_Hello_Async()
        {
            try
            {
                var helloViewModel = new HelloViewModel { Message = "Send Messege" };
                var result = await factory.SayHello(helloViewModel);
                Assert.IsTrue(result.IsValid);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(false);
            }
   
        }
    }
}
