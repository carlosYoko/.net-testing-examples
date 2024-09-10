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

            //// Assert (usando la sintaxis moderna)
            //Assert.That(result, Is.EqualTo(50));
        }
    }
}