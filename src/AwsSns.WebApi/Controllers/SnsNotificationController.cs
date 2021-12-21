using AwsSns.Domain.Entities.Dto;
using AwsSns.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

namespace AwsSns.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SnsNotificationController : ControllerBase
    {
        private readonly ILogger<SnsNotificationController> _logger;
        private readonly IEventPublisherService _eventPublisherService;

        public SnsNotificationController(IEventPublisherService eventPublisher, ILoggerFactory loggerFactory)
        {
            _eventPublisherService = eventPublisher;
            _logger = loggerFactory.CreateLogger<SnsNotificationController>();
        }

        [HttpPost]
        public async Task<ActionResult> HandleNotificationAsync([FromBody] PublishRequestDto publishRequestDto)
        {
            await _eventPublisherService.PublishEventAsync(publishRequestDto);

            return Ok();
        }

        [HttpPost("SubscribeByEmail")]
        public async Task<ActionResult> EmailSubscriptionAsync([FromBody] SubscribeRequestDto subscribeRequestDto)
        {
            await _eventPublisherService.SubscribeAsync(subscribeRequestDto);

            return Ok();
        }

        [HttpPost("Unsubscribe")]
        public async Task<ActionResult> UnsubscribeAsync([FromBody] UnsubscribeRequestDto unsubscribeRequestDto)
        {
            await _eventPublisherService.UnsubscribeAsync(unsubscribeRequestDto);

            return Ok();
        }
    }
}
