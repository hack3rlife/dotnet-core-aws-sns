using Amazon;
using Amazon.Runtime;
using Amazon.SimpleNotificationService;
using AwsSns.Domain.Entities;
using AwsSns.Domain.Interfaces;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;
using Amazon.SimpleNotificationService.Model;
using AwsSns.Domain.Entities.Dao;
using AutoMapper;

namespace AwsSns.Infrastructure.Repositories
{
    public class AmazonSnsClient : IAmazonSnsClient
    {
        private readonly IAmazonSimpleNotificationService _snsClient;
        private readonly SNSSettings _snsSettings;
        /// <summary>
        /// 
        /// </summary>
        /// <see cref="https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration/options?view=aspnetcore-6.0"/>
        /// <param name="snsSettings"></param>
        public AmazonSnsClient(IOptions<SNSSettings> snsSettings)
        {
            _snsSettings = snsSettings.Value;

            var region = RegionEndpoint.GetBySystemName(_snsSettings.AWSRegion);

            _snsClient = new AmazonSimpleNotificationServiceClient(
                new BasicAWSCredentials(_snsSettings.AWSAccessKey, _snsSettings.AWSSecretKey), region);
        }

        public async Task<PublishResponseDao> PublishEventAsync(PublishRequestDao publisherRequest)
        {
            try
            {
                var request = new PublishRequest(publisherRequest.TopicArn, publisherRequest.Message,
                    publisherRequest.Subject);

                var response = await _snsClient.PublishAsync(request);

                return new PublishResponseDao
                {
                    MessageId = response.MessageId,
                    SequenceNumber = response.SequenceNumber
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<SubscribeResponseDao> SubscribeAsync(SubscribeRequestDao subscribeRequest)
        {
            try
            {
                var request = new SubscribeRequest
                {
                    TopicArn = subscribeRequest.TopicArn,
                    Endpoint = subscribeRequest.EndPoint,
                    Protocol = subscribeRequest.Protocol
                };

                var response = await _snsClient.SubscribeAsync(request);

                return new SubscribeResponseDao
                {
                    SubscriptionArn = response.SubscriptionArn
                };

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<UnsubscribeResponseDao> UnsubscribeAsync(UnsubscribeRequestDao unsubscribeRequest)
        {

            try
            {
                var request = new UnsubscribeRequest
                {
                    SubscriptionArn = unsubscribeRequest.SubscriptionArn
                };

                var response = await _snsClient.UnsubscribeAsync(request);

                return new UnsubscribeResponseDao();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
