using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, Result>
        where TCommand : ICommand;


    public interface ICommandHandler<TCommand, Tresponse> : IRequestHandler<TCommand, Result<Tresponse>>
        where TCommand : ICommand<Tresponse>;
}
