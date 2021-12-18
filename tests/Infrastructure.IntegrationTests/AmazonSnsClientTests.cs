using AwsSns.Domain.Entities;
using AwsSns.Infrastructure.Repositories;
using FluentAssertions;
using LoremNET;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using AwsSns.Domain.Entities.Dao;
using Xunit;

namespace Infrastructure.IntegrationTests
{
    public class AmazonSnsClientTests
    {
        public readonly IConfiguration Configuration;
        private readonly AmazonSnsClient _amazonSnsClient;

        public AmazonSnsClientTests()
        {
            Configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsettings.Development.json")
                .Build();

            var snsSettings = Configuration.GetSection("EventPublishing").Get<SNSSettings>();

            _amazonSnsClient = new AmazonSnsClient(Options.Create(snsSettings));
        }

        [Fact]
        public async Task AmazonSnsClient_Publish_Success()
        {
            // Arrange
            var publisherRequest = new PublishRequestDao
            {
                Subject = Lorem.Words(10),
                Message = Lorem.Paragraph(10, 5),
                TopicArn = ""
            };

            // Act
            var publishResponse = await _amazonSnsClient.PublishEventAsync(publisherRequest);

            // Assert
            publishResponse.Should().NotBeNull();
            publishResponse.MessageId.Should().NotBeNull();
        }

        [Fact]
        public async Task AmazonSnsClient_Subscribe_Success()
        {
            // Arrange
            var subscribeRequest = new SubscribeRequestDao
            {
                //TODO: Get this values from appsettings.json
                TopicArn = "",
                EndPoint = "",
                Protocol = "email"
            };

            // Act
            var subscribeResponse = await _amazonSnsClient.SubscribeAsync(subscribeRequest);

            // Assert
            subscribeResponse.Should().NotBeNull();
            subscribeResponse.SubscriptionArn.Should().NotBeNull();
        }

        [Fact]
        public async Task AmazonSnsClient_Unsubscribe_Success()
        {
            // Arrange
            var unsubscribeRequest = new UnsubscribeRequestDao
            {
                // TODO: Get these value dynamically
                SubscriptionArn = ""
            };

            var unsubscribeResponse = await _amazonSnsClient.UnsubscribeAsync(unsubscribeRequest);

            // Assert
            unsubscribeResponse.Should().NotBeNull();
        }
    }
}
