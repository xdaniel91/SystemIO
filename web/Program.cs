using System.Net;



//FirstAsync();
//Second();
await ThirdAsync();

// retorna o html do site usando WebClient de forma assincrona
static async Task FirstAsync()
{
    WebClient client = new WebClient();
    var stringdownloaded = await client.DownloadStringTaskAsync("https://balta.io");
    Console.WriteLine(stringdownloaded);
}

// retorna o html do site usando WebRequest
static void Second()
{
    var request = WebRequest.Create("https://balta.io");
    var response = request.GetResponse();
    using (var responseReader = new StreamReader(response.GetResponseStream()))
    {
        var siteText = responseReader.ReadToEnd();
        Console.WriteLine(siteText);
    }
}

// retorna o html do site usando HttRequest
static async Task ThirdAsync()
{
    var client = new HttpClient();
    var stringdownloaded = await client.GetStringAsync("https://balta.io");
    Console.WriteLine(stringdownloaded);
}
