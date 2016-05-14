using Newtonsoft.Json;

namespace SparkPost.WebHooks
{
    public class GeoIp
    {
        [JsonProperty("country")]
        public string Country
        {
            get;
            set;
        }

        [JsonProperty("region")]
        public string Region
        {
            get;
            set;
        }

        [JsonProperty("city")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty("latitude")]
        public float Latitude
        {
            get;
            set;
        }

        [JsonProperty("longitude")]
        public float Longitude
        {
            get;
            set;
        }
    }
}