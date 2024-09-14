namespace CG.Testing.MyLibrary
{
    public interface ILoggerGeneral
    {
        void Message(string message);
    }

    public class LoggerGeneral : ILoggerGeneral
    {
        public void Message(string message)
        {
            Console.WriteLine(message);
        }
    }
}
