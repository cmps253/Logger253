using Driver;
using Logger253;
using LoggerCore;
using RestSharp;

namespace Logging
{
    class Program
    {
        static void Main(string[] args)
        {
            slack();
            return;
            var T = typeof(FileLogger).AssemblyQualifiedName;
            var objectType = Type.GetType(T);
            BaseLogger L = (BaseLogger)Activator.CreateInstance(objectType, new object[] { @"c:\trash\log2.txt" });
            L.Log("hello");

            return;
            var logger = new AllLogger(@"c:\trash\log2.txt");
            logger.Log("Program Started");
            Thread.Sleep(3000); //SRP: sending emails
            logger.Log("Program Ended");
        }
        static void slack()
        {
            var client = new RestClient("https://hooks.slack.com/services/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");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var body = new { text = "hello1" };
            var json = Newtonsoft.Json.JsonConvert.SerializeObject(body);
//            var body = @"{
//" + "\n" +
//@"    ""text"":""hello""
//" + "\n" +
//@"}";
            request.AddParameter("application/json", json, ParameterType.RequestBody);
            client.ExecuteAsync(request).Wait();
            //Task<RestResponse>? r = client.ExecuteAsync(request);
            //r.Wait();
            //Console.WriteLine(r.Result.StatusCode);
        }
    }
}