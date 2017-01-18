namespace SparkPost
{
    /// <summary>
    /// Provides access to the SparkPost API.
    /// </summary>
    public interface IClient
    {
        /// <summary>
        /// Gets or sets the key used for requests to the SparkPost API.
        /// </summary>
        string ApiKey { get; set; }

        /// <summary>
        /// Gets or sets the base URL of the SparkPost API.
        /// </summary>
        string ApiHost { get; set; }

        /// <summary>
        /// Gets access to the transmissions resource of the SparkPost API.
        /// </summary>
        ITransmissions Transmissions { get; }

        /// <summary>
        /// Gets access to the suppressions resource of the SparkPost API.
        /// </summary>
        ISuppressions Suppressions { get; }

        /// <summary>
        /// Gets access to the subaccounts resource of the SparkPost API.
        /// </summary>
        ISubaccounts Subaccounts { get; }

        /// <summary>
        /// Gets access to the webhooks resource of the SparkPost API.
        /// </summary>
        IWebhooks Webhooks { get; }

        /// <summary>
        /// Gets access to the message events resource of the SparkPost API.
        /// </summary>
        IMessageEvents MessageEvents { get; }

        /// <summary>
        /// Gets access to the inbound domains resource of the SparkPost API.
        /// </summary>
        IInboundDomains InboundDomains { get; }

        /// <summary>
        /// Gets access to the sending domains resource of the SparkPost API.
        /// </summary>
        ISendingDomains SendingDomains { get; }
        
        /// <summary>
        /// Gets access to the relay webhooks resource of the SparkPost API.
        /// </summary>
        IRelayWebhooks RelayWebhooks { get; }

        IRecipientLists RecipientLists { get; }

        /// <summary>
        /// Gets access to the Templates resource of the SparkPost API.
        /// </summary>
        ITemplates Templates { get; }

        /// <summary>
        /// Gets access to the metrics resource of the SparkPost API.
        /// </summary>
        IMetrics Metrics { get; }

        /// <summary>
        /// Gets the API version supported by this client.
        /// </summary>
        string Version { get; }

        /// <summary>
        /// Get the custom settings for this client.
        /// </summary>
        Client.Settings CustomSettings { get; }

        /// <summary>
        /// Gets the sub account.
        /// </summary>
        long SubaccountId { get; }
    }
}
