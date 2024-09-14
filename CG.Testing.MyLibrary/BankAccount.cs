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
            _logger.Message($"Depositando la cantidad: {amount}");
            _logger.Message("Otro texto");
            _logger.Message("Otro texto mas");
            _logger.PriorityLogger = 100;
            var priority = _logger.PriorityLogger;

            Balance += amount;
            return true;
        }

        public bool Retire(int amount)
        {
            if (amount <= Balance)
            {
                _logger.LogDatabase($"Cantidad a retirar {amount.ToString()}");
                Balance -= amount;
                return _logger.LogBalanceAfterRetire(amount);
            };

            return _logger.LogBalanceAfterRetire(Balance - amount);
        }

        public int GetBalance()
        {
            return Balance;
        }

    }
}
