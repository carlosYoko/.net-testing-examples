namespace CG.Testing.MyLibrary
{
    public class BankAccount
    {
        public int Balance { get; set; }
        private readonly ILoggerGeneral _logger;

        public BankAccount(ILoggerGeneral loggerGeneral)
        {
            Balance = 0;
            _logger = loggerGeneral;
        }

        public bool Deposit(int amount)
        {
            Balance += amount;
            return true;
        }

        public bool Retire(int amount)
        {
            if (amount < Balance)
            {
                _logger.Message($"Depositando la cantidad: {amount}");
                Balance -= amount;
                return true;
            };

            return false;
        }

        public int GetBalance()
        {
            return Balance;
        }

    }
}
