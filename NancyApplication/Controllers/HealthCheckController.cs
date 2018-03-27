using Nancy;

namespace NancyApplication.Controllers
{
    public sealed class HealthCheckController : NancyModule
    {
        public HealthCheckController()
        {
            Get("/", args => "Hello from Nancy running on CoreCLR");
        }
    }
}
