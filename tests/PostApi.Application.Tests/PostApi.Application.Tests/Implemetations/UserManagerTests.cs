using AutoMapper;
using Moq;
using PostAppApi.Application.Implementations;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.User;
using PostAppApi.Domain.Enums;
using PostAppApi.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace PostApi.Application.Tests.Implemetations
{
    public class UserManagerTests
    {
        private UserManager _manager;
        private readonly Mock<IUserRepository> _userRepositoryMock;

        public UserManagerTests()
        {
            _userRepositoryMock = new Mock<IUserRepository>();
            _manager = new UserManager(_userRepositoryMock.Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public async Task Get_AllAsyncValidAsync()
        {
            List<User> users = new List<User>()
            {
                new User
                {
                    Id = 1,
                    Username = "Test",
                    UpdatedAt = DateTime.UtcNow,
                    Roles = Roles.User,
                    CreatedAt = DateTime.UtcNow,
                    Email = "Test",
                    Password = "Test"
                },
                new User
                {
                    Id = 2,
                    Username = "Test2",
                    UpdatedAt = DateTime.UtcNow,
                    Roles = Roles.User,
                    CreatedAt = DateTime.UtcNow,
                    Email = "Test2",
                    Password = "Test2"
                },
                new User
                {
                    Id = 3,
                    Username = "Test3",
                    UpdatedAt = DateTime.UtcNow,
                    Roles = Roles.User,
                    CreatedAt = DateTime.UtcNow,
                    Email = "Test3",
                    Password = "Test3"
                }
            };

            _userRepositoryMock.Setup(ob => ob.GetAllAsync()).ReturnsAsync(users);
            var result = await _manager.GetAllAsync();

            Assert.Equal(3, users.Count);
            Assert.NotNull(result);
            _userRepositoryMock.Verify(ob => ob.GetAllAsync(), Times.Once);
        }

        [Fact]
        public async void Get_UserByIdAsyncInvalidShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.GetByIdAsync(0));
            Assert.Equal("ID do usuario informado não foi encontrado ou é inválido", exception.Message);
        }

        [Fact]
        public void Get_UserByIdAsyncValid()
        {
            User user = new User()
            {
                Id = 1,
                Username = "Test",
                UpdatedAt = DateTime.UtcNow,
                Roles = Roles.User,
                CreatedAt = DateTime.UtcNow,
                Email = "Test",
                Password = "Test"
            };

            _userRepositoryMock.Setup(ob => ob.GetByIdAsync(It.IsAny<int>())).ReturnsAsync(user);
            var result = _manager.GetByIdAsync(1);

            Assert.Equal(1, result.Id);

        }

        [Fact]
        public async void Get_UserByEmailAsyncEmptyShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.GetByEmailAsync(""));
            Assert.Equal("Email não informado", exception.Message);
        }

        [Fact]
        public async void Get_UserByUsernameInvalidShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.GetByUsername(""));
            Assert.Equal("Nome de usuario não foi informado", exception.Message);
        }

        [Fact]
        public void Get_UserByLoginInvalidShouldReturnEqualNull()
        {
            var result = _manager.GetByLogin(new UserLoginRequestBody("teste@email.com", "123123")).Result;
            Assert.Null(result);
        }

        [Fact]
        public async void Post_InsertAsyncEmptyUsernameShoulReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.InsertAsync(new UserPostRequestBody()));
            Assert.Equal("Nome de Usuario não foi informado", exception.Message);
        }

        [Fact]
        public void Post_InsertAsyncValidObject()
        {
            var result = _manager.InsertAsync(new UserPostRequestBody
            {
                Username = "valid",
                Email = "valid@email.com",
                Password = "123123",
                Roles = Roles.User
            });
            Assert.NotNull(result);
        }

        [Fact]
        public async void Post_InsertAsyncInvalidObject()
        {
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _manager.InsertAsync(new UserPostRequestBody
            {
                Username = "invalid",
                Password = "123123",
                Roles = Roles.User
            }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        [Fact]
        public async void Put_UpdateAsyncInvalidObjectShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _manager.UpdateAsync(new UserPutRequestBody
            {
                Username = "invalid",
                Password = "123123"
            }));
            Assert.Equal("The Email field is required.", exception.Message);
        }

        [Fact]
        public void Put_UpdateAsyncValidOject()
        {
            var result = _manager.UpdateAsync(new UserPutRequestBody
            {
                Id = 1,
                Username = "valid",
                Email = "valid@email.com",
                Password = "123123"
            });

            Assert.NotNull(result);
        }

        [Fact]
        public async void Put_UpdateAsyncInvalidIdShouldReturnException()
        {
            UserPutRequestBody user = new UserPutRequestBody()
            {
                Id = 0,
                Username = "invalid",
                Email = "invalid@email.com",
                Password = "123123"
            };
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.UpdateAsync(user));
            Assert.Equal("ID do usuario informado não foi encontrado", exception.Message);
        }

        [Fact]
        public async void Delete_DeleteAsyncInvalidIdShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manager.DeleteAsync(0));
            Assert.Equal("ID do usuario informado não foi encontrado ou é inválido", exception.Message);
        }
    }
}
