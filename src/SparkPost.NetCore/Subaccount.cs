namespace SparkPost
{
    public class Subaccount
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public SubaccountStatus Status { get; set; }
        public string IpPool { get; set; }
        public string ComplianceStatus { get; set; }
    }
}
