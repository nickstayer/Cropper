namespace Cropper;

public class Parser
{
    private List<string> _contentList { get; set; }
    private HashSet<int> _trueIndexes { get; set; }
    private string _mainDepartment { get; set; }
    private int _subDepartmentsCount { get; set; }
    private string[] _patterns { get; set; }

    public Parser(string file, Settings settings, string[] patterns)
    {
        _mainDepartment = settings.MainDepartment;
        _subDepartmentsCount = settings.SubDepartmentsCount;
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

    public Parser(string file)
    {
        var contentString = File.ReadAllText(file);
        _contentList = GetList(contentString);
    }

    public List<string> ParseDepartments(string mainDepartment, int subDepartmentsCount)
    {
        var uvdIndex = GetUvdIndexes(mainDepartment).First();
        _trueIndexes = new();
        GetTrueIndexes(uvdIndex, subDepartmentsCount);
        var lines = new List<string>();
        for(var i = 0; i < _contentList.Count; i++)
        {
            if (_trueIndexes.Contains(i))
            {
                lines.Add(_contentList[i]);
            }
        }
        var result = ParseDepartmentsNames(lines);
        return result;
    }

    public string ParseMainDepartment(string input)
    {
        var line = _contentList.Find(x => x.ToLower().Contains(input.ToLower())) ?? throw new Exception(input);
        var result = ":"+ ParseDepartmentName(line);
        return result;
    }

    public List<string> ParseDepartmentsNames(List<string> lines)
    {
        return lines
            .Select(line => ParseDepartmentName(line))
            .ToList();
    }

    public string ParseDepartmentName(string line)
    {
        var result = line.Split(':')[1].Trim();
        return result;
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
            throw new Exception();
        }
        return index;
    }

    private List<int> GetUvdIndexes(string mainDep)
    {
        var result = new List<int>();
        for(var i = 0; i < _contentList.Count; i++)
        {
            if (_contentList[i].StartsWith(mainDep))
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
