using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Commands;
using TestAllThemes.Application.UseCases.Users.Repos;

namespace TestAllThemes.Application.UseCases.User.Handlers
{
    public class DeleteUserCommandHandler :
        IRequestHandler<DeleteUserCommand, bool>
    {

        private readonly IApplicationDbContext _context;

        public DeleteUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public DeleteUserCommandHandler(IUserRepository @object)
        {
            Object = @object;
        }

        public IUserRepository Object { get; }

        public async Task<bool> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var res = await _context.Users.FirstOrDefaultAsync(x => x.Id == request.Id);

                if (res == null)
                {
                    return false;
                }

                _context.Users.Remove(res);
                await _context.SaveChangesAsync(cancellationToken);
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
