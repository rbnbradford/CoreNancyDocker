using System.Collections.Generic;
using Domain.Domain;
using Domain.Infrastructure.DuckRepositories;
using Domain.Records;
using Domain.Representation;
using Nancy.TinyIoc;

namespace NancyApplication.Containers
{
    internal class Develop : IContainerConfiguration
    {
        public void Configure(TinyIoCContainer container)
        {
            var duckDictionary = new Dictionary<string, DuckRecord>();
            container.Register<IDuckRepository>((c, o) => new MemoryDuckRepository(duckDictionary));
            container.Register<IDuckReadRepository>((c, o) => new MemoryDuckReadRepository(duckDictionary));
        }
    }
}
