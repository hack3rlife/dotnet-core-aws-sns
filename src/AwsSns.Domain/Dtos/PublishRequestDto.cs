namespace AwsSns.Domain.Dtos
{
    public class PublishRequestDto
    {
        public string TopicArn { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
