using System;

namespace Heimdall.Templates.DotNet.Microservice.Application
{
    public sealed class ApplicationFacadeException : Exception
    {
        public ApplicationFacadeException()
        { }

        public ApplicationFacadeException(string message)
            : base(message)
        { }

        public ApplicationFacadeException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}