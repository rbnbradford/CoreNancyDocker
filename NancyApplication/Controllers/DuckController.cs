using Domain.ApplicationServices;
using Nancy;
using NancyApplication.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            dynamic body = JObject.Parse(Request.Body.StringFromStream());
            var id = _service.CreateDuck((string) body.name, (int) body.age);

            return JsonConvert
                .SerializeObject(new {data = new {id}})
                .AsResponse()
                .WithContentType("application/json")
                .WithStatusCode(201);
        }
    }
}
