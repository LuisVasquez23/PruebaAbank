using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AutoMapper;
using MediatR;


namespace AbankApi.Application.Features.User.Commands.Update
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, GetUserDto?>
    {

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<GetUserDto?> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            // Buscar el usuario por ID
            var userEntity = await _userRepository.FindByIdAsync(request.id);

            if (userEntity == null) return null;

            // Actualizar solo los campos que no son nulos
            if (!string.IsNullOrEmpty(request.user.FirstName))
                userEntity.FirstName = request.user.FirstName;

            if (!string.IsNullOrEmpty(request.user.LastName))
                userEntity.LastName = request.user.LastName;

            if (request.user.DateOfBirth != default)
                userEntity.DateOfBirth = request.user.DateOfBirth;

            if (!string.IsNullOrEmpty(request.user.Phone))
                userEntity.Phone = request.user.Phone;

            if (!string.IsNullOrEmpty(request.user.Email))
                userEntity.Email = request.user.Email;

            if (!string.IsNullOrEmpty(request.user.Address))
                userEntity.Address = request.user.Address;

            if (!string.IsNullOrEmpty(request.user.Password))
                userEntity.Password = request.user.Password;

            var updatedUser = await _userRepository.UpdateAsync(userEntity);

            return _mapper.Map<GetUserDto>(updatedUser);
        }
    }
}
