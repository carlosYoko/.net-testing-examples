namespace CG.Testing.MyLibrary.MSTest
{
    [TestClass]
    public class OperationMSTest
    {
        [TestMethod]
        public void AddNumbers_InputTwoNumbers_GetCorrectValue()
        {
            // Arrange
            Operation op = new Operation();
            int numTest1 = 20;
            int numTest2 = 30;

            // Act
            int result = op.AddNumbers(numTest1, numTest2);

            // Asser
            Assert.AreEqual(50, result);
        }
    }
}
