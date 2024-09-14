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

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void Retire_InputAmountWithBalance200_ReturnsTrue(int balance, int amount)
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.Setup(s => s.LogDatabase(It.IsAny<string>())).Returns(true);
            loggerGeneralMock.Setup(s => s.LogBalanceAfterRetire(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new BankAccount(loggerGeneralMock.Object);
            bankAccount.Deposit(balance);

            // Act
            var result = bankAccount.Retire(amount);

            // Assert
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(200, 300)]
        public void Retire_InputAmount100WithBalance200_ReturnsFalse(int balance, int amount)
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.Setup(s => s.LogBalanceAfterRetire(It.Is<int>(x => x < 0))).Returns(false);

            BankAccount bankAccount = new BankAccount(loggerGeneralMock.Object);
            bankAccount.Deposit(balance);

            // Act
            var result = bankAccount.Retire(amount);

            // Assert
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        public void BankAccountLoggerGeneral_LogMocking_ReturnsTrue()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textTest = "hello world";
            loggerGeneralMock.Setup(s => s.MessageWithReturnStr(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            // Act
            var result = loggerGeneralMock.Object.MessageWithReturnStr("Hello World");

            // Assert
            Assert.That(result, Is.EqualTo(textTest));
        }
    }
}
