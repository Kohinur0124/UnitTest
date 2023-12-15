using MediatR;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestAllThemes.Application.UseCases.User.Commands
{
    public class PostUserCommand : IRequest<bool>
    {
        public string Name { get; set; }

    
        public int Age { get; set; }


        public string Role { get; set; }

    }
}
