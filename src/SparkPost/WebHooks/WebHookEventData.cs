using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class WebHookEventData
    {
        [JsonProperty("msys")]
        public Msys Msys { get; set; }
    }
}