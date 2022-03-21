using CMPS253.LoggerCore;
using CMPS253.Loggers;

namespace CMPS253.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new AllLogger();
            logger.Log("Test");
        }
    }
}