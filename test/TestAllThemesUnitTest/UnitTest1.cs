using MediatR;
using Moq;
using TestAllThemes.Application;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Commands;
using TestAllThemes.Application.UseCases.User.Handlers;
using TestAllThemes.Application.UseCases.Users.Repos;
using TestAllThemes.Domain.Entities;
using TestAllThemess.API.Controllers;

namespace TestAllThemesUnitTest
{
    public class UnitTest1
    {
        private readonly IMediator mediator;
        private readonly Mock<IUserRepository> _userRepositoryMock;
       
        public UnitTest1()
        {

            _userRepositoryMock = new Mock<IUserRepository>();
        }

        [Fact]
        public async Task ShouldAddUser()
        {
            var postUser = new PostUserCommand()
            {
                Name = "Test",
                Age = 15,
                Role = "Admin",
            };

            var user = new UserS
            {
                Name = "Test",
                Age = 15,
                Role = "Admin",
            };

            var cancellationToken = new CancellationToken();


            var extest = false;


             _userRepositoryMock.Setup( x => x.InsertAsync(user,cancellationToken)).ReturnsAsync(true);
            PostUserCommandHandler handler = new PostUserCommandHandler(_userRepositoryMock.Object);

            var result = await handler.Handle(postUser,cancellationToken);

            Assert.Equal(result, extest);
            

        }
    }
}