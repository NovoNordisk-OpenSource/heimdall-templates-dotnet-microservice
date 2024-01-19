using BeHeroes.CodeOps.Abstractions.Facade;
using MediatR;

namespace Heimdall.Templates.DotNet.Microservice.Application
{
    public sealed class ApplicationFacade : Facade, IApplicationFacade
    {
        public ApplicationFacade(IMediator mediator) : base(mediator)
        {
        }
    }
}