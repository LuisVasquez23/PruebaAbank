using AbankApi.Application.Dtos.User;
using MediatR;

namespace AbankApi.Application.Features.User.Commands.Create
{
    public record CreateUserCommand(CreateUserDto user) : IRequest<GetUserDto>;
}
