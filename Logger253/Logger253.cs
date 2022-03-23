using System.Reflection;

namespace CMPS253.Loggers
{
    public class Logger253 : CMPS253.LoggerCore.ILogger
    {
        List<CMPS253.LoggerCore.ILogger> _loggers = new();
        public Logger253()
        {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string json = File.ReadAllText("config.json");
            var logs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CMPS253.LoggerCore.LogEntry>>(json);
            foreach (var item in logs)
            {
                System.Runtime.Remoting.ObjectHandle? T;
                string assemblyFile = $"{path}\\{item.AssemblyName}";

                if (item.Parameters == null)
                {
                    T = Activator.CreateInstanceFrom(assemblyFile, item.FullClassName);
                }
                else
                {
                    T = Activator.CreateInstanceFrom(
                        assemblyFile: assemblyFile
                        , typeName: item.FullClassName
                        , ignoreCase: true
                        , bindingAttr: BindingFlags.Instance | BindingFlags.Public
                        , args: item.Parameters
                        , binder: null
                        , culture: null
                        , activationAttributes: null
                        );
                }
                (T.Unwrap() as CMPS253.LoggerCore.ILogger)?.Log("hello");
            }
        }
        public void Log(string msg)
        {
            foreach (var logger in _loggers)
            {
                logger.Log(msg);
            }
        }
        public static void WriteJsonFile()
        {
            List<CMPS253.LoggerCore.LogEntry> logs = new();
            logs.Add(new("CMPS253.Loggers.ConsoleLogger", "ConsoleLoggerLib.dll", null));
            logs.Add(new("CMPS253.Loggers.FileLogger", "FileLoggerLib.dll", new string[] { @"c:\trash\log2.txt" }));
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(logs);
            File.WriteAllText("config.json", json);
        }
    }
}
