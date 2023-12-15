using MediatR;

namespace TestAllThemes.Application.UseCases.User.Commands
{
    public class PutUserCommand : IRequest<bool>
    {

        public int Id { get; set; }

        public string Name { get; set; }


        public int Age { get; set; }


        public string Role { get; set; }
    }
}
