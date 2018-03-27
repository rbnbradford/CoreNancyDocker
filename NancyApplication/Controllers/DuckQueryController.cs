using Domain.Representation;
using Nancy;
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

            Get("/Ducks/", args => GetDucks());
        }

        private Response GetDuck(dynamic args)
        {
            return ((Response) JsonConvert.SerializeObject(_readRepository.Get((string) args.id)))
                .WithContentType("application/json");
        }

        private Response GetDucks()
        {
            return ((Response) JsonConvert.SerializeObject(_readRepository.Get()))
                .WithContentType("application/json");
        }
    }
}
