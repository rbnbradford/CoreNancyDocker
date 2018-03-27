using System.Collections.Generic;
using Domain.Domain;
using Domain.Infrastructure;
using Domain.Infrastructure.Dtos;
using Domain.Representation;
using Nancy;
using Nancy.Bootstrapper;
using Nancy.Configuration;
using Nancy.TinyIoc;

namespace NancyApplication.BootStrap
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        protected override void RegisterInstances(TinyIoCContainer container,
            IEnumerable<InstanceRegistration> instanceRegistrations)
        {
            base.RegisterInstances(container, instanceRegistrations);

            container.Register(new Dictionary<string, DuckRecord>());

            container.Register<IDuckRepository, MemoryDuckRepository>()
                .AsSingleton();
            container.Register<IDuckReadRepository, MemoryDuckReadRepository>()
                .AsSingleton();
        }
    }
}
