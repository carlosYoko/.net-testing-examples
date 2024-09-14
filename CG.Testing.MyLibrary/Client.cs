namespace CG.Testing.MyLibrary
{
    public class Client
    {
        public string ClientName { get; set; }
        public int Discount = 10;

        public string CreateFullName(string name, string surname)
        {
            ClientName = name + " " + surname;
            Discount = 30;

            return ClientName;
        }
    }
}
