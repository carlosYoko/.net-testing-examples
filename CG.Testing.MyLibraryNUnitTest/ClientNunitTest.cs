using NUnit.Framework;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class ClientNunitTest
    {
        private Client _client;

        [SetUp]
        public void SetUp()
        {
            _client = new Client();
        }

        [Test]
        public void CreateFullName_InputNameSurname_ReturnFUllName()
        {
            // Arrange

            // Act
            _client.CreateFullName("Carlos", "Gimenez");

            // Asert
            Assert.That(_client.ClientName, Is.EqualTo("Carlos Gimenez"));
            Assert.That(_client.ClientName, Does.Contain("Gimenez"));
            Assert.That(_client.ClientName, Does.Contain("carlos").IgnoreCase);
            Assert.That(_client.ClientName, Does.StartWith("Ca"));
            Assert.That(_client.ClientName, Does.EndWith("ez"));
        }

        [Test]
        public void ClientName_NoValues_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.That(_client.ClientName, Is.EqualTo(null));
        }

        [Test]
        public void DiscountEvaluation_DefaultClient_ReturnsDiscountInterval()
        {
            // Arrange

            // Act
            int discount = _client.Discount;

            // Assert
            Assert.That(discount, Is.InRange(5, 24));
        }

    }
}
