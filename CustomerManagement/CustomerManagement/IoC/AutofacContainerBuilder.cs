using Autofac;
using Autofac.Integration.WebApi;
using AutoMapper;
using CustomerManagement.Business.Customer;
using CustomerManagement.DAL.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace CustomerManagement.IoC
{
    public class AutofacContainerBuilder
    {
        public IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .AsImplementedInterfaces()
                .AsSelf();

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>()
                .As<IUnitOfWork>();

            builder.RegisterType<CustomerManager>()
                .As<ICustomerManager>();

            RegisterAutomapper(builder);

            return builder.Build();
        }

        private void RegisterAutomapper(ContainerBuilder builder)
        {
            IMapper mapper = new Mappers.AutomapperSetting().CreateMapper();
            builder.RegisterInstance(mapper).As<IMapper>();
        }
    }
}