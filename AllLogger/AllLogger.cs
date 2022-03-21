using Logger253;
using LoggerCore;

namespace Driver
{
    public class AllLogger : BaseLogger
    {
        string _fileName;
        public AllLogger(string fileName)
        {
            _fileName = fileName;
        }
        protected override void ConcreteLogging(string msg)
        {
            new ConsoleLogger().Log(msg);
            new FileLogger(_fileName).Log(msg);
        }
    }
}
