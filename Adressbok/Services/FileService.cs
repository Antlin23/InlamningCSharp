using Adressbok.Interfaces;
using Adressbok.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Adressbok.Services;

internal class FileService
{

    private string FilePath = @$"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\content.json";

    //save to file
    public void Save(string content)
    {
        using var sw = new StreamWriter(FilePath);
        sw.WriteLine(content);
    }

    //read file
    public string Read()
    {
        try
        {
            using var sr = new StreamReader(FilePath);
            return sr.ReadToEnd();
        }
        catch { return null!; }
    }
}
