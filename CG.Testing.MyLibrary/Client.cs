namespace CG.Testing.MyLibrary
{
    public interface IClient
    {
        string ClientName { get; set; }
        int OrderTotal { get; set; }
        int Discount { get; set; }
        bool IsPremium { get; set; }
        string CreateFullName(string name, string surname);
        TypeClient GetClientDetail();
    }

    public class Client : IClient
    {
        public string ClientName { get; set; }
        public int OrderTotal { get; set; }
        public int Discount { get; set; }
        public bool IsPremium { get; set; }

        public Client()
        {
            Discount = 10;
            IsPremium = false;
        }

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
