using MediatR;

namespace Application.Notifications
{
    public record UserCreatedNotification(Guid UserId) : INotification;
}