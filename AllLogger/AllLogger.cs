using CMPS253.LoggerCore;

namespace CMPS253.Loggers
{
    public class AllLogger : ILogger
    {
        List<ILogger> _loggers = new();
        public AllLogger()
        {
            IConfigFile config = new ConfigFile();
            List<(string logger, string constructorParam)>? loggers = config.GetValueList("logger");

            foreach (var item in loggers)
            {
                var T = Type.GetType(item.logger);
                ILogger L;
                if (item.constructorParam == null)
                {
                    L = (ILogger)Activator.CreateInstance(T);
                }
                else
                {
                    L = (ILogger)Activator.CreateInstance(T, new object[] { item.constructorParam });
                }
                _loggers.Add(L);
            }
        }
        public void Log(string msg)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(msg);
            }
        }
    }
}
