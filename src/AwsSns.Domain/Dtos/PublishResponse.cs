namespace AwsSns.Domain.Dtos
{
    /// <summary>
    /// Data Access Class to manage responses from Amazon Simple Notification Service 
    /// </summary>
    public class PublishResponse
    {
        public string MessageId { get; set; }
        public string SequenceNumber { get; set; }
    }
}
