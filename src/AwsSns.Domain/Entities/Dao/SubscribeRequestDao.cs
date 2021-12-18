namespace AwsSns.Domain.Entities.Dao
{
    public class SubscribeRequestDao
    {
        public string TopicArn { get; set; }
        public string EndPoint { get; set; }
        public string Protocol { get; set; }
    }
}
