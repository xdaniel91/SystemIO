using System.Collections.Concurrent;
using System.IO;
using System.IO.Compression;
using System.Text;

DirectoryCurso();
Console.WriteLine();
EscreverContas();
Console.WriteLine();
CriarConta();
Console.WriteLine();
Drivers();
Console.WriteLine();
InfosArquivos();

string path = "C:\\Users\\DanielRodriguesCarva\\source\\repos\\Csharp parte8\\Csharp parte8\\Diretores.txt";

void Executar()
{
    using (var fs = new FileStream("Texto.zip", FileMode.OpenOrCreate, FileAccess.ReadWrite))
    {
        using (var compactador = new GZipStream(fs, CompressionMode.Compress))
        {
            using (var sw = new StreamWriter(fs))
            {
                sw.Write("Hello world! escrito.");
            }
        }
    }

    using (var fs = new FileStream("Texto.zip", FileMode.Open, FileAccess.Read))
    {
        using (var descompactador = new GZipStream(fs, CompressionMode.Decompress))
        {
            using (var reader = new StreamReader("Texto.zip"))
            {
                var result = reader.ReadToEnd();
                Console.WriteLine("eu li: " + result);
            }
        }
    }

    var fila = new ConcurrentQueue<string>();
    fila.Enqueue("azul");
    fila.Enqueue("vermelho");
    fila.Enqueue("roxo");
    fila.Enqueue("amarelo");
    fila.Enqueue("rosa");

}

static void TestaEscrita()
{
    var caminhoArquivo = "teste.txt";

    using (var fluxoDeArquivo = new FileStream(caminhoArquivo, FileMode.Create))
    using (var escritor = new StreamWriter(fluxoDeArquivo))
    {
        for (int i = 0; i < 100000000; i++)
        {
            escritor.WriteLine($"Linha {i}");
            escritor.Flush();
            Console.WriteLine($"Linha {i} foi escrita no arquivo. Tecle enter p adicionar mais uma!");
            var input = Console.Read();
        }
    }
}

void CriarConta()
{
    using (var sr = new FileStream("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt", FileMode.Open, FileAccess.Read))
    {

        var contas = File.ReadAllLines("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt");
        foreach (var item in contas)
        {

            var linha = item;

            var campos = linha.Split(' ');
            var agencia = Convert.ToInt32(campos[0]);
            var conta = Convert.ToInt32(campos[1]);
            var nome = campos[2].ToString();
            new ContaCorrente(agencia, conta, nome);
        }
    }
}

void EscreverContas()
{
    using (var sw = new StreamWriter("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt"))
    {
        string conta1 = "1234 546978 roberto";
        string conta2 = "9874 369258 jose";
        string conta3 = "7894 321477 aloisio";
        string conta4 = "1237 741255 pedro";
        string conta5 = "3579 744144 dalva";
        var rei = new string[] { conta1, conta2, conta3, conta4, conta5 };
        foreach (var item in rei)
        {
            sw.WriteLine(item);
        }
    }
}

void Drivers()
{
    var drives = DriveInfo.GetDrives();
    foreach (var drive in drives)
    {
        Console.WriteLine(drive.Name);
        Console.WriteLine(drive.DriveFormat);
        double freespace = drive.TotalFreeSpace;
        Console.WriteLine($"{freespace / 1024 / 1024 / 1024:N2} gb freespace");
        Console.WriteLine(drive.DriveType + "\n");
    }
}

void InfosArquivos()
{
    File.WriteAllText("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt", "macaco");
    File.AppendAllText("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt", "macacão grande");
    var info = new FileInfo("C:\\Users\\DanielRodriguesCarva\\Desktop\\contasespaço.txt");
    Console.WriteLine("full name "+ info.FullName);
    Console.WriteLine($"directory {info.Directory}");
    Console.WriteLine($"created at {info.CreationTime}");
    Console.WriteLine($"exists? {info.Exists}");
    Console.WriteLine($"length in bytes {info.Length}");
}

void DirectoryCurso()
{
    Directory.CreateDirectory("novoDiretorio"); // cria uma pasta
    Console.WriteLine("existte? " + Directory.Exists("novoDiretorio"));
    Directory.Delete("novoDiretorio");
}

public class ContaCorrente
{
    public ContaCorrente(int agencia, int conta, string nome)
    {
        Console.WriteLine($"conta criada :) ag: {agencia} | cc: {conta} | titular: {nome}");
    }
}
