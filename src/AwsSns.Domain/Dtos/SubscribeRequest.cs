namespace AwsSns.Domain.Dtos
{
    public class SubscribeRequest
    {
        public string TopicArn { get; set; }
        public string EndPoint { get; set; }
        public string Protocol { get; set; }
    }
}
