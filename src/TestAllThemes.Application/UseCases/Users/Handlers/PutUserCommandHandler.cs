using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Commands;

namespace TestAllThemes.Application.UseCases.User.Handlers
{
    public class PutUserCommandHandler :
        IRequestHandler<PutUserCommand, bool>
    {
        private readonly IApplicationDbContext _context;

        public PutUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Handle(PutUserCommand request, CancellationToken cancellationToken)
        {
            try
            {

                var res = await _context.Users.
                    FirstOrDefaultAsync(x => x.Id == request.Id);

                res.Name = request.Name;
                res.Age = request.Age;
                res.Role = request.Role;

                _context.Users.Update(res);

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
