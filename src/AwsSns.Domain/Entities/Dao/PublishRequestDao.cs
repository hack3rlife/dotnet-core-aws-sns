namespace AwsSns.Domain.Entities.Dao
{
    /// <summary>
    /// Data Access Class to manage requests from Amazon Simple Notification Service 
    /// </summary>
    public class PublishRequestDao
    {
        public string TopicArn { get; set; }
        public string Message { get; set; }
        public string Subject { get; set; }
    }
}
