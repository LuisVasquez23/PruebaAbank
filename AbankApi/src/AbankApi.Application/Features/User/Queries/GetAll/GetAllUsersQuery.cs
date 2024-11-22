using AbankApi.Application.Dtos.User;
using MediatR;


namespace AbankApi.Application.Features.User.Queries.GetAll
{
    public record GetAllUsersQuery : IRequest<IEnumerable<GetUserDto>>;
}
