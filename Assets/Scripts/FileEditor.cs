using System.IO;

public class FileEditor
{
    public void WriteString(string path, string text)
    {
        File.WriteAllText(path, text);
    }

    public string ReadString(string path)
    {
        string text;
        //Read the text from directly from the test.txt file
        StreamReader reader = new StreamReader(path);
        text = reader.ReadToEnd();
        reader.Close();
        return text;
    }

}