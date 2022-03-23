namespace CMPS253.LoggerCore
{
    public class LogEntry
    {
        public LogEntry(string fullClassName, string assemblyName, string[] parameters)
        {
            FullClassName = fullClassName;
            AssemblyName = assemblyName;
            Parameters = parameters;
        }

        public string FullClassName { get; }
        public string AssemblyName { get; }
        public object[] Parameters { get; }
    }
}
