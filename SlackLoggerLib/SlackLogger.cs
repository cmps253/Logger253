using CMPS253.LoggerCore;
using Newtonsoft.Json;
using System.Collections.Specialized;
using System.Net;
using System.Text;

namespace CMPS253.Loggers
{
    public class SlackLogger : BaseLogger
    {
        string _connectionString;
        public SlackLogger(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void ConcreteLogging(string msg)
        {
            string payloadJson = JsonConvert.SerializeObject(new { text = msg });

            using (WebClient client = new WebClient())
            {
                NameValueCollection data = new NameValueCollection();
                data["payload"] = payloadJson;
                var response = client.UploadValues(_connectionString, "POST", data);
                string responseText = new UTF8Encoding().GetString(response);
                Console.WriteLine(responseText);
            }
        }
    }
}