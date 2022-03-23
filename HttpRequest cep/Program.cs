using Newtonsoft.Json;
using System.Xml;

await ExecutarAsync();

async Task ExecutarAsync()
{
    Console.WriteLine("digite seu cep\n");
    var cep = Console.ReadLine();
    Console.WriteLine("\n -----------JSON----------- \n");

    using (var client = new HttpClient())
    {
        var json = await client.GetStringAsync(@$"https://viacep.com.br/ws/{cep}/json/");
        var end = JsonConvert.DeserializeObject<Endereco>(json);

        Console.WriteLine(@$"{end.Cep} | {end.Logradouro} | {end.Complemento} | {end.Localidade} | {end.Bairro} | {end.UF} | {end.Ibge} | {end.Gia}");
    }

    Console.WriteLine("\n -----------XML----------- \n");

    using (var client = new HttpClient())
    {
        var xml = await client.GetStringAsync($"https://viacep.com.br/ws/{cep}/xml/");
        using (var leitor = new StringReader(xml))
        {
            var leitorxml = new XmlTextReader(leitor);
            while(leitorxml.Read())
            {
                Console.WriteLine($"tipo:{leitorxml.NodeType} | {leitorxml.Name}");
            }
        }
  
    }

}


public class Endereco
{
    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Complemento { get; set; }
    public string Bairro { get; set; }
    public string Localidade { get; set; }
    public string UF { get; set; }
    public string Ibge { get; set; }
    public string Gia { get; set; }
    public int DDD { get; set; }
    public string Siafi { get; set; }

}
