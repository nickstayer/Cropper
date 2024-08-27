namespace Cropper;

public enum Rule
{
    always,
    ifUp,
    ifDown
}

public class DataManager
{
    private string[] _content;

    private string[] _departments;
    private bool _hasTableOpened = false;
    private bool _hasSetOpened = false;
    private int _setCount = 0;

    public DataManager(string file, string[] departments, Encoding encoding)
    {
        _content = File.ReadAllLines(file, encoding);
        _departments = departments;
    }

    public string Filter()
    {
        var list = new List<string>();
        foreach (var row in _content)
        {
            if (row.StartsWith(Consts.FIRST_TABLE_BODY_ROW))
            {
                OpenTableBody();
            }

            if (!_hasTableOpened)
            {
                list.Add(row);
                continue;
            }

            if (row.StartsWith(Consts.LAST_TABLE_BODY_ROW))
            {
                CloseTableBody();
            }

            if (row.StartsWith(_departments[0]))
            {
                OpenSet();
                _setCount++;
                list.Add(row);
                continue;
            }
            if (_hasSetOpened)
            {
                if (_setCount == _departments.Length)
                {
                    _setCount = 0;
                    CloseSet();
                    continue;
                }
                foreach (var dep in _departments)
                {
                    if (row.StartsWith(dep))
                    {
                        _setCount++;
                        list.Add(row);
                        break;
                    }
                }
            }
            continue;
        }

        var result = EnumarableToString(list);
        return result;
    }

    public static string EnumarableToString(IEnumerable<string> list)
    {
        var result = string
            .Join("\r\n", list)
            .Replace("", "")
            .Replace("", "");
        return result;
    }

    // public static void SaveToWordWithFormatting(string docxFilePath, string content)
    // {
    //     var word = new WordApp();
    //     word.CreateDoc();
    //     word.AddContentToBegin(content);
    //     word.FormattDoc();
    //     word.SaveDocAs(docxFilePath);
    //     word.CloseDoc();
    //     word.Quit();
    // }

    public static void SaveToWordWithFormatting(string docxFilePath, string content)
    {
        Word.SaveToWordWithFormatting(docxFilePath, content);
    }

    public static void HighLightParagraphsWithText(string wordFile, IEnumerable<string> lines)
    {
        var word = new WordApp();
        word.OpenDoc(wordFile);
        foreach (var line in lines)
        {
            word.HighLightRowsWithText(line);
        }
        word.SaveDoc();
        word.Quit();
    }

    public static string[] GetSettings(string file)
    {
        return File.ReadAllLines(file, Encoding.Default);
    }

    public static HashSet<string> GetFormsToHighlight(string formsTohighlightFile)
    {
        return File.ReadAllLines(formsTohighlightFile, Encoding.Default).ToHashSet();
    }

    public static Dictionary<string, string> GetHighlightRules(string rulesFile)
    {
        var lines = File.ReadAllLines(rulesFile, Encoding.Default);
        var result = lines
            .Select(str => str.Split(';'))
            .Where(parts => parts.Length > 1)
            .GroupBy(parts => parts[0])
            .ToDictionary(group => group.Key, group => group.First()[1]);
        return result;
    }

    public static Encoding GetEncoding(string encoding)
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        if (encoding == Consts.ENCODING_1251)
            return Encoding.GetEncoding(Consts.ENCODING_1251);
        else return Encoding.Default;
    }

    public static List<string> GetHighLightLines(string[] lines, Dictionary<string, string> highlightRules)
    {
        var highlightLines = new List<string>();
        foreach (var line in lines)
        {
            foreach (var pair in highlightRules)
            {
                if (line.StartsWith(pair.Key))
                {
                    var columns = line.Split(":");
                    if (columns.Length > 6)
                    {
                        if(WhatRule(pair.Value) == Rule.always || WhatRule(columns[6]) == WhatRule(pair.Value))
                        {
                            if (!highlightLines.Contains(line))
                            {
                                highlightLines.Add(line);
                                break;
                            }
                        }
                    }
                }
            }
        }
        return highlightLines;
    }

    public static Rule WhatRule(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
            return Rule.always;
        else if (str.Contains("+"))
            return Rule.ifUp;
        else if (str.Contains("-"))
            return Rule.ifDown;
        return Rule.ifUp;
    }

    private void OpenSet() { _hasSetOpened = true; }
    private void CloseSet() { _hasSetOpened = false; }
    private void OpenTableBody() { _hasTableOpened = true; }
    private void CloseTableBody() { _hasTableOpened = false; }
}
