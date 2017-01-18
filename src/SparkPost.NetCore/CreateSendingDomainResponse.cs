namespace SparkPost
{
    public class CreateSendingDomainResponse : Response
    {
        public string Domain { get; set; }
        
        public Dkim Dkim { get; set; }
    }
}