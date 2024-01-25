namespace Heimdall.Templates.DotNet.Microservice.Application;

using BeHeroes.CodeOps.Abstractions.Facade;
using MediatR;

public sealed class ApplicationFacade : Facade, IApplicationFacade
{
    public ApplicationFacade(IMediator mediator) : base(mediator)
    {
    }
}