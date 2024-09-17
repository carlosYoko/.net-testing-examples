using Moq;
using Xunit;

namespace CG.Testing.MyLibrary
{
    public class BankAccountXUnitTest
    {
        private BankAccount account;

        [Fact]
        public void Deposit_InputAmount100LoggerFake_ReturnsTrue()
        {
            // Arrange
            BankAccount bankAccount = new BankAccount(new LoggerFake());
            var amount = 100;

            // Act
            var result = bankAccount.Deposit(amount);

            // Assert
            Assert.True(result);
            Assert.Equal(100, bankAccount.Balance);
        }


        [Fact]
        public void Deposit_InputAmount100Mocking_ReturnsTrue()
        {
            // Arrange
            var loggerMock = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(loggerMock.Object);
            var amount = 100;

            // Act
            var result = bankAccount.Deposit(amount);

            // Assert
            Assert.True(result);
            Assert.Equal(100, bankAccount.GetBalance());
        }

        [Theory]
        [InlineData(200, 100)]
        [InlineData(200, 150)]
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
            Assert.True(result);
        }

        [Theory]
        [InlineData(200, 300)]
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
            Assert.False(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMocking_ReturnsTrue()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textTest = "hello world";
            loggerGeneralMock.Setup(s => s.MessageWithReturnStr(It.IsAny<string>())).Returns<string>(str => str.ToLower());

            // Act
            var result = loggerGeneralMock.Object.MessageWithReturnStr("Hello World");

            // Assert
            Assert.Equal(textTest, result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingOutPut_ReturnsTrue()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            string textTest = "hola";
            loggerGeneralMock.Setup(s => s.MessageWithOutParameterReturnBool(It.IsAny<string>(), out textTest)).Returns(true);

            // Act
            string outParameter = "";
            var result = loggerGeneralMock.Object.MessageWithOutParameterReturnBool("Carlos", out outParameter);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingObjectRef_ReturnsTrue()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            IClient client = new Client();
            IClient clientUnused = new Client();
            loggerGeneralMock.Setup(s => s.MessageWithObjectRefReturnBool(ref client)).Returns(true);

            // Act
            var resultClient = loggerGeneralMock.Object.MessageWithObjectRefReturnBool(ref client);
            var resultClientUnused = loggerGeneralMock.Object.MessageWithObjectRefReturnBool(ref clientUnused);

            // Assert
            Assert.True(resultClient);
            Assert.False(resultClientUnused);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingPropertiesPriorityType_ReturnsTrue()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.SetupAllProperties();
            loggerGeneralMock.Setup(s => s.TypeLogger).Returns("warning");

            //loggerGeneralMock.Setup(s => s.PriorityLogger).Returns(10);
            loggerGeneralMock.Object.PriorityLogger = 10;

            // Act
            var typeLogger = loggerGeneralMock.Object.TypeLogger;
            var priorityLogger = loggerGeneralMock.Object.PriorityLogger;

            // Assert
            Assert.Equal("warning", typeLogger);
            Assert.Equal(10, priorityLogger);
        }

        [Fact]
        public void BankAccountLoggerGeneral_LogMockingCallback_ReturnsTrue()
        {
            // Arrange
            string textTemporal = "Hello";
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            loggerGeneralMock.Setup(s => s.LogDatabase(It.IsAny<string>())).Returns(true).Callback<string>(param => textTemporal += param);

            // Act
            loggerGeneralMock.Object.LogDatabase("World");

            // Assert
            Assert.Equal("HelloWorld", textTemporal);
        }

        [Fact]
        public void BankAccountLogger_VerifyExamples()
        {
            // Arrange
            var loggerGeneralMock = new Mock<ILoggerGeneral>();
            BankAccount bankAccount = new BankAccount(loggerGeneralMock.Object);

            // Act
            bankAccount.Deposit(100);

            // Assert
            Assert.Equal(100, bankAccount.GetBalance());

            loggerGeneralMock.Verify(v => v.Message(It.IsAny<string>()), Times.Exactly(3));
            loggerGeneralMock.Verify(v => v.Message("Otro texto"), Times.AtLeastOnce);
            loggerGeneralMock.VerifySet(v => v.PriorityLogger = It.IsAny<int>(), Times.Once);
            loggerGeneralMock.VerifyGet(v => v.PriorityLogger, Times.Once);
        }
    }
}
