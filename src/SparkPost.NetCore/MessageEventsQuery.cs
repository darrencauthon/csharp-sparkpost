using SparkPost.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SparkPost
{
    public class MessageEventsQuery
    {

        public MessageEventsQuery()
        {
            this.Events = new List<string>();
            this.BounceClasses = new List<string>();
            this.CampaignIds = new List<string>();
            this.FriendlyFroms = new List<string>();
            this.MessageIds = new List<string>();
            this.Recipients = new List<string>();
            this.Subaccounts = new List<string>();
            this.TemplateIds = new List<string>();
            this.TransmissionIds = new List<string>();
        }

        /// <summary>
        /// bounce_classes : Number : Comma-delimited list of bounce classification codes to search.
        /// See Bounce Classification Codes at https://support.sparkpost.com/customer/portal/articles/1929896.
        /// Example: 1,10,20.
        /// </summary>
        public IList<string> BounceClasses { get; set; }

        /// <summary>
        /// campaign_ids : ? : (optional, string, `Example Campaign Name`) ... Comma-delimited list of campaign ID's to search (i.e. campaign_id used during creation of a transmission).
        /// </summary>
        public IList<string> CampaignIds { get; set; }

        /// <summary>
        /// events : List : Comma-delimited list of event types to search. Defaults to all event types.
        /// Example: delivery, injection, bounce, delay, policy_rejection, out_of_band, open, click, generation_failure, generation_rejection, spam_complaint, list_unsubscribe, link_unsubscribe.
        /// </summary>
        public IList<string> Events { get; set; }

        /// <summary>
        /// friendly_froms : ? : (optional, list, `sender@mail.example.com`) ... Comma-delimited list of friendly_froms to search.
        /// </summary>
        public IList<string> FriendlyFroms { get; set; }

        /// <summary>
        /// from : Datetime : Datetime in format of YYYY-MM-DDTHH:MM.
        /// Example: 2014-07-20T08:00.
        /// Default: One hour ago.
        /// </summary>
        public DateTime? From { get; set; }

        /// <summary>
        /// message_ids : List : Comma-delimited list of message ID's to search.
        /// Example: 0e0d94b7-9085-4e3c-ab30-e3f2cd9c273e.
        /// </summary>
        public IList<string> MessageIds { get; set; }

        /// <summary>
        /// page : number : The results page number to return. Used with per_page for paging through results.
        /// Example: 25.
        /// Default: 1.
        /// </summary>
        public int? Page { get; set; }

        /// <summary>
        /// per_page : Number : Number of results to return per page. Must be between 1 and 10,000 (inclusive).
        /// Example: 100.
        /// Default: 1000.
        /// </summary>
        public int? PerPage { get; set; }

        /// <summary>
        /// reason : String :Bounce/failure/rejection reason that will be matched using a wildcard(e.g., %reason%).
        /// Example: bounce.
        /// </summary>
        public string Reason { get; set; }

        /// <summary>
        /// recipients : List : Comma-delimited list of recipients to search.
        /// Example: recipient @example.com.
        /// </summary>
        public IList<string> Recipients { get; set; }

        /// <summary>
        /// subaccounts : List : Comma-delimited list of subaccount ID's to search.
        /// Example: 101.
        /// </summary>
        public IList<string> Subaccounts { get; set; }

        /// <summary>
        /// template_ids : List : Comma-delimited list of template ID's to search.
        /// Example: templ-1234.
        /// </summary>
        public IList<string> TemplateIds { get; set; }

        /// <summary>
        /// timezone : String : Standard timezone identification string.
        /// Example: America/New_York.
        /// Default: UTC.
        /// </summary>
        public string Timezone { get; set; }

        /// <summary>
        /// to : Datetime : Datetime in format of YYYY-MM-DDTHH:MM.
        /// Example: 2014-07-20T09:00.
        /// Default: now.
        /// </summary>
        public DateTime? To { get; set; }

        /// <summary>
        /// transmission_ids : List : Comma-delimited list of transmission ID's to search (i.e. id generated during creation of a transmission).
        /// Example: 65832150921904138.
        /// </summary>
        public IList<string> TransmissionIds { get; set; }

    }
}