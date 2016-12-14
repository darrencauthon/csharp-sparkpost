namespace SparkPost
{
    public class UpdateSendingDomainResponse : Response
    {
        public string Domain { get; set; }
        
        public string TrackingDomain { get; set; }
        
        public Dkim Dkim { get; set; }
    }
}