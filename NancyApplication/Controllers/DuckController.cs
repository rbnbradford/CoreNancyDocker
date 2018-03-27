using Domain.Application;
using Nancy;
using NancyApplication.Extensions;
using Newtonsoft.Json;

namespace NancyApplication.Controllers
{
    public sealed class DuckController : NancyModule
    {
        private readonly DuckService _service;

        public DuckController(DuckService service)
        {
            _service = service;

            Post("/Ducks/", args => CreateDuck());
        }

        private Response CreateDuck()
        {
            var body = JsonConvert.DeserializeAnonymousType(Request.Body.StringFromStream(), new {name = "", age = 0});

            var id = _service.CreateDuck(body.name, body.age);

            return JsonConvert
                .SerializeObject(new {data = new {id}})
                .JsonResponse()
                .WithContentType("application/json")
                .WithStatusCode(201);
        }
    }
}
