using AutoMapper;
using Moq;
using PostAppApi.Application.Implementations;
using PostAppApi.Application.Interfaces.Repositories;
using PostAppApi.Comunicacao.ModelViews.Post;
using System.ComponentModel.DataAnnotations;

namespace PostApi.Application.Tests.Implemetations
{
    public class PostManagerTests
    {
        private PostManager _manger;
        private readonly Mock<IPostRepository> _postRepositoryMock;

        public PostManagerTests()
        {
            _postRepositoryMock = new Mock<IPostRepository>();
            _manger = new PostManager(_postRepositoryMock.Object, new Mock<IMapper>().Object);
        }

        [Fact]
        public async void Get_PostByIdAsyncInvalidShouldReturnException()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manger.GetByIdAsync(0));
            Assert.Equal("ID da postagem informado não foi encontrado ou é inválido", exception.Message);
        }

        [Fact]
        public void Post_InsertAsyncValidObject()
        {
            var result = _manger.InsertAsync(new PostPostRequestBody
            {
                Body = "valid body",
                Title = "Title",
                UserId = 1,
            });
            Assert.NotNull(result);
        }

        [Fact]
        public async void Post_InsertAsyncInvalidId()
        {
            var exception = await Assert.ThrowsAsync<Exception>(() => _manger.InsertAsync(new PostPostRequestBody
            {
                Title = "invalid",
                Body = "invalid_body",
                
            }));
            Assert.Equal("Postagem não foi atribuida a nenhum usuário", exception.Message);
        }

        [Fact]
        public async void Post_InsertAsyncInvalidObject()
        {
            var exception = await Assert.ThrowsAsync<ValidationException>(() => _manger.InsertAsync(new PostPostRequestBody
            {
                Title = "invalid",
                UserId = 1
            }));
            Assert.Equal("The Body field is required.", exception.Message);
        }
    }
}
