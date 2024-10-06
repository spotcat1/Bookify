using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    public interface IQueryHandler <TQuery,Tresponse>:IRequestHandler<TQuery,Result<Tresponse>>
        where TQuery : IQuery<Tresponse>;
}
