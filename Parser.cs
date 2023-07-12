namespace Cropper;

public class Parser
{
    private string[] _content { get; set; }

    public Parser(string file)
    {
        _content = File.ReadAllLines(file, Encoding.Default);
    }

    private bool IsTableBorder(string row)
    {
        var result = Regex.IsMatch(row, @"^\W+(-)+");
        return result;
    }

    public string Parse()
    {
        //var parsedList = _content
        //    .Where(pair => Conditions(pair, patterns))
        //    .Select(pair => pair.Value)
        //    .ToList();
        //var result = string
        //    .Join("\r\n", parsedList)
        //    .Replace("", "")
        //    .Replace("", "");
        //return result;
        return string.Empty;
    }
}
