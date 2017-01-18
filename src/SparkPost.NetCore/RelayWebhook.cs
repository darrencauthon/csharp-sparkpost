using System;
using System.Collections.Generic;

namespace SparkPost
{
    public class RelayWebhook
    {
        public RelayWebhook()
        {
            Match = new RelayWebhookMatch();
        }

        public string Id { get; set; }
        public string Target { get; set; }
        public string Name { get; set; }
        public string AuthToken { get; set; }
        public RelayWebhookMatch Match { get; set; }
    }

    public class RelayWebhookMatch
    {
        public RelayWebhookMatch()
        {
            Protocol = "SMTP";
        }

        public string Protocol { get; set; }
        public string Domain { get; set; }
    }
}