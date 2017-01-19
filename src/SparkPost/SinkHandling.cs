using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkPost
{
    internal static class SinkHandling
    {
        private static readonly string SINK_DOMAIN = ".sink.sparkpostmail.com";

        internal static void AddSinkDomainToAddresses(IDictionary<string, object> result)
        {
            if (result.ContainsKey("recipients"))
            {
                var recipients = result["recipients"] as IEnumerable<IDictionary<string, object>>;
                var addresses = recipients.Select(r => r["address"]).Cast<IDictionary<string, object>>();
                foreach (var address in addresses)
                {
                    address["email"] = AddSinkDomainToAddress((string)address["email"]);
                    address["header_to"] = AddSinkDomainToAddress((string)address["header_to"]);
                }
            }
        }

        private static string AddSinkDomainToAddress(string emailAddress)
        {
            if (!String.IsNullOrWhiteSpace(emailAddress) && !emailAddress.EndsWith(SINK_DOMAIN, true, null))
                return emailAddress + SINK_DOMAIN;
            else
                return emailAddress;
        }
    }
}
