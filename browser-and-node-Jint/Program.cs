using System;
using System.Net.Http;
using System.Threading.Tasks;
using Jint;

internal class Program
{
    private static void Main(string[] args)
    {
        var engine = new Engine();
        engine.SetValue("console", new JsConsole());
        engine.SetValue("http", new HttpRequester());

        engine.Execute(@"
// custom object
http.get('https://httpbin.org/anything');
");
    }
}

public class JsConsole
{
    public static void Log(string str)
    {
        Console.WriteLine(str);
    }
}

public class HttpRequester
{
    public static async ValueTask<string> Get(string url)
    {
        HttpClient client = new HttpClient();
        string responseText = await client.GetStringAsync(url);
        Console.WriteLine("body: " + responseText);
        return responseText;
    }
}
