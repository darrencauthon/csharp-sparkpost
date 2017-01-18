namespace SparkPost
{
    public class SendTransmissionResponse : Response
    {
        public string Id { get; set; }
        public int TotalAcceptedRecipients { get; set; }
        public int TotalRejectedRecipients { get; set; }
    }
}