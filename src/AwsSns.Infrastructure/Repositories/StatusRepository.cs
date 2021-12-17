using Microsoft.EntityFrameworkCore;
using AwsSns.Domain.Entities;
using AwsSns.Domain.Interfaces;
using System.Threading.Tasks;

namespace AwsSns.Infrastructure.Repositories
{
    public class StatusRepository : IStatusRepository
    {
        private readonly CleanArchitectureDbContext _cleanArchitectureDbContext;

        public StatusRepository(CleanArchitectureDbContext cleanArchitectureDbContext)
        {
            _cleanArchitectureDbContext = cleanArchitectureDbContext;
        }

        public async Task<Status> GetStatusAsync()
        {
            return await _cleanArchitectureDbContext.Status.FirstOrDefaultAsync();
        }
    }
}