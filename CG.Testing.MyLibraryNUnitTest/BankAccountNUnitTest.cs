using Moq;
using NUnit.Framework;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
        }

        [Test]
        public void Deposit_InputAmount100LoggerFake_ReturnsTrue()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount(new LoggerFake());
            var amount = 100;

            // Act
            var result = bankAccount.Deposit(amount);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(bankAccount.Balance, Is.EqualTo(100));
        }


        [Test]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            // Arrange
            var loggerMock = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            var amount = 100;

            // Act
            var result = bankAccount.Deposit(amount);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(bankAccount.Balance, Is.EqualTo(100));
        }
    }
}
