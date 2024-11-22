using AbankApi.Application.Dtos.Auth;
using AbankApi.Application.Dtos.User;
using MediatR;


namespace AbankApi.Application.Features.User.Queries.GetByEmailAndPassword
{
    public record GetUserByEmailAndPasswordQuery(LoginDto login) : IRequest<GetUserDto>;
}
