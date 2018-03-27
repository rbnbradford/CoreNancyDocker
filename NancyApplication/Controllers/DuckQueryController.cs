using Domain.Representation;
using Nancy;
using NancyApplication.Extensions;
using Newtonsoft.Json;

namespace NancyApplication.Controllers
{
    public sealed class DuckQueryController : NancyModule
    {
        private readonly IDuckReadRepository _readRepository;

        public DuckQueryController(IDuckReadRepository readRepository)
        {
            _readRepository = readRepository;

            Get("/Duck/{id}", args => GetDuck(args));

            Get("/Ducks/", _ => GetDucks());
        }

        private Response GetDuck(dynamic args)
        {
            return JsonConvert
                .SerializeObject(_readRepository.Get((string) args.id))
                .AsResponse()
                .WithContentType("application/json")
                .WithStatusCode(200);
        }

        private Response GetDucks()
        {
            return JsonConvert
                .SerializeObject(_readRepository.Get())
                .AsResponse()
                .WithContentType("application/json")
                .WithStatusCode(200);
        }
    }
}
