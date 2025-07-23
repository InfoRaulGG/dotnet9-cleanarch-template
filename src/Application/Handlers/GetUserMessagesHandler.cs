using MediatR;
using Domain.Repositories;
using Application.Queries;
using Domain.Entities;

namespace Application.Handlers
{
    public class GetUserMessagesHandler : IRequestHandler<GetUserMessagesQuery, IEnumerable<Message>>
    {
        private readonly IMessageRepository _messageRepository;

        public GetUserMessagesHandler(IMessageRepository messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public async Task<IEnumerable<Message>> Handle(GetUserMessagesQuery request, CancellationToken cancellationToken)
        {
            return await _messageRepository.GetMessagesForUserAsync(request.UserId);
        }
    }
}
