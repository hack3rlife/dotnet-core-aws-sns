using System.Threading.Tasks;
using AwsSns.Domain.Entities;

namespace AwsSns.Domain.Interfaces
{
    public interface IStatusRepository
    {
        /// <summary>
        /// Gets the service status
        /// </summary>
        /// <returns>The Service <see cref="Status"/></returns>
        Task<Status> GetStatusAsync();
    }
}
