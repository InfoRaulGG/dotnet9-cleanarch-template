using MediatR;
using Domain.Entities;
using Domain.ValueObjects;
using Domain.Repositories;
using Application.Commands;

namespace Application.Handlers 
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateUserCommandHandler(IUserRepository userRepository, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = new User(new Domain.TypedIds.UserId(), new UserName(request.Name), new Email(request.Email));
            await _userRepository.AddAsync(user);
            await _unitOfWork.CommitAsync(cancellationToken);
            return user.Id.Value;
        }
    }
}



