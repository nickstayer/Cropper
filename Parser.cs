namespace Cropper;

public class Parser
{
    private List<string> _contentList { get; set; }
    private HashSet<int> _trueIndexes { get; set; }
    private string _mainDepartment { get; set; }
    private int _subDepartmentsCount { get; set; }
    private string[] _patterns { get; set; }

    public Parser(string file, string mainDepartment, int subDepartmentsCount, string[] patterns)
    {
        _mainDepartment = mainDepartment;
        _subDepartmentsCount = subDepartmentsCount;
        _patterns = patterns;
        var contentString = File.ReadAllText(file);
        _contentList = GetList(contentString);
        var uvdIndexes = GetUvdIndexes(_mainDepartment);
        _trueIndexes = new();
        foreach (var uvdIndex in uvdIndexes)
        {
            GetTrueIndexes(uvdIndex, _subDepartmentsCount);
        }
    }

    public string Parse()
    {
        var parsedList = _contentList
            .Where(row => Conditions(row, _patterns))
            .ToList();
        var result = string
            .Join("\r\n", parsedList)
            .Replace("", "")
            .Replace("", "");
        return result;
    }

    private bool Conditions(string row, string[] patterns)
    {
        if(HasTrueIndex(RowIndex(row)))
        {
            return true;
        }
        return HasTargetPattern(row, patterns);
    }

    private bool HasTargetPattern(string row, string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            if (Regex.IsMatch(row, pattern))
            {
                return true;
            }
        }
        return false;
    }

    private bool HasTrueIndex(int index)
    {
        return _trueIndexes.Contains(index);
    }

    private void GetTrueIndexes(int firstTrueIndex, int nextRowsCount)
    {
        for (var i = 0; i < nextRowsCount + 1; i++)
        {
            _trueIndexes.Add(firstTrueIndex);
            firstTrueIndex++;
        }
    }

    private int RowIndex(string row)
    {
        int index = _contentList.IndexOf(row);
        if(index == -1)
        {
            throw new IndexOutOfRangeException();
        }
        return index;
    }

    private List<int> GetUvdIndexes(string start)
    {
        var result = new List<int>();
        for(var i = 0; i < _contentList.Count; i++)
        {
            if (_contentList[i].StartsWith(start))
            {
                result.Add(i);
            }
        }
        return result;
    }

    private static List<string> GetList(string contentString)
    {
        var result = Regex.Split(contentString, @"[\r\n]")
            .Where(str => !String.IsNullOrEmpty(str))
            .ToList();
        return result;
    }
}
