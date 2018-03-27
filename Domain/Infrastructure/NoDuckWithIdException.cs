using System;

namespace Domain.Infrastructure
{
    public class NoDuckWithIdException : Exception
    {
        public NoDuckWithIdException(string id) : base(MakeMessage(id))
        {
        }

        private static string MakeMessage(string id) => $"No duck with id `{id}` found";
    }
}
