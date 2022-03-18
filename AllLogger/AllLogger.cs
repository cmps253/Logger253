using Logger253;

namespace Driver
{
    public class AllLogger
    {
        string _fileName;
        public AllLogger(string fileName)
        {
            _fileName = fileName;
        }
        public void Log(string msg)
        {
            new ConsoleLogger().Log(msg);
            new FileLogger(_fileName).Log(msg);
        }
    }
}
