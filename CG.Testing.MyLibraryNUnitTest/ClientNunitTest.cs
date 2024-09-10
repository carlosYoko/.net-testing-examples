using NUnit.Framework;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class ClientNunitTest
    {
        [Test]
        public void CreateFullName_InputNameSurname_ReturnFUllName()
        {
            // Arrange
            Client client = new Client();

            // Act
            var result = client.CreateFullName("Carlos", "Gimenez");

            // Asert
            Assert.That(result, Is.EqualTo("Carlos Gimenez"));
        }
    }
}
