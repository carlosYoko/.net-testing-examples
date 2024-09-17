using Moq;
using Xunit;

namespace CG.Testing.MyLibrary
{
    public class ProductXUnitTest
    {
        [Fact]
        public void GetPrice_PremiumClient_ReturnsPrice80PerCent()
        {
            // Arrange
            Product product = new Product() { Price = 50 };

            // Act
            var result = product.GetPrice(new Client() { IsPremium = true });

            // Assert
            Assert.Equal(40, result);
        }

        [Fact]
        public void GetPrice_PremiumClientMoq_ReturnsPrice80PerCent()
        {
            // Arrange
            Product product = new Product() { Price = 50 };

            var clientMock = new Mock<IClient>();
            clientMock.Setup(s => s.IsPremium).Returns(true);

            // Act
            var result = product.GetPrice(clientMock.Object);

            // Assert
            Assert.Equal(40, result);
        }
    }
}
