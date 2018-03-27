using System;
using System.Reflection;
using Nancy;
using Nancy.Configuration;
using Nancy.TinyIoc;
using NancyApplication.Containers;

namespace NancyApplication.BootStrap
{
    public class Bootstrapper : DefaultNancyBootstrapper
    {
        public override void Configure(INancyEnvironment environment)
        {
            environment.Tracing(true, true);
        }

        protected override void ConfigureApplicationContainer(TinyIoCContainer container)
        {
            base.ConfigureApplicationContainer(container);
            ConfigurationNamed(DetermineContainerName()).Configure(container);
        }

        private static string DetermineContainerName()
        {
            return $"Containers.{Environment.GetEnvironmentVariable("CONTAINER") ?? "Develop"}";
        }

        private static IContainerConfiguration ConfigurationNamed(
            string containerConfigurationClassName,
            string assemblyName = null
        )
        {
            assemblyName = assemblyName ?? Assembly.GetCallingAssembly().GetName().Name;
            var name = $"{assemblyName}.{containerConfigurationClassName}";
            var type = Type.GetType($"{name}, {assemblyName}", false) ?? throw new NoSuchContainerConfiguration(name);
            return Activator.CreateInstance(type) as IContainerConfiguration;
        }
    }
}
