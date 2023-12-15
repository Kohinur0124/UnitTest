using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAllThemes.Application.Abstractions;
using TestAllThemes.Domain.Entities;

namespace TestAllThemes.Application.UseCases.Users.Repos
{
    public class UserRepository : IUserRepository
    {
        private readonly IApplicationDbContext _context;

        public UserRepository(IApplicationDbContext context)

        {

            _context = context;
        }
        
        public async ValueTask<bool> InsertAsync(UserS product,CancellationToken cancellationToken)
        {
            try
            { 

                await _context.Users.AddAsync(product);

                await _context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public ValueTask<bool> RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public ValueTask<List<UserS>> SelectAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
