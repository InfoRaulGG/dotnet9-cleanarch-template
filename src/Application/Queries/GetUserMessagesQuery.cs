using MediatR;
using Domain.TypedIds;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Queries
{
    public record GetUserMessagesQuery(UserId UserId) : IRequest<IEnumerable<Message>>;
}