

BuscandoArquivosRecursivamente(new DirectoryInfo("..\\..\\.."));


Console.WriteLine("\n\n");

/* retorna onde fica a pasta especial documents */
var documents = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
Console.WriteLine($"documents -> {documents}");

/* combina o endereço de documents com "alura.txt" */
var location = Path.Combine(documents, "alura.txt");
Console.WriteLine($"location  -> {location}");

/* retorna o nome do diretorio a partir da localização completa de "alura.txt" */
var nomeDirectory = Path.GetDirectoryName(location);
Console.WriteLine(nomeDirectory);

/* retorna somente o nome do arquivo a partir da localização completa */
var nomeArquivo = Path.GetFileName(location);
Console.WriteLine(nomeArquivo);

/* retorna a extension do arquivo */ 
var extension = Path.GetExtension(location);
Console.WriteLine($"extension -> {extension}");

/* altera a extensão do arquivo */
extension = "json";
location = Path.ChangeExtension(location, extension);
Console.WriteLine($"new extension now is : {Path.GetExtension(location)}");

/* lista todos os arquivos .cs na pasta, usando recursividade */
void ProcurandoArquivosRecusivamente(DirectoryInfo directory)
{
  
    foreach (var diretorio in directory.GetDirectories())
    {
        Console.WriteLine(diretorio.FullName);

        foreach (var files in diretorio.GetFiles("*.cs"))
        {
            Console.WriteLine(files.FullName);
        }
        ProcurandoArquivosRecusivamente(diretorio);
    }
}

void BuscandoArquivosRecursivamente(DirectoryInfo directory)
{
    foreach (var dir in directory.GetDirectories())
    {
        Console.WriteLine("diretorio: " + dir.FullName);

        foreach (var file in dir.GetFiles("*.cs"))
        {
            Console.WriteLine(file.FullName);
        }
        BuscandoArquivosRecursivamente(dir);
    }
}