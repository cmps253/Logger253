namespace CMPS253.LoggerCore
{
    public abstract class BaseLogger : ILogger
    {
        protected abstract void ConcreteLogging(string msg);
        private string FormatMessage(string msg) => $"{DateTime.Now}: {msg}\n";
        public void Log(string msg)
        {
            ConcreteLogging(FormatMessage(msg));
        }
    }
}