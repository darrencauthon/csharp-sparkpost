using System;
using System.Collections.Generic;

namespace SparkPost
{
    public class Webhook
    {
        public Webhook()
        {
            Events = new List<string>();
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Target { get; set; }
        public IList<string> Events { get; set; }

        public DateTime? LastSuccessful { get; set; }
        public DateTime? LastFailure { get; set; }

        public string AuthType { get; set; }
        public string AuthToken { get; set; }
        public object AuthRequestDetails { get; set; }
        public object AuthCredentials { get; set; }
    }
}