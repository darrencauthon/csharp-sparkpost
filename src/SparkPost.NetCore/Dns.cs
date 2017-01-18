namespace SparkPost
{
    public class Dns
    {
        public string DkimRecord { get; set; }

        public string SpfRecord { get; set; }

        public string DkimError { get; set; }

        public string SpfError { get; set; }

        /// <summary>
        ///     Convert json result form Sparkpost API to Dns.
        /// </summary>
        /// <param name="result">Json result form Sparkpost API.</param>
        /// <returns></returns>
        public static Dns ConvertToDns(dynamic result)
        {
            return result != null
                ? new Dns
                {
                    DkimError = result.dkim_error,
                    DkimRecord = result.dkim_record,
                    SpfError = result.spf_error,
                    SpfRecord = result.spf_record
                }
                : null;
        }
    }
}