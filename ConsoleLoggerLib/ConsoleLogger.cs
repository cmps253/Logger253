using CMPS253.LoggerCore;

namespace CMPS253.Loggers
{
    public class ConsoleLogger : BaseLogger
    {
        protected override void ConcreteLogging(string msg)
        {
            Console.WriteLine(msg); //SRP: knowing HOW to log
        }
    }
}
