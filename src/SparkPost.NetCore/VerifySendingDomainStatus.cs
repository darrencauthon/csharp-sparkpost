using System;
namespace SparkPost
{
    public class VerifySendingDomainStatus : SendingDomainStatus
    {
        public Dns Dns { get; set; }

        /// <summary>
        /// Convert json result form Sparkpost API to VerifySendingDomainStatus.
        /// </summary>
        /// <param name="result">Json result form Sparkpost API.</param>
        /// <returns></returns>
        public static VerifySendingDomainStatus ConvertToVerifySendingDomainStatus(dynamic result)
        {
            return result != null ? new VerifySendingDomainStatus
                {
                    OwnershipVerified = result.ownership_verified,
                    DkimStatus = Enum.Parse(typeof(DkimStatus), (result.dkim_status ?? DkimStatus.Unknowed).ToString(), true),
                    SpfStatus = Enum.Parse(typeof(SpfStatus), (result.spf_status ?? SpfStatus.Unknowed).ToString(), true),
                    AbuseAtStatus = Enum.Parse(typeof(AbuseAtStatus), (result.abuse_at_status ?? AbuseAtStatus.Unknowed).ToString(), true) ,
                    PostmasterAtStatus = Enum.Parse(typeof(PostmasterAtStatus), (result.postmaster_at_status ?? PostmasterAtStatus.Unknowed).ToString(), true),
                    ComplianceStatus = Enum.Parse(typeof(ComplianceStatus), (result.compliance_status ?? ComplianceStatus.Unknowed).ToString(), true),
                    Dns = Dns.ConvertToDns(result.dns)
                }
                : null;
        }
    }
}