namespace CG.Testing.MyLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
        bool LogDatabase(string message);
        bool LogBalanceAfterRetire(int balanceAfterRetire);
        string MessageWithReturnStr(string message);
        bool MessageWithOutParameterReturnBool(string str, out string outPutStr);
        bool MessageWithObjectRefReturnBool(ref IClient client);
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

        public bool MessageWithObjectRefReturnBool(ref IClient client)
        {
            return true;
        }

        public bool MessageWithOutParameterReturnBool(string str, out string outPutStr)
        {
            outPutStr = "Hola" + str;
            return true;
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

        public bool MessageWithObjectRefReturnBool(ref IClient client)
        {
            return true;
        }

        public bool MessageWithOutParameterReturnBool(string str, out string outPutStr)
        {
            outPutStr = "";
            return true;
        }

        public string MessageWithReturnStr(string message)
        {
            return message;
        }
    }
}
