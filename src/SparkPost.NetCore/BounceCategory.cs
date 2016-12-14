namespace SparkPost
{
    // The list was taken from:
    // https://support.sparkpost.com/customer/portal/articles/1929896

    public enum BounceCategory
    {
        /// <summary>
        /// None or unable to parse.
        /// </summary>
        Undefined,

        /// <summary>
        /// The response text could not be identified.
        /// </summary>
        Undetermined,

        /// <summary>
        /// Hard bounce: Invalid recipient, no recipient.
        /// </summary>
        Hard,

        /// <summary>
        /// Soft bounce: soft bounced, DNS failure, MX record not found, mailbox is full, message too large, timeout, delayed, auto-reply, unspecified reason.
        /// </summary>
        Soft,

        /// <summary>
        /// The message was failed by Momentum's (SparkPost) configured policies or the message is a subscribe request.
        /// </summary>
        Admin,

        /// <summary>
        /// The message was blocked by the receiver (spam).
        /// </summary>
        Block
    }
}
