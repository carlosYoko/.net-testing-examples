using Xunit;

namespace CG.Testing.MyLibrary
{
    public class OperationXUnitTest
    {
        [Fact]
        public void AddNumbers_InputTwoNumbers_GetCorrectValue()
        {
            // Arrange
            Operation op = new Operation();
            int numTest1 = 20;
            int numTest2 = 30;

            // Act
            int result = op.AddNumbers(numTest1, numTest2);

            // Assert
            Assert.Equal(50, result);
        }

        [Fact]
        public void IsEven_InputNumberEven_ReturnFalse()
        {
            // Arrange
            Operation op = new Operation();
            int numTest = 3;

            // Act
            bool result = op.IsEven(numTest);

            // Assert
            Assert.False(result);
        }

        [Theory]
        [InlineData(3, false)]
        [InlineData(5, false)]
        public void IsEven_InputNumberEven_ReturnFalse_With_ExpectedResult(int numTest, bool expectedResult)
        {
            // Arrange
            Operation op = new Operation();

            // Act
            var result = op.IsEven(numTest);

            // Assert
            Assert.Equal(expectedResult, result);
        }

        [Theory]
        [InlineData(4)]
        [InlineData(6)]
        [InlineData(8)]
        public void IsEven_InputNumberEven_ReturnTrue(int numTest)
        {
            // Arrange
            Operation op = new Operation();

            // Act
            bool result = op.IsEven(numTest);

            // Assert
            Assert.True(result);
        }

        [Theory]
        [InlineData(2.2, 1.2)]
        [InlineData(2.23, 1.24)]
        public void AddDecimal_InputTwoNumbers_GetCorrectValue(double numTest1, double numTest2)
        {
            // Arrange
            Operation op = new Operation();

            // Act
            double result = op.AddDecimal(numTest1, numTest2);

            // Assert
            Assert.Equal(3.4, result, 0);
        }

        [Fact]
        public void GetListOddNumbers_InputMaxMinIntervals_ReturnsOddList()
        {
            // Arrange
            Operation op = new Operation();
            List<int> expectedList = new List<int>() { 5, 7, 9 };

            // Act
            List<int> result = op.GetListOddNumbers(5, 10);

            // Assert
            Assert.Equal(expectedList, result);
            Assert.Contains(5, result);
            Assert.DoesNotContain(100, result);
            Assert.NotEmpty(result);
            Assert.Equal(3, result.Count);
            Assert.Equal(result.OrderBy(u => u), result);
        }

    }
}