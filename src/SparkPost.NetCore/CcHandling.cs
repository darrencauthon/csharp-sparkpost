using System.Collections.Generic;
using System.Linq;

namespace SparkPost
{
    internal static class CcHandling
    {
        internal static void SetAnyCCsInTheHeader(Transmission transmission, IDictionary<string, object> result)
        {
            var ccs = GetTheCcEmails(transmission);

            if (ccs.Any() == false) return;

            MakeSureThereIsAHeaderDefinedInTheRequest(result);

            SetThisHeaderValue(result, "CC", FormatTheCCs(ccs));
        }

        private static string FormatTheCCs(IEnumerable<string> ccs)
        {
            return string.Join(",", ccs.Select(x => "<" + x + ">"));
        }

        private static IEnumerable<string> GetTheCcEmails(Transmission transmission)
        {
            return transmission.Recipients
                .Where(x => x.Type == RecipientType.CC)
                .Where(x => x.Address != null)
                .Where(x => string.IsNullOrWhiteSpace(x.Address.Email) == false)
                .Select(x => x.Address.Email);
        }

        private static void MakeSureThereIsAHeaderDefinedInTheRequest(IDictionary<string, object> result)
        {
            if (result.ContainsKey("content") == false)
                result["content"] = new Dictionary<string, object>();

            var content = result["content"] as IDictionary<string, object>;
            if (content.ContainsKey("headers") == false)
                content["headers"] = new Dictionary<string, string>();
        }

        private static void SetThisHeaderValue(IDictionary<string, object> result, string key, string value)
        {
            ((IDictionary<string, string>) ((IDictionary<string, object>) result["content"])["headers"])
                [key] = value;
        }
    }
}