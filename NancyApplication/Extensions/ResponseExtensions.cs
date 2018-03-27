using Nancy;

namespace NancyApplication.Extensions
{
    public static class ResponseExtensions
    {
        public static Response JsonResponse(this string json) => json;
    }
}
