using Nancy.TinyIoc;

namespace NancyApplication.Containers
{
    internal interface IContainerConfiguration
    {
        void Configure(TinyIoCContainer container);
    }
}
