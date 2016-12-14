namespace SparkPost
{
    public class SendRecipientListsResponse : Response
    {
        public string Id { get; set; }
        public int TotalAcceptedRecipients { get; set; }
        public int TotalRejectedRecipients { get; set; }
        public string Name { get; set; }
    }
}