namespace AwsSns.Domain.Entities
{
    public class Publication
    {
        public string TopicArn { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
