using LoggerCore;

namespace Logger253
{
    public class FileLogger : BaseLogger
    {
        string _fileName;
        public FileLogger(string fileName)
        {
            _fileName = fileName;
        }
        public override void Log(string msg)
        {
            File.AppendAllText(_fileName, base.FormatMessage(msg));
        }
    }
}
