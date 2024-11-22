using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AbankApi.Domain.Entities;
using AutoMapper;
using MediatR;


namespace AbankApi.Application.Features.User.Commands.Create
{
    public class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, GetUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<GetUserDto> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var userEntity = _mapper.Map<UserEntity>(request.user);

            var newUser = await _userRepository.CreateAsync(userEntity);

            return _mapper.Map<GetUserDto>(newUser);
        }
    }
}
