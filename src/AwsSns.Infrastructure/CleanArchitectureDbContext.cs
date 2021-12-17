using Microsoft.EntityFrameworkCore;
using AwsSns.Domain.Entities;

namespace AwsSns.Infrastructure
{
    public class CleanArchitectureDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public CleanArchitectureDbContext(DbContextOptions<CleanArchitectureDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Status> Status { get; set; }

    }
}
