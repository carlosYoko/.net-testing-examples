using NUnit.Framework;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class BankAccountNUnitTest
    {
        private BankAccount bankAccount;

        [SetUp]
        public void SetUp()
        {
            bankAccount = new BankAccount(new LoggerFake());
        }

        [Test]
        public void Deposit_InputAmount100_ReturnsTrue()
        {
            // Arrange
            var amount = 100;

            // Act
            var result = bankAccount.Deposit(amount);

            // Assert
            Assert.That(result, Is.True);
            Assert.That(bankAccount.Balance, Is.EqualTo(100));
        }
    }
}
