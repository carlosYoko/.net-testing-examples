namespace CG.Testing.MyLibrary
{
    public class Client
    {
        public string ClientName { get; set; }

        public string CreateFullName(string name, string surname)
        {
            ClientName = name + " " + surname;

            return ClientName;
        }
    }
}
