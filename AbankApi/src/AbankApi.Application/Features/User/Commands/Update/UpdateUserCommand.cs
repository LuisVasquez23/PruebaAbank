using AbankApi.Application.Dtos.User;
using MediatR;

namespace AbankApi.Application.Features.User.Commands.Update
{
    public record UpdateUserCommand(UpdateUserDto user, int id) : IRequest<GetUserDto>;
}
