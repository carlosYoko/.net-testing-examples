namespace CG.Testing.MyLibrary
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public double GetPrice(IClient client)
        {
            if (client.IsPremium)
            {
                return Price * 0.8;
            }

            return Price;
        }
    }
}
