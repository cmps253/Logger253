namespace CMPS253.Loggers
{
    public class ConfigFile : IConfigFile
    {
        Dictionary<string, List<(string, string)>> dictionary = new();
        public ConfigFile()
        {
            const string SEPARATOR = "==";
            const string FILENAME = "config.txt";
            List<string>? lines = File.ReadAllLines(FILENAME).ToList();
            foreach (string line in lines)
            {
                string[]? a = line.Split(SEPARATOR);
                if(a==null) throw new FormatException("Config file is not properly formatted");
                if (!dictionary.ContainsKey(a[0]))
                {
                    dictionary.Add(a[0], new List<(string,string)>());
                }
                var e = a[1].Split("|");
                dictionary[a[0]].Add((e[0], e.Length==2?e[1]:null));
            }
        }

        public List<(string logger, string constructorParam)> GetValueList(string key)
        {
            if(dictionary.ContainsKey(key))
                return dictionary[key];
            return null;
            
        }
    }
}
