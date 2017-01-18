using Newtonsoft.Json;
namespace SparkPost
{
    public class GetSendingDomainResponse : Response
    {
        public SendingDomain SendingDomain { get; set; }
    }
}