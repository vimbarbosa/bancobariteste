using Autofac;
using Vini.Application.Testing.Factories.Interface;
using Vini.Application.Testing.UnitTest;

namespace Vini.Application.Testing.InjectionModules
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
