namespace SparkPost
{
    public class Address
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string HeaderTo { get; set; }

        public Address()
        {
        }

        public Address(string email): this(email, null, null)
        {
        }

        public Address(string email, string name): this(email, name, null)
        {
        }

        public Address(string email, string name, string headerTo)
        {
            this.Email = email;
            this.Name = name;
            this.HeaderTo = headerTo;
        }
    }
}