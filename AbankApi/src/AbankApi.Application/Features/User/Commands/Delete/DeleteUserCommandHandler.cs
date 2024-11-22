using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AutoMapper;
using MediatR;

namespace AbankApi.Application.Features.User.Commands.Delete
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand, GetUserDto?>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public DeleteUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = repository;
        }

        public async Task<GetUserDto?> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByIdAsync(request.id);

            if (user == null) return null;

            user = await _userRepository.DeleteAsync(request.id);

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
