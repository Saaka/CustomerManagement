using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace CustomerManagement.IoC
{
    public class AutofacWebApiDependencyResolver : IDependencyResolver
    {
        private readonly ILifetimeScope container;
        private readonly IDependencyScope rootScope;
        private bool isDisposed;

        public AutofacWebApiDependencyResolver(IContainer container)
        {
            if (container == null)
                throw new ArgumentNullException("Container can't be null");

            this.container = container;
            this.rootScope = new AutofacWebApiDependencyScope(this.container);
        }

        ~AutofacWebApiDependencyResolver()
        {
            Dispose(false);
        }

        public IDependencyScope BeginScope()
        {
            var lifetimeScope = container.BeginLifetimeScope();
            return new AutofacWebApiDependencyScope(lifetimeScope);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public object GetService(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("Service type can't be null");

            return rootScope.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (serviceType == null)
                throw new ArgumentNullException("Service type can't be null");

            return rootScope.GetServices(serviceType);
        }

        private void Dispose(bool disposing)
        {
            if(!isDisposed)
            {
                if(disposing)
                {
                    if(rootScope != null)
                        rootScope.Dispose();
                }

                isDisposed = true;
            }
        }
    }
}