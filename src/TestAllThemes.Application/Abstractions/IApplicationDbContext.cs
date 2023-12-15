using Microsoft.EntityFrameworkCore;
using TestAllThemes;
using TestAllThemes.Domain.Entities;

namespace TestAllThemes.Application.Abstractions
{
    public interface IApplicationDbContext
    {
        public DbSet<UserS> Users { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
