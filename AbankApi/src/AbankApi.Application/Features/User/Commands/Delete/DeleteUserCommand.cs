using AbankApi.Application.Dtos.User;
using MediatR;

namespace AbankApi.Application.Features.User.Commands.Delete
{
    public record DeleteUserCommand(int id) : IRequest<GetUserDto>;
}
