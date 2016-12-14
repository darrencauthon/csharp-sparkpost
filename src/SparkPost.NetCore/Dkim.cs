namespace SparkPost
{
    public class Dkim
    {
        public string SigningDomain { get; set; }

        public string PrivateKey { get; set; }

        public string PublicKey { get; set; }

        public string Selector { get; set; }

        public string Headers { get; set; }

        /// <summary>
        ///     Convert json result form Sparkpost API to Dkim.
        /// </summary>
        /// <param name="result">Json result form Sparkpost API.</param>
        /// <returns></returns>
        public static Dkim ConvertToDkim(dynamic result)
        {
            return result != null
                ? new Dkim
                {
                    SigningDomain = result["public"],
                    PublicKey = result["private"],
                    Selector = result.selector,
                    Headers = result.headers
                }
                : null;
        }
    }
}