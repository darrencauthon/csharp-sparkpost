using System;

namespace SparkPost
{
    public class RetrieveTransmissionResponse : Response
    {
        public string Id { get; set; }
        public string Description { get; set; }
        public DateTime? GenerationEndTime { get; set; }
        public int RecipientListTotalChunks { get; set; }
        public int RecipientListTotalSize { get; set; }
        public int NumberRecipients { get; set; }
        public int NumberGenerated { get; set; }
    }
}