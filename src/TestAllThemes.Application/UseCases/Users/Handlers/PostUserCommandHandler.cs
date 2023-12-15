using MediatR;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Commands;
using TestAllThemes.Application.UseCases.Users.Repos;

namespace TestAllThemes.Application.UseCases.User.Handlers
{
    public class PostUserCommandHandler :
        IRequestHandler<PostUserCommand, bool>
    {
        private readonly IUserRepository _context;

        public PostUserCommandHandler(IUserRepository context)
        { 
            _context = context;
        }

        public async Task<bool> Handle(PostUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = new Domain.Entities.UserS
                {
                    Name = request.Name,
                    Age = request.Age,
                    Role = request.Role,
                };
                
                return (bool) await  _context.InsertAsync(res,cancellationToken);
                
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
