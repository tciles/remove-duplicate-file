using System.Security.Cryptography;

static string GetFileHash(string path)
{
    using(FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
    {
        return BitConverter.ToString(SHA1.Create().ComputeHash(fs));
    }
}

if (args.Length < 1) 
{
    Console.WriteLine("Path argument required");

    return;
}

string path = args[0];

if (!Directory.Exists(path)) {
    Console.WriteLine("Path is not a directory");

    return;
}

string[] fileEntries = Directory.GetFiles(args[0]);
Array.Sort(fileEntries);
int len = fileEntries.Length;
int i;

Console.WriteLine($"Analyse {len} files in {path}");

for (i = 0; i < len; i++)
{
    string fileName = fileEntries[i];
    FileInfo fileInfo = new FileInfo(fileName);
    string hash = GetFileHash(fileName);

    Console.WriteLine($"{fileInfo.Name} - {fileInfo.Length} - {hash}");
}
