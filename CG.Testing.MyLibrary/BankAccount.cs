namespace CG.Testing.MyLibrary
{
    public class BankAccount
    {
        public int Balance { get; set; }

        public BankAccount()
        {
            Balance = 0;
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
