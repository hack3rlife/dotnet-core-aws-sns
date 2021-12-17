namespace AwsSns.Domain.Dtos
{
    public class SubscribeRequestDto
    {
        public string TopicArn { get; set; }
        public string Endpoint { get; set; }
        public string Protocol { get; set; }
    }
}
