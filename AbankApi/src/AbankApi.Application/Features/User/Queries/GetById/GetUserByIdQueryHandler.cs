using AbankApi.Application.Dtos.User;
using AbankApi.Application.Repositories;
using AutoMapper;
using MediatR;

namespace AbankApi.Application.Features.User.Queries.GetById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserDto>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IUserRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GetUserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var user = await _repository.FindByIdAsync(request.id);

            return _mapper.Map<GetUserDto>(user);
        }
    }
}
