namespace AwsSns.Domain.Dtos
{
    /// <summary>
    /// Data Access Class to manage requests from Amazon Simple Notification Service 
    /// </summary>
    public class PublishRequest
    {
        public string TopicArn { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
