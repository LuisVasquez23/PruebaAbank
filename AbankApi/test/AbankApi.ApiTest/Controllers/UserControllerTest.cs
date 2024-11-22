using AbankApi.Api.Controllers;
using AbankApi.Application.Dtos.User;
using AbankApi.Application.Features.User.Commands.Create;
using AbankApi.Application.Features.User.Commands.Delete;
using AbankApi.Application.Features.User.Commands.Update;
using AbankApi.Application.Features.User.Queries.GetAll;
using AbankApi.Application.Features.User.Queries.GetById;
using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace AbankApi.ApiTest.Controllers
{
    [TestClass]
    public class UserControllerTest
    {
        private Mock<IMediator>? _mockMediator;
        private UserController? _controller;

        [TestInitialize]
        public void Setup()
        {
            _mockMediator = new Mock<IMediator>();
            _controller = new UserController(_mockMediator.Object);
        }

        #region GET ALL - TEST 
        [TestMethod]
        public async Task GetAll_ShouldReturnOkResultWithUsers()
        {
            // Arrange
            var users = new List<GetUserDto>
            {
                new GetUserDto { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@test.com" , Address = "Santa Ana" },
                new GetUserDto { Id = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@test.com", Address = "Santa Ana" }
            };

            _mockMediator!
                .Setup(m => m.Send(It.IsAny<GetAllUsersQuery>(), default))
                .ReturnsAsync(users);

            // Act
            var result = await _controller!.GetAll();

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            var returnedUsers = okResult.Value as IEnumerable<GetUserDto>;
            returnedUsers.Should().BeEquivalentTo(users);
        }
        #endregion

        #region CREATE - TEST 
        [TestMethod]
        public async Task Create_ShouldReturnOkResult_WhenUserIsCreated()
        {
            // Arrange
            var newUser = new CreateUserDto
            {
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Email = "john.doe@test.com",
                Phone = "123456789",
                Address = "123 Main St",
                Password = "securepassword"
            };

            GetUserDto expectedResponse = new GetUserDto { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@test.com", Address = "Santa Ana" };

            _mockMediator!
                .Setup(m => m.Send(It.IsAny<CreateUserCommand>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller!.Create(newUser);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion

        #region FIND BY ID - TEST 
        [TestMethod]
        public async Task GetById_ShouldReturnOkResult_WhenUserExists()
        {
            // Arrange
            var userId = 1;
            var user = new GetUserDto
            {
                Id = userId,
                FirstName = "John",
                LastName = "Doe",
                DateOfBirth = new DateTime(1990, 1, 1),
                Email = "john.doe@test.com",
                Phone = "123456789",
                Address = "123 Main St"
            };

            _mockMediator!
                .Setup(m => m.Send(It.Is<GetUserByIdQuery>(q => q.id == userId), default))
                .ReturnsAsync(user);

            // Act
            var result = await _controller!.GetById(userId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().Be(user);
        }
        #endregion

        #region UPDATE - TEST 
        [TestMethod]
        public async Task Update_ShouldReturnOkResult_WhenUserIsUpdated()
        {
            // Arrange
            var userId = 1;
            var updatedUser = new UpdateUserDto
            {
                FirstName = "John Updated",
                LastName = "Doe Updated",
                Email = "john.updated@test.com"
            };

            GetUserDto expectedResponse = new GetUserDto { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@test.com", Address = "Santa Ana" };

            _mockMediator!
                .Setup(m => m.Send(It.IsAny<UpdateUserCommand>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller!.Update(userId, updatedUser);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(expectedResponse);
        }
        #endregion

        #region DELETE - TEST
        [TestMethod]
        public async Task Delete_ShouldReturnOkResult_WhenUserIsDeleted()
        {
            // Arrange
            var userId = 1;
            GetUserDto expectedResponse = new GetUserDto { Id = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@test.com", Address = "Santa Ana" };

            _mockMediator!
                .Setup(m => m.Send(It.IsAny<DeleteUserCommand>(), default))
                .ReturnsAsync(expectedResponse);

            // Act
            var result = await _controller!.Delete(userId);

            // Assert
            var okResult = result as OkObjectResult;
            okResult.Should().NotBeNull();
            okResult!.StatusCode.Should().Be(200);
            okResult.Value.Should().BeEquivalentTo(expectedResponse);
        }

        #endregion

    }
}
