using Moq;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class ProductXUnitTest
    {
        [Test]
        public void GetPrice_PremiumClient_ReturnsPrice80PerCent()
        {
            // Arrange
            Product product = new Product() { Price = 50 };

            // Act
            var result = product.GetPrice(new Client() { IsPremium = true });

            // Assert
            Assert.That(result, Is.EqualTo(40));
        }

        [Test]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80PerCent()
        {
            // Arrange
            Product product = new Product() { Price = 50 };

            var clientMock = new Mock<IClient>();
            clientMock.Setup(s => s.IsPremium).Returns(true);

            // Act
            var result = product.GetPrice(clientMock.Object);

            // Assert
            Assert.That(result, Is.EqualTo(40));
        }
    }
}
