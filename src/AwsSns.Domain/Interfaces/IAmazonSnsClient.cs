using System.Threading.Tasks;
using AwsSns.Domain.Entities.Dao;

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
        /// <param name="publisherRequest">The <see cref="PublishRequestDao"/> values to be sent to Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="PublishResponseDao"/></returns>
        Task<PublishResponseDao> PublishEventAsync(PublishRequestDao publisherRequest);

        /// <summary>
        /// Manages subscribe requests and responses from Amazon Simple Notification Service 
        /// </summary>
        /// <param name="subscribeRequest">The <see cref="SubscribeRequestDao"/> values to subscribe to a topic in Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="SubscribeResponseDao"/></returns>
        Task<SubscribeResponseDao> SubscribeAsync(SubscribeRequestDao subscribeRequest);

        /// <summary>
        /// Manages unsubscribe requests and responses from Amazon Simple Notification Service 
        /// </summary>
        /// <param name="unsubscribeRequest">The <see cref="UnsubscribeRequestDao"/> values to unsubscribe from a topic in Amazon Simple Notification Service.</param>
        /// <returns>A <see cref="UnsubscribeResponseDao"/></returns>
        Task<UnsubscribeResponseDao> UnsubscribeAsync(UnsubscribeRequestDao unsubscribeRequest);
    }
}
