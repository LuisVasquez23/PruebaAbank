using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AutoMapper;
using MediatR;

namespace AbankApi.Application.Features.User.Queries.GetAll
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<GetUserDto>>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<GetUserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _repository.GetAllAsync();

            return _mapper.Map<List<GetUserDto>>(users);
        }
    }
}
