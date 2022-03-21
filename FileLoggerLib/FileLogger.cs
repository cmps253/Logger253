using CMPS253.LoggerCore;

namespace CMPS253.Loggers
{
    public class FileLogger : BaseLogger
    {
        string _fileName;
        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }
        protected override void ConcreteLogging(string msg)
        {
            File.AppendAllText(_fileName, msg);
        }
    }
}