namespace SparkPost
{

    public class SubaccountCreate
    {
        public string Name { get; set; }
        public string KeyLabel { get; set; }
        public string[] KeyGrants { get; set; }
    }
}