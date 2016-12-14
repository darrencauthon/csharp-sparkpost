using System.Collections.Generic;

namespace SparkPost
{
    public static class BounceClassesDetails
    {
        public static Dictionary<BounceClass, BounceClassDetails> AllBounceClasses { get; private set; }

        static BounceClassesDetails()
        {
            // The list was taken from:
            // https://support.sparkpost.com/customer/portal/articles/1929896
            AllBounceClasses = new Dictionary<BounceClass, BounceClassDetails>();
            AllBounceClasses[BounceClass.Undefined] = (new BounceClassDetails { BounceClass = BounceClass.Undefined, Name = "Undefined", Description = "Undefined/unknown or unable to parse.", Category = BounceCategory.Undefined });
            AllBounceClasses[BounceClass.Undetermined] = (new BounceClassDetails { BounceClass = BounceClass.Undetermined, Name = "Undetermined", Description = "The response text could not be identified.", Category = BounceCategory.Undetermined });
            AllBounceClasses[BounceClass.InvalidRecipient] = (new BounceClassDetails { BounceClass = BounceClass.InvalidRecipient, Name = "Invalid Recipient", Description = "The recipient is invalid.", Category = BounceCategory.Hard });
            AllBounceClasses[BounceClass.SoftBounce] = (new BounceClassDetails { BounceClass = BounceClass.SoftBounce, Name = "Soft Bounce", Description = "The message soft bounced.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.DnsFailure] = (new BounceClassDetails { BounceClass = BounceClass.DnsFailure, Name = "DNS Failure", Description = "The message bounced due to a DNS failure.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.MailboxFull] = (new BounceClassDetails { BounceClass = BounceClass.MailboxFull, Name = "Mailbox Full", Description = "The message bounced due to the remote mailbox being over quota.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.TooLarge] = (new BounceClassDetails { BounceClass = BounceClass.TooLarge, Name = "Too Large", Description = "The message bounced because it was too large for the recipient.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.Timeout] = (new BounceClassDetails { BounceClass = BounceClass.Timeout, Name = "Timeout", Description = "The message timed out.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.AdminFailure] = (new BounceClassDetails { BounceClass = BounceClass.AdminFailure, Name = "Admin Failure", Description = "The message was failed by Momentum's configured policies.", Category = BounceCategory.Admin });
            AllBounceClasses[BounceClass.GenericBounceNoRecipient] = (new BounceClassDetails { BounceClass = BounceClass.GenericBounceNoRecipient, Name = "Generic Bounce: No RCPT", Description = "No recipient could be determined for the message.", Category = BounceCategory.Hard });
            AllBounceClasses[BounceClass.GenericBounce] = (new BounceClassDetails { BounceClass = BounceClass.GenericBounce, Name = "Generic Bounce", Description = "The message failed for unspecified reasons.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.MailBlock] = (new BounceClassDetails { BounceClass = BounceClass.MailBlock, Name = "Mail Block", Description = "The message was blocked by the receiver.", Category = BounceCategory.Block });
            AllBounceClasses[BounceClass.SpamBlock] = (new BounceClassDetails { BounceClass = BounceClass.SpamBlock, Name = "Spam Block", Description = "The message was blocked by the receiver as coming from a known spam source.", Category = BounceCategory.Block });
            AllBounceClasses[BounceClass.SpamContent] = (new BounceClassDetails { BounceClass = BounceClass.SpamContent, Name = "Spam Content", Description = "The message was blocked by the receiver as spam.", Category = BounceCategory.Block });
            AllBounceClasses[BounceClass.ProhibitedAttachment] = (new BounceClassDetails { BounceClass = BounceClass.ProhibitedAttachment, Name = "Prohibited Attachment", Description = "The message was blocked by the receiver because it contained an attachment.", Category = BounceCategory.Block });
            AllBounceClasses[BounceClass.RelayingDenied] = (new BounceClassDetails { BounceClass = BounceClass.RelayingDenied, Name = "Relaying Denied", Description = "The message was blocked by the receiver because relaying is not allowed.", Category = BounceCategory.Block });
            AllBounceClasses[BounceClass.AutoReply] = (new BounceClassDetails { BounceClass = BounceClass.AutoReply, Name = "Auto-Reply", Description = "The message is an auto-reply/vacation mail.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.TransientFailure] = (new BounceClassDetails { BounceClass = BounceClass.TransientFailure, Name = "Transient Failure", Description = "Message transmission has been temporarily delayed.", Category = BounceCategory.Soft });
            AllBounceClasses[BounceClass.Subscribe] = (new BounceClassDetails { BounceClass = BounceClass.Subscribe, Name = "Subscribe", Description = "The message is a subscribe request.", Category = BounceCategory.Admin });
            AllBounceClasses[BounceClass.Unsubscribe] = (new BounceClassDetails { BounceClass = BounceClass.Unsubscribe, Name = "Unsubscribe", Description = "The message is an unsubscribe request.", Category = BounceCategory.Hard });
            AllBounceClasses[BounceClass.ChallengeResponse] = (new BounceClassDetails { BounceClass = BounceClass.ChallengeResponse, Name = "Challenge-Response", Description = "The message is a challenge-response probe.", Category = BounceCategory.Soft });
        }
    }
}
