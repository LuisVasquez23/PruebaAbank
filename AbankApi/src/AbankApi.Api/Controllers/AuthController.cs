using AbankApi.Application.Dtos.Auth;
using AbankApi.Application.Features.User.Queries.GetByEmailAndPassword;
using AbankApi.Application.Services;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AbankApi.Api.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly JwtService _jwtService;

        public AuthController(IMediator mediator, JwtService jwtService)
        {
            _mediator = mediator;
            _jwtService = jwtService;
        }


        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginRequest)
        {
            var user = await _mediator.Send(new GetUserByEmailAndPasswordQuery(loginRequest));

            if (user == null)
            {
                return Unauthorized("Invalid credentials.");
            }

            var token = _jwtService.GenerateToken(user.Id, user.Email);

            return Ok(new { user = user, access_token = token, token_type = "bearer" });
        }
    }
}
