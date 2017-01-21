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
                foreach (var address in recipients
                        .Where(r => r.ContainsKey("address"))
                        .Select(r => r["address"])
                        .Cast<IDictionary<string, object>>())
                {
                    AddSinkDomainToAddress(address, "email");
                    AddSinkDomainToAddress(address, "header_to");                                        
                }
                result["recipients"] = recipients;
            }
        }

        private static void AddSinkDomainToAddress(IDictionary<string, object> address, string fieldName)
        {            
            if (address.ContainsKey(fieldName))
            {
                var currentAddress = (string)address[fieldName];
                if (!String.IsNullOrWhiteSpace(currentAddress) && !currentAddress.EndsWith(SINK_DOMAIN, true, null))
                    address[fieldName] = currentAddress + SINK_DOMAIN;

            }            
        }
    }
}
