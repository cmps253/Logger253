using Driver;
using LoggerCore;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new AllLogger(@"c:\trash\log2.txt");
            logger.Log("hello");
        }
    }
}