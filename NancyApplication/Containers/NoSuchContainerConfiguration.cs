using System;

namespace NancyApplication.Containers
{
    internal class NoSuchContainerConfiguration : Exception
    {
        public NoSuchContainerConfiguration(string containerName) : base(MakeMessage(containerName))
        {
        }

        private static string MakeMessage(string containerName) => $"no container exists named `{containerName}`";
    }
}
