using System.IO;
using System.Text;

string path = "C:\\Users\\DanielRodriguesCarva\\source\\repos\\Csharp parte8\\Csharp parte8\\Diretores.txt";
Executar();
Console.WriteLine();
Executar2();
Console.WriteLine();
Executar3();
Console.WriteLine();
Executar4();


void Executar()
{
    var bytes = new byte[10];
    int offset = 0;
    int count = 10;

    using (var fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        var bytesLeitura = new byte[fs.Length];
        fs.Read(bytesLeitura, offset, (int)fs.Length);
        var txt = Encoding.UTF8.GetString(bytes);
        Console.WriteLine(txt);
    }

    using (var leitor = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        var bytesLidos = new byte[leitor.Length];
        var x = leitor.Read(bytesLidos, offset, (int)leitor.Length);
        var txt = Encoding.UTF8.GetString(bytesLidos);
        Console.WriteLine(txt);
    }
}

void Executar2()
{
    var msg = "Hello world!";
    var bytes = Encoding.UTF8.GetBytes(msg);
    var offset = 0;
    var count = msg.Length;

    // escreve num arq txt a msg
    using (var  fluxoSaida = new FileStream("AruivoSaida.txt", FileMode.Create, FileAccess.ReadWrite))
    {
        fluxoSaida.Write(bytes, offset, count);
    }

    // lê a msg dentro do arquivo txt > converte pra utf8 > exibe no console
    using (var fluxoEntrada = new FileStream("AruivoSaida.txt", FileMode.Open, FileAccess.Read))
    {
        var bytesLeitura = new byte[fluxoEntrada.Length];

        fluxoEntrada.Read(bytesLeitura, offset, (int)fluxoEntrada.Length);
        string txt = Encoding.UTF8.GetString(bytesLeitura);
        Console.WriteLine(txt);
    } 
}

void Executar3()
{
    var fs = new FileStream("AruivoSaida.txt", FileMode.Open);

    var buffer = new byte[1024];
    var encoding = Encoding.ASCII;

    var bytesLidos = fs.Read(buffer, 0, 1024);
    var conteudoArquivo = encoding.GetString(buffer, 0, bytesLidos);

    Console.Write(conteudoArquivo);
}

void Executar4()
{
    using (var writer = new StreamWriter("ArquivosEscritos.txt"))
    {
        writer.Write("Arquivo escrito com StreamWriter com sucesso!");
    }
    using (var reader = new StreamReader("ArquivosEscritos.txt"))
    {
        var txt  = reader.ReadToEnd();
        Console.WriteLine(txt);

    }
}