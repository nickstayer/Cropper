namespace Cropper;

public class Parser
{
    private string[] _content;

    private string[] _departments;
    private bool _hasTableOpened = false;
    private bool _hasSetOpened = false;
    private int _setCount = 0;

    public Parser(string file, string[] departments, Encoding encoding)
    {
        _content = File.ReadAllLines(file, encoding);
        _departments = departments;
    }

    public string Parse()
    {
        var list = new List<string>();
        foreach(var row in _content) 
        {
            if (row.StartsWith(Consts.FIRST_TABLE_BODY_ROW))
            {
                OpenTableBody();
            }

            if(!_hasTableOpened)
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
                if(_setCount==_departments.Length)
                {
                    _setCount= 0;
                    CloseSet();
                    continue;
                }
                foreach(var dep in _departments)
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

        var result = string
            .Join("\r\n", list)
            .Replace("", "")
            .Replace("", "");
        return result;
    }

    private void OpenSet() { _hasSetOpened = true; }
    private void CloseSet() { _hasSetOpened = false; }
    private void OpenTableBody() { _hasTableOpened = true; }
    private void CloseTableBody() { _hasTableOpened = false; }
}
