namespace SparkPost
{
    public class VerifySendingDomain
    {
        public string Domain { get; set; }
        
        public bool SpfVerify { get; set; }
        
        public bool DkimVerify { get; set; }
        
        public bool PostmasterAtVerify { get; set; }
        
        public string PostmasterAtToken { get; set; }
        
        public string AbuseAtToken { get; set; }
    }
}