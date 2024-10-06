using Bookify.Domain.Abstractions;
using MediatR;

namespace Bookify.Application.Abstractions.Messaging
{
    public interface IQuery<Tresponse> : IRequest<Result<Tresponse>>;
}
