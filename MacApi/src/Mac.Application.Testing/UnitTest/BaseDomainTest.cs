using Autofac;
using Mac.Application.Testing.InjectionModules;

namespace Mac.Application.Testing.UnitTest
{
    public class BaseDomainTest
    {
        protected readonly IContainer container;

        protected BaseDomainTest()
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterModule(new IoCModuleDomainTest());
            containerBuilder.RegisterModule(new IocModuleApplicationTest());
            container = containerBuilder.Build();
        }
    }
}
