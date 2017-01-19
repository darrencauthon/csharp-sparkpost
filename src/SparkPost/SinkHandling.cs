using System;
using System.Collections.Generic;
using System.Linq;

namespace SparkPost
{
    internal static class SinkHandling
    {
        private static readonly string SINK_DOMAIN = ".sink.sparkpostmail.com";

        internal static void AddSinkDomainToAddresses(IDictionary<string, object> result)
        {
            if (result.ContainsKey("recipients"))
            {
                var recipients = (result["recipients"] as IEnumerable<IDictionary<string, object>>).ToList();
                foreach (var recipient in recipients)
                {
                    AddSinkDomainToAddress(recipient, "email");
                    AddSinkDomainToAddress(recipient, "header_to");                                        
                }
                result["recipients"] = recipients;
            }
        }

        private static void AddSinkDomainToAddress(IDictionary<string, object> recipient, string fieldName)
        {
            if (recipient.ContainsKey("address"))
            {
                var address = recipient["address"] as IDictionary<string, object>;
                if (address.ContainsKey(fieldName))
                {
                    var emailAddress = (string)address[fieldName];
                    if (!String.IsNullOrWhiteSpace(emailAddress) && !emailAddress.EndsWith(SINK_DOMAIN, true, null))
                        address[fieldName] = emailAddress + SINK_DOMAIN;

                }
            }
        }
    }
}
