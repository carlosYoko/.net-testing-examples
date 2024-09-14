﻿namespace CG.Testing.MyLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterRetire(int balanceAfterRetire);
        string MessageWithReturnStr(string message);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public bool LogBalanceAfterRetire(int balanceAfterRetire)
        {
            if (balanceAfterRetire >= 0)
            {
                Console.WriteLine("Operacion realizada");
                return true;
            }

            Console.WriteLine("Error. Operacion no realizada");
            return false;
        }

        public bool LogDatabase(string message)
        {
            Console.WriteLine(message);
            return true;
        }

        public void Message(string message)
        {
            Console.WriteLine(message);
        }

        public string MessageWithReturnStr(string message)
        {
            Console.WriteLine(message);
            return message.ToLower();
        }
    }

    public class LoggerFake : ILoggerGeneral
    {
        public bool LogBalanceAfterRetire(int balanceAfterRetire)
        {
            return false;
        }

        public bool LogDatabase(string message)
        {
            return false;
        }

        public void Message(string message)
        { }

        public string MessageWithReturnStr(string message)
        {
            return message;
        }
    }
}
