using AbankApi.Application.Dtos.User;
using MediatR;

namespace AbankApi.Application.Features.User.Queries.GetById
{
    public record GetUserByIdQuery(int id) : IRequest<GetUserDto>;
}
