using System.IO;
using Nancy.Extensions;
using Nancy.IO;

namespace NancyApplication.Extensions
{
    public static class RequestBodyExtensions
    {
        public static string StringFromStream(this Stream stream)
        {
            return RequestStream.FromStream(stream).AsString();
        }
    }
}
