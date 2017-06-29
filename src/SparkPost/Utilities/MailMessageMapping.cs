#if !NETSTANDARD1_6
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;

namespace SparkPost.Utilities
{
    public static class MailMessageMapping
    {
        private static readonly Action<Transmission, MailMessage>[] Actions =
        {
            (t, m) => t.Content.From = ConvertToAddress(m.From),
            (t, m) => t.Content.Subject = m.Subject,
            (t, m) => AddRecipients(t, m.To, RecipientType.To),
            (t, m) => AddRecipients(t, m.CC, RecipientType.CC),
            (t, m) => AddRecipients(t, m.Bcc, RecipientType.BCC),
            (t, m) =>
            {
                if (m.ReplyToList.Any()) t.Content.ReplyTo = m.ReplyToList.First().Address;
            },
            (t, m) =>
            {
                if (m.IsBodyHtml) t.Content.Html = m.Body;
            },
            (t, m) =>
            {
                if (!m.IsBodyHtml) t.Content.Text = m.Body;
            },
            (t, m) =>
            {
                foreach (var attachment in m.Attachments)
                    t.Content.Attachments
                        .Add(File.Create<Attachment>(attachment.ContentStream, attachment.ContentType.Name));
            },
            (t, m) =>
            {
                var text = GetTheAlternativeView(m.AlternateViews, MediaTypeNames.Text.Plain);
                if (text != null)
                    t.Content.Text = text;
            },
            (t, m) =>
            {
                var html = GetTheAlternativeView(m.AlternateViews, MediaTypeNames.Text.Html);
                if (html != null)
                    t.Content.Html = html;
            }
        };

        public static Transmission ToTransmission(MailMessage message)
        {
            var transmission = new Transmission();
            ToTransmission(message, transmission);
            return transmission;
        }

        public static Transmission ToTransmission(MailMessage message, Transmission transmission)
        {
            foreach (var action in Actions)
                action(transmission, message);
            return transmission;
        }

        private static string GetTheAlternativeView(AlternateViewCollection views, string type)
        {
            return AlternativeViewsAreAvailable(views) ? GetViewContent(views, type) : null;
        }

        private static bool AlternativeViewsAreAvailable(AlternateViewCollection views)
        {
            var textTypes = new[] {MediaTypeNames.Text.Plain, MediaTypeNames.Text.Html};
            return views.Any() && (views.Count <= 2) &&
                   !views.Select(av => av.ContentType.MediaType).Except(textTypes).Any();
        }

        private static Address ConvertToAddress(MailAddress address)
        {
            return new Address(address.Address, address.DisplayName);
        }

        private static string GetViewContent(AlternateViewCollection views, string type)
        {
            var view = views.FirstOrDefault(v => v.ContentType.MediaType == type);
            return view == null ? null : GetViewContent(view);
        }

        private static string GetViewContent(AttachmentBase view)
        {
            var reader = new StreamReader(view.ContentStream);

            if (view.ContentStream.CanSeek)
                view.ContentStream.Position = 0;

            return reader.ReadToEnd();
        }

        private static void AddRecipients(Transmission transmission, MailAddressCollection addresses, RecipientType type)
        {
            foreach (var recipient in ConvertToRecipients(addresses, type))
                transmission.Recipients.Add(recipient);
        }

        private static IEnumerable<Recipient> ConvertToRecipients(MailAddressCollection addresses, RecipientType type)
        {
            return addresses.Select(a => ConvertToARecipient(type, a));
        }

        private static Recipient ConvertToARecipient(RecipientType type, MailAddress address)
        {
            return new Recipient
            {
                Type = type,
                Address = ConvertToAddress(address)
            };
        }
    }
}
#endif