using MediatR;
using Microsoft.EntityFrameworkCore;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Application.UseCases.User.Queries;
using TestAllThemes.Domain.Entities;

namespace TestAllThemes.Application.UseCases.User.Handlers
{
    public class GetUserCommandHandler :
        IRequestHandler<GetUserCommand, List<UserS>>
    {

        private readonly IApplicationDbContext _context;

        public GetUserCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Domain.Entities.UserS>> Handle(GetUserCommand request, CancellationToken cancellationToken)
        {
            return await _context.Users.ToListAsync();
        }
    }
}
