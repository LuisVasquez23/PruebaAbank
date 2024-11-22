using AbankApi.Application.Dtos.User;
using AbankApi.Application.Features.User.Commands.Create;
using AbankApi.Application.Features.User.Commands.Delete;
using AbankApi.Application.Features.User.Commands.Update;
using AbankApi.Application.Features.User.Queries.GetAll;
using AbankApi.Application.Features.User.Queries.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AbankApi.Api.Controllers
{
    [ApiController]
    [Route("api/v1/Users")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region [GET] /api/v1/users
        [HttpGet()]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll()
        {
            var users = await _mediator.Send(new GetAllUsersQuery());
            return Ok(users);
        }
        #endregion

        #region [GET] /api/v1/users/{id_user}
        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _mediator.Send(new GetUserByIdQuery(id));

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(user);
        }
        #endregion

        #region [POST] /api/v1/users
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create([FromBody] CreateUserDto newUser)
        {

            var user = await _mediator.Send(new CreateUserCommand(newUser));

            return Ok(user);

        }
        #endregion

        #region [DELETE] /api/v1/users/{id_user}
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _mediator.Send(new DeleteUserCommand(id));

            if (user == null)
            {
                return NotFound($"User with ID {id} not found.");
            }


            return Ok(user);
        }
        #endregion

        #region [UPDATE] /api/v1/users/{user_id}
        [HttpPut("{userId}")]
        [Authorize]
        public async Task<IActionResult> Update(int userId, [FromBody] UpdateUserDto user)
        {

            var userUpdated = await _mediator.Send(new UpdateUserCommand(user, userId));

            if (userUpdated == null)
            {
                return NotFound($"User with ID {userId} not found.");
            }


            return Ok(userUpdated);
        }
        #endregion

    }
}
