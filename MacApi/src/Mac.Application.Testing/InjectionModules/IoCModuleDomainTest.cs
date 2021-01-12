using Autofac;
using Mac.Application.Testing.Factories.Interface;
using Mac.Application.Testing.UnitTest;

namespace Mac.Application.Testing.InjectionModules
{
    public class IoCModuleDomainTest : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(BaseDomainTest).Assembly)
                .Where(p => p.IsAssignableTo<IBaseApplicationTestFactory>()).AsSelf();

            base.Load(builder);
        }
    }
}
