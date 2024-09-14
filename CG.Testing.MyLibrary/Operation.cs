namespace CG.Testing.MyLibrary
{
    public class Operation
    {
        public List<int> OddNumbers = new List<int>();

        public int AddNumbers(int a, int b) => a + b;

        public bool IsEven(int a) => a % 2 == 0;

        public double AddDecimal(double a, double b) => a + b;

        public List<int> GetListOddNumbers(int minInterval, int maxInterval)
        {
            OddNumbers.Clear();
            for (int i = minInterval; i < maxInterval; i++)
            {
                if (i % 2 != 0)
                {
                    OddNumbers.Add(i);
                }
            }

            return OddNumbers;
        }
    }
}
