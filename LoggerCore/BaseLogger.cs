namespace LoggerCore
{
    public abstract class BaseLogger
    {
        public abstract void Log(string msg);
        protected string FormatMessage(string msg) => $"{DateTime.Now}: {msg}\n";
    }
}