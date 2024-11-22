using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AutoMapper;
using MediatR;

namespace AbankApi.Application.Features.User.Queries.GetByEmailAndPassword
{
    public class GetUserByEmailAndPasswordQueryHandler : IRequestHandler<GetUserByEmailAndPasswordQuery, GetUserDto>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public GetUserByEmailAndPasswordQueryHandler(IUserRepository userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }


        public async Task<GetUserDto> Handle(GetUserByEmailAndPasswordQuery request, CancellationToken cancellationToken)
        {
            var user = await _userRepository.FindByEmailAndPasswordAsync(request.login.email, request.login.password);

            if (user == null)
            {
                throw new Exception("Usuario no encontrado");
            }

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
