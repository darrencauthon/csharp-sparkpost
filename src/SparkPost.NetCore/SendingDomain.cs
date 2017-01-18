namespace SparkPost
{
    public class SendingDomain
    {
        public string Domain { get; set; }

        public string TrackingDomain { get; set; }

        public SendingDomainStatus Status { get; set; }

        public Dkim Dkim { get; set; }

        public bool GenerateDkim { get; set; }

        public long DkimKeyLength { get; set; }

        public bool SharedWithSubAccounts { get; set; }

        /// <summary>
        /// Convert json result form Sparkpost API to SendingDomain.
        /// </summary>
        /// <param name="result">Json result form Sparkpost API.</param>
        /// <returns></returns>
        public static SendingDomain ConvertToSendingDomain(dynamic result)
        {
            return result != null ? new SendingDomain
                {
                    Domain = result.domain,
                    TrackingDomain = result.tracking_domain,
                    Status = SendingDomainStatus.ConvertToSendingDomainStatus(result.status),
                    Dkim = Dkim.ConvertToDkim(result.dkim),
                    GenerateDkim = result.generate_dkim ?? false,
                    DkimKeyLength = result.dkim_key_length ?? 0,
                    SharedWithSubAccounts = result.shared_with_subaccounts ?? false
                }
                : null;
        }
    }
}