namespace CG.Testing.MyLibrary
{
    public class Client
    {
        public string ClientName { get; set; }
        public int OrderTotal { get; set; }
        public int Discount = 10;

        public string CreateFullName(string name, string surname)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentException("El nombre está en blanco");
            }

            ClientName = name + " " + surname;
            Discount = 30;

            return ClientName;
        }

        public TypeClient GetClientDetail()
        {
            if (OrderTotal < 500)
            {
                return new BasicClient();
            }

            return new PremiumClient();
        }
    }

    public class TypeClient { }
    public class BasicClient : TypeClient { }
    public class PremiumClient : TypeClient { }

}
