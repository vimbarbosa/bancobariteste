using Vini.Infra.CrossCutting.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using System.Reflection;
using MediatR;
using AutoMapper;
using Vini.Application.AutoMapper;

namespace Vini.Application.Testing.InjectionModules
{
    public class IocModuleApplicationTest : Autofac.Module
    {
        protected override void Load(ContainerBuilder containerBuilder)
        {
            string projectPath = AppDomain.CurrentDomain.BaseDirectory.Split(new string[] { @"bin\" }, StringSplitOptions.None)[0];
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(projectPath)
                //.AddJsonFile("appsetting.Development.json")
                .Build();

            containerBuilder.Register(context => configuration).As<IConfiguration>();
            var services = new ServiceCollection();
            NativeInjectorBootStrapper.RegisterServices(services);
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddLogging();
            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
            containerBuilder.Populate(services);

            base.Load(containerBuilder);
        }
    }
}
