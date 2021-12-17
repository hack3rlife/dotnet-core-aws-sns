namespace AwsSns.Domain.Entities
{
    public class Subscription
    {
        public string TopicArn { get; set; }
        public string EndPoint { get; set; }
        public string Protocol { get; set; }
    }
}
