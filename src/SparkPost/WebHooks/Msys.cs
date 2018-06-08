using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class Msys
    {
        [JsonProperty("message_event")]
        public MessageEvent MessageEvent
        {
            get;
            set;
        }

        [JsonProperty("track_event")]
        public TrackEvent TrackEvent
        {
            get;
            set;
        }

        [JsonProperty("gen_event")]
        public GenEvent GenEvent
        {
            get;
            set;
        }

        [JsonProperty("unsubscribe_event")]
        public UnsubscribeEvent UnsubscribeEvent
        {
            get;
            set;
        }

        [JsonProperty("relay_event")]
        public RelayEvent RelayEvent
        {
            get;
            set;
        }

        [JsonProperty("relay_message")]
        public RelayMessage RelayMessage
        {
            get;
            set;
        }
    }
}