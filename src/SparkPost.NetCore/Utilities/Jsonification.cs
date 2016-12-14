using Newtonsoft.Json;

namespace SparkPost.Utilities
{
    internal static class Jsonification
    {
        internal static T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        internal static string SerializeObject(object @object)
        {
            return JsonConvert.SerializeObject(@object,
                new JsonSerializerSettings {TypeNameHandling = TypeNameHandling.None});
        }
    }
}