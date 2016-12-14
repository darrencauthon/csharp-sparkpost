using System;
using System.Collections.Generic;
using SparkPost.Utilities;

namespace SparkPost
{
    public class ListSubaccountResponse : Response
    {
        public IEnumerable<Subaccount> Subaccounts { get; set; }

        public static ListSubaccountResponse CreateFromResponse(Response response)
        {
            var result = new ListSubaccountResponse();
            LeftRight.SetValuesToMatch(result, response);

            var results = Jsonification.DeserializeObject<dynamic>(response.Content).results;
            var subaccounts = new List<Subaccount>();
            foreach (var r in results)
                subaccounts.Add(ConvertToSubaccount(r));

            result.Subaccounts = subaccounts;
            return result;
        }

        private static Subaccount ConvertToSubaccount(dynamic result)
        {
            return new Subaccount
            {
                Id = result.id,
                Name = result.name,
                Status = Enum.Parse(typeof(SubaccountStatus), result.status.ToString(), true),
                ComplianceStatus = result.compliance_status
            };
        }
    }
}