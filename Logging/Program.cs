namespace CMPS253.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            CMPS253.LoggerCore.ILogger logger = new CMPS253.Loggers.Logger253();
            logger.Log("Hello");
        }
    }
}