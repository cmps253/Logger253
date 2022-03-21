namespace CMPS253.Loggers
{
    public interface IConfigFile
    {
        List<(string logger, string constructorParam)> GetValueList(string key);
    }
}
