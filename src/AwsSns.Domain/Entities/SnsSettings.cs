namespace AwsSns.Domain.Entities
{
    public class SNSSettings
    {
        public string AWSRegion { get; set; }
        public string AWSAccessKey { get; set; }
        public string AWSSecretKey { get; set; }
        public string TopicArn { get; set; }
    }
}
