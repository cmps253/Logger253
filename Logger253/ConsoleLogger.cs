using LoggerCore;

namespace Logger253
{
    public class ConsoleLogger : BaseLogger
    {
        public override void Log(string msg)
        {
            Console.WriteLine(base.FormatMessage(msg)); //SRP: knowing HOW to log
        }
    }
}
