using AwsSns.Domain.Dtos;
using System.Threading.Tasks;

namespace AwsSns.Domain.Interfaces
{
    /// <summary>
    /// Infrastructure Class to manage requests and responses from Amazon Simple Notification Service.
    /// </summary>
    public interface IAmazonSnsClient
    {
        /// <summary>
        /// Manages publish requests and responses from Amazon Simple Notification Service 
        /// </summary>
        /// <param name="publisherRequest">The <see cref="PublishRequest"/> values to be sent to Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="PublishResponse"/></returns>
        Task<PublishResponse> PublishEventAsync(PublishRequest publisherRequest);

        /// <summary>
        /// Manages subscribe requests and responses from Amazon Simple Notification Service 
        /// </summary>
        /// <param name="subscribeRequest">The <see cref="SubscribeRequest"/> values to subscribe to a topic in Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="SubscribeResponse"/></returns>
        Task<SubscribeResponse> SubscribeAsync(SubscribeRequest subscribeRequest);

        /// <summary>
        /// Manages unsubscribe requests and responses from Amazon Simple Notification Service 
        /// </summary>
        /// <param name="unsubscribeRequest">The <see cref="UnsubscribeRequest"/> values to unsubscribe from a topic in Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="UnsubscribeResponse"/></returns>
        Task<UnsubscribeResponse> UnsubscribeAsync(UnsubscribeRequest unsubscribeRequest);
    }
}
