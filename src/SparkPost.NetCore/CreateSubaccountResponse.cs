namespace SparkPost
{
    public class CreateSubaccountResponse : Response
    {
        public int SubaccountId { get; set; }
        public string Key { get; set; }
        public string Label { get; set; }
        public string ShortKey { get; set; }
    }
}