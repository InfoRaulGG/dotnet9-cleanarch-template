using MediatR;

namespace Application.Commands
{
    public record CreateUserCommand(string Name, string Email) : IRequest<Guid>;
}