using System;
using System.Threading.Tasks;
using AutoMapper;
using AwsSns.Application.Mappers;
using AwsSns.Application.Services;
using AwsSns.Domain.Entities.Dao;
using AwsSns.Domain.Entities.Dto;
using AwsSns.Domain.Interfaces;
using FluentAssertions;
using LoremNET;
using Moq;
using Xunit;

namespace Application.UnitTest.Services
{
    public class EventPublisherTests
    {
        private readonly Mock<IAmazonSnsClient> _mockAmazonSnsClient;
        private readonly EventPublisherService _sut;

        public EventPublisherTests()
        {
            _mockAmazonSnsClient = new Mock<IAmazonSnsClient>();

            var configurationProvider = new MapperConfiguration(cfg => { cfg.AddProfile<ProfileMapper>(); });
            var mapper = configurationProvider.CreateMapper();
            
            _sut = new EventPublisherService(_mockAmazonSnsClient.Object, mapper);
        }

        [Fact]
        public async Task EventPublisher_Pusblish_Success()
        {
            // Arrange
            var publishResponse = new PublishResponseDao
            {
                MessageId = "MessageId",
                SequenceNumber = "SequenceNumber"
            };

            _mockAmazonSnsClient
                .Setup(x => x.PublishEventAsync(It.IsAny<PublishRequestDao>()))
                .ReturnsAsync(publishResponse)
                .Verifiable();

            var publishRequestDto = new PublishRequestDto
            {
                Message = Lorem.Sentence(10),
                Subject = Lorem.Sentence(5),
                TopicArn = Guid.NewGuid().ToString("D")
            };

            // Act
            var publishResponseDto = await _sut.PublishEventAsync(publishRequestDto);

            // Assert
            publishResponseDto.Should().NotBeNull();
            _mockAmazonSnsClient.Verify(x=>x.PublishEventAsync(It.IsAny<PublishRequestDao>()), Times.Once);
        }

        [Fact]
        public async Task EventPublisher_Subscribe_Success()
        {
            // Arrange
            var subscribeResponse = new SubscribeResponseDao
            {
                SubscriptionArn = "SubscriptionArn"
            };

            _mockAmazonSnsClient
                .Setup(x => x.SubscribeAsync(It.IsAny<SubscribeRequestDao>()))
                .ReturnsAsync(subscribeResponse)
                .Verifiable();

            var subscribeRequestDto = new SubscribeRequestDto()
            {
                Endpoint = "TheEndpoint",
                Protocol = "TheProtocol",
                TopicArn = "TheTopicArn"
            };

            // Act
            var subscribeResponseDto = await _sut.SubscribeAsync(subscribeRequestDto);

            // Assert
            subscribeResponseDto.Should().NotBeNull();
            _mockAmazonSnsClient.Verify(x=>x.SubscribeAsync(It.IsAny<SubscribeRequestDao>()), Times.Once);
        }

        [Fact]
        public async Task EventPublisher_Unsubscribe_Success()
        {
            // Arrange
            var unsubscribeResponse = new UnsubscribeResponseDao();

            _mockAmazonSnsClient
                .Setup(x => x.UnsubscribeAsync(It.IsAny<UnsubscribeRequestDao>()))
                .ReturnsAsync(unsubscribeResponse)
                .Verifiable();

            var unsubscribeRequestDto = new UnsubscribeRequestDto
            {
                SubscriptionArn = "SubscriptionArn"
            };

            // Act
            var unsubscribeResponseDto =  await _sut.UnsubscribeAsync(unsubscribeRequestDto);

            // Assert
            unsubscribeResponseDto.Should().NotBeNull();

            _mockAmazonSnsClient.Verify(x => x.UnsubscribeAsync(It.IsAny<UnsubscribeRequestDao>()));
        }

    }
}
