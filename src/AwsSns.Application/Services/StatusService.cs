using System.Threading.Tasks;
using AutoMapper;
using AwsSns.Application.Interfaces;
using AwsSns.Domain.Entities.Dto;
using AwsSns.Domain.Interfaces;

namespace AwsSns.Application.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _statusRepository;
        private readonly IMapper _mapper;

        public StatusService(IStatusRepository statusRepository, IMapper mapper)
        {
            _statusRepository = statusRepository;
            _mapper = mapper;
        }

        public async Task<StatusResponse> GetStatusAsync()
        {
           var status = await _statusRepository.GetStatusAsync();

           return _mapper.Map<StatusResponse>(status);
        }
    }
}
