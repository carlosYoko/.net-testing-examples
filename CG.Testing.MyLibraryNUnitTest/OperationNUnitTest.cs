using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace CG.Testing.MyLibrary
{
    [TestFixture]
    public class OperationNUnitTest
    {
        [Test]
        public void AddNumbers_InputTwoNumbers_GetCorrectValue()
        {
            // Arrange
            Operation op = new Operation();
            int numTest1 = 20;
            int numTest2 = 30;

            // Act
            int result = op.AddNumbers(numTest1, numTest2);

            // Assert
            ClassicAssert.AreEqual(50, result);

            // Assert (usando la sintaxis moderna)
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void IsEven_InputNumberEven_ReturnFalse()
        {
            // Arrange
            Operation op = new Operation();
            int numTest = 3;

            // Act
            bool result = op.IsEven(numTest);

            // Assert
            ClassicAssert.IsFalse(result);

            // Assert (usando la sintaxis moderna)
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase(3, ExpectedResult = false)]
        [TestCase(5, ExpectedResult = false)]
        public bool IsEven_InputNumberEven_ReturnFalse_With_ExpectedResult(int numTest)
        {
            // Arrange
            Operation op = new Operation();

            // Assert
            return op.IsEven(numTest);
        }

        [Test]
        [TestCase(4)]
        [TestCase(6)]
        [TestCase(8)]
        public void IsEven_InputNumberEven_ReturnTrue(int numTest)
        {
            // Arrange
            Operation op = new Operation();

            // Act
            bool result = op.IsEven(numTest);

            // Assert
            ClassicAssert.IsTrue(result);

            // Assert (usando la sintaxis moderna)
            Assert.That(result, Is.EqualTo(true));
        }

        [Test]
        [TestCase(2.2, 1.2)]
        [TestCase(2.23, 1.24)]
        public void AddDecimal_InputTwoNumbers_GetCorrectValue(double numTest1, double numTest2)
        {
            // Arrange
            Operation op = new Operation();

            // Act
            double result = op.AddDecimal(numTest1, numTest2);

            // Assert
            ClassicAssert.AreEqual(3.4, result, 0.1);

            // Assert (usando la sintaxis moderna)
            Assert.That(result, Is.EqualTo(3.4).Within(0.1));
        }

        [Test]
        public void GetListOddNumbers_InputMaxMinIntervals_ReturnsOddList()
        {
            // Arrange
            Operation op = new Operation();
            List<int> expectedList = new List<int>() { 5, 7, 9 };

            // Act
            List<int> result = op.GetListOddNumbers(5, 10);

            // Assert
            Assert.That(result, Is.EquivalentTo(expectedList));
        }

    }
}