using Nancy.TinyIoc;

namespace NancyApplication.Containers
{
    internal abstract class ExtendingContainerConfiguration : IContainerConfiguration
    {
        private TinyIoCContainer _container;

        public void Configure(TinyIoCContainer container)
        {
            _container = container;
            ConfigureContainer(container);
        }

        protected abstract void ConfigureContainer(TinyIoCContainer container);

        protected void Extend<T>() where T : IContainerConfiguration, new()
        {
            new T().Configure(_container);
        }
    }
}
