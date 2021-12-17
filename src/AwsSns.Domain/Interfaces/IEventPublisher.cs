using AwsSns.Domain.Dtos;
using System.Threading.Tasks;

namespace AwsSns.Domain.Interfaces
{
    /// <summary>
    /// Wrapper for IAmazonSimpleNotificationService
    /// </summary>
    public interface IEventPublisherService
    {
        /// <summary>
        /// Publish an event to Amazon Simple Notification Service
        /// </summary>
        /// <param name="publishRequestDto">The <see cref="PublishRequestDto"/> values to be published to AWS SNS</param>
        /// <returns>A <see cref="PublishResponseDto"/></returns>
        Task<PublishResponseDto> PublishEventAsync(PublishRequestDto publishRequestDto);

        /// <summary>
        /// Manages the subscription to a topic 
        /// </summary>
        /// <param name="subscribeRequestDto">The <see cref="SubscribeRequestDto"/> with the values required to be subscribed to a topic</param>
        /// <returns>A <see cref="SubscribeResponseDto"/></returns>
        Task<SubscribeResponseDto> SubscribeAsync(SubscribeRequestDto subscribeRequestDto);

        /// <summary>
        /// Manages the Unsubscribe action from a topic
        /// </summary>
        /// <param name="unsubscribeRequestDto">The <see cref="UnsubscribeRequestDto"/> with the required values to unsubscribe from a topic</param>
        /// <returns>A <see cref="UnsubscribeResponseDto"/></returns>
        Task<UnsubscribeResponseDto> UnsubscribeAsync(UnsubscribeRequestDto unsubscribeRequestDto);
    }
}
