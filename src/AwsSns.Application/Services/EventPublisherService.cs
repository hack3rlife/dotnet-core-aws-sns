using AutoMapper;
using AwsSns.Domain.Entities.Dao;
using AwsSns.Domain.Entities.Dto;
using AwsSns.Domain.Interfaces;
using System.Threading.Tasks;

namespace AwsSns.Application.Services
{
    public class EventPublisherService : IEventPublisherService
    {
        private readonly IMapper _mapper;
        private readonly IAmazonSnsClient _amazonSnsClient;

        public EventPublisherService(IAmazonSnsClient amazonSnsClient, IMapper mapper)
        {
            _amazonSnsClient = amazonSnsClient;
            _mapper = mapper;
        }

        public async Task<PublishResponseDto> PublishEventAsync(PublishRequestDto publishRequestDto)
        {
            var publisher = _mapper.Map<PublishRequestDao>(publishRequestDto);

            var publishResponse = await _amazonSnsClient.PublishEventAsync(publisher);

            return _mapper.Map<PublishResponseDto>(publishResponse);
        }

        public async Task<SubscribeResponseDto> SubscribeAsync(SubscribeRequestDto subscribeRequestDto)
        {
            var subscription = _mapper.Map<SubscribeRequestDao>(subscribeRequestDto);

            var subscriptionResponse = await _amazonSnsClient.SubscribeAsync(subscription);

            return _mapper.Map<SubscribeResponseDto>(subscriptionResponse);
        }

        public async Task<UnsubscribeResponseDto> UnsubscribeAsync(UnsubscribeRequestDto unsubscribeRequestDto)
        {
            var unsubscribeRequest = _mapper.Map<UnsubscribeRequestDao>(unsubscribeRequestDto);

            var unsubscribeResponse = await _amazonSnsClient.UnsubscribeAsync(unsubscribeRequest);

            return _mapper.Map<UnsubscribeResponseDto>(unsubscribeResponse);

        }
    }
}
