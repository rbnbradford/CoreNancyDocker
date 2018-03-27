using Nancy;

namespace NancyApplication.Extensions
{
    public static class ResponseExtensions
    {
        public static Response AsResponse(this string json) => json;
    }
}
