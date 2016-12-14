using System;

namespace SparkPost
{
    public class SendingDomainStatus
    {
        public bool OwnershipVerified { get; set; }

        public DkimStatus DkimStatus { get; set; }

        public SpfStatus SpfStatus { get; set; }

        public AbuseAtStatus AbuseAtStatus { get; set; }

        public PostmasterAtStatus PostmasterAtStatus { get; set; }

        public ComplianceStatus ComplianceStatus { get; set; }

        /// <summary>
        ///     Convert json result form Sparkpost API to SendingDomainStatus.
        /// </summary>
        /// <param name="result">Json result form Sparkpost API.</param>
        /// <returns></returns>
        public static SendingDomainStatus ConvertToSendingDomainStatus(dynamic result)
        {
            if (result == null) return null;
            return new SendingDomainStatus
            {
                OwnershipVerified = result.ownership_verified ?? false,
                DkimStatus =
                    Enum.Parse(typeof (DkimStatus), (result.dkim_status ?? DkimStatus.Unknowed).ToString(), true),
                SpfStatus =
                    Enum.Parse(typeof (SpfStatus), (result.spf_status ?? SpfStatus.Unknowed).ToString(), true),
                AbuseAtStatus =
                    Enum.Parse(typeof (AbuseAtStatus), (result.abuse_at_status ?? AbuseAtStatus.Unknowed).ToString(),
                        true),
                PostmasterAtStatus =
                    Enum.Parse(typeof (PostmasterAtStatus),
                        (result.postmaster_at_status ?? PostmasterAtStatus.Unknowed).ToString(), true),
                ComplianceStatus =
                    Enum.Parse(typeof (ComplianceStatus),
                        (result.compliance_status ?? ComplianceStatus.Unknowed).ToString(), true)
            };
        }
    }

    public enum DkimStatus
    {
        Unverified,
        Pending,
        Invalid,
        Valid,
        Unknowed
    }

    public enum SpfStatus
    {
        Unverified,
        Pending,
        Invalid,
        Valid,
        Unknowed
    }

    public enum AbuseAtStatus
    {
        Unverified,
        Pending,
        Invalid,
        Valid,
        Unknowed
    }

    public enum PostmasterAtStatus
    {
        Unverified,
        Pending,
        Invalid,
        Valid,
        Unknowed
    }

    public enum ComplianceStatus
    {
        Pending,
        Valid,
        Unknowed
    }
}