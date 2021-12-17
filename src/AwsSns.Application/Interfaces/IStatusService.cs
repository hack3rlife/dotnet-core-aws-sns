using AwsSns.Domain.Dtos;
using System.Threading.Tasks;

namespace AwsSns.Application.Interfaces
{
    public interface IStatusService
    {
        /// <summary>
        /// Get the status of the service
        /// </summary>
        /// <returns>The <see cref="StatusResponse"/></returns>
        Task<StatusResponse> GetStatusAsync();
    }
}
