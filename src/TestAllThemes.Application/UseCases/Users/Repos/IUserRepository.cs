using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestAllThemes.Application.UseCases.User.Commands;
using TestAllThemes.Domain.Entities;

namespace TestAllThemes.Application.UseCases.Users.Repos
{
    public interface IUserRepository
    {
        public ValueTask<bool> InsertAsync(UserS product, CancellationToken cancellationToken);
        public ValueTask<bool> RemoveAsync(int id);
        public ValueTask<List<UserS>> SelectAllAsync();
    }
}
