using Xunit;

namespace CG.Testing.MyLibrary
{
    public class ClientXunitTest
    {
        private Client _client;

        public ClientXunitTest()
        {
            _client = new Client();
        }

        [Fact]
        public void CreateFullName_InputNameSurname_ReturnFUllName()
        {
            // Arrange

            // Act
            _client.CreateFullName("Carlos", "Gimenez");

            // Asert
            Assert.Equal("Carlos Gimenez", _client.ClientName);
            Assert.Contains("Gimenez", _client.ClientName);
            Assert.StartsWith("Ca", _client.ClientName);
            Assert.EndsWith("ez", _client.ClientName);
        }

        [Fact]
        public void ClientName_NoValues_ReturnsNull()
        {
            // Arrange

            // Act

            // Assert
            Assert.Null(_client.ClientName);
        }

        [Fact]
        public void DiscountEvaluation_DefaultClient_ReturnsDiscountInterval()
        {
            // Arrange

            // Act
            int discount = _client.Discount;

            // Assert
            Assert.InRange(discount, 5, 24);
        }

        [Fact]
        public void CreateFullName_InputName_ReturnsNotNull()
        {
            // Arrange

            // Act
            _client.CreateFullName("Carlos", "");

            // Assert
            Assert.NotNull(_client.ClientName);
            Assert.NotEmpty(_client.ClientName);
            Assert.False(string.IsNullOrEmpty(_client.ClientName));
        }

        [Fact]
        public void CreateFullName_InputNameBlank_ThrowsException()
        {
            // Arrange

            // Act
            var exceptionDetail = Assert.Throws<ArgumentException>(() => _client.CreateFullName("", "Giménez"));

            // Assert
            Assert.Equal("El nombre está en blanco", exceptionDetail!.Message);
        }

        [Fact]
        public void GetClientDetail_CreateClientWithLessThan500TotalOrder_ReturnsBasicClient()
        {
            // Arrange
            _client.OrderTotal = 150;

            // Act
            var result = _client.GetClientDetail();

            // Assert
            Assert.IsType<BasicClient>(result);
        }

        [Fact]
        public void GetClientDetail_CreateClientWithGreatherThan500TotalOrder_ReturnsPremiumClient()
        {
            // Arrange
            _client.OrderTotal = 650;

            // Act
            var result = _client.GetClientDetail();

            // Assert
            Assert.IsType<PremiumClient>(result);
        }
    }
}
