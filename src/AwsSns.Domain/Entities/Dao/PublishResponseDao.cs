namespace AwsSns.Domain.Entities.Dao
{
    /// <summary>
    /// Data Access Class to manage responses from Amazon Simple Notification Service 
    /// </summary>
    public class PublishResponseDao
    {
        public string MessageId { get; set; }
        public string SequenceNumber { get; set; }
    }
}
