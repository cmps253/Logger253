using AllLogger;
using CMPS253.LoggerCore;
using System.Reflection;
using System.Runtime.Remoting;

namespace CMPS253.Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            string? path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string json = File.ReadAllText("config.json");
            var logs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<LogEntry>>(json);
            foreach (var item in logs)
            {
                ObjectHandle? T;
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
                (T.Unwrap() as ILogger).Log("hello");
            }
        }
        public void WriteJsonFile()
        {
            List<LogEntry> logs = new();
            logs.Add(new("CMPS253.Loggers.ConsoleLogger", "ConsoleLoggerLib.dll", null));
            logs.Add(new("CMPS253.Loggers.FileLogger", "FileLoggerLib.dll", new string[] { @"c:\trash\log2.txt" }));
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(logs);
            File.WriteAllText("config.json", json);
        }
    }
}