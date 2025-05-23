```cs
public class IOHandler
{
    public string ReadFileContent(string? filePath)
    {
        if (!File.Exists(filePath))
        {
            throw new FileLoadException($"Could not load the {filePath}, are you sure this file exists?");
        }
        return File.ReadAllText(filePath);
    }

    public void AppendFileContent(string? filePath, string content)
    {
        if (File.Exists(filePath) == false)
        {
            throw new FileLoadException($"Could not load the {filePath}, are you sure this file exists?");
        }
        File.AppendAllText(filePath, content);
    }
}
```
