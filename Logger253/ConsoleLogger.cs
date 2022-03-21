using LoggerCore;

namespace Logger253
{
    public class ConsoleLogger : BaseLogger
    {
        protected override void ConcreteLogging(string msg)
        {
            Console.WriteLine(msg); //SRP: knowing HOW to log
        }
    }
}
