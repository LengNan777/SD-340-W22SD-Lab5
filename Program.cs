using System.IO;
using System.Text.RegularExpressions;

string path = @"C:\Users\VULCAN\Desktop";

Console.WriteLine($"Current directory is '{Environment.CurrentDirectory}'");
Directory.SetCurrentDirectory(path);
Console.WriteLine($"Current directory is '{Environment.CurrentDirectory}'");

Console.WriteLine(ReplacePeriod(path)); 

string ReplacePeriod(string path)
{
    string content;
    string editedContent;

    try
    {
        using (StreamReader sr = File.OpenText($"{path}\\theMachineStops.txt"))
        {
            content = sr.ReadToEnd();
            editedContent = content.Replace(@".", "STOP");
        }

        using (StreamWriter sw = new StreamWriter("TelegramCopy.txt"))
        {
            sw.WriteLine(editedContent);
        }
        return "It works!";
    }
    catch(Exception e)
    {
        Console.WriteLine(e.Message);
    }
    return "No content in file.";
}