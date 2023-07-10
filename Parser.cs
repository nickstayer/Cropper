namespace Cropper;

public class Parser
{
    private Dictionary<int,string> _contentList { get; set; }
    private HashSet<int> _needDepartmentIndexes { get; set; }
    private string[] _patterns { get; set; }

    public Parser(string file, Settings settings)
    {
        var mainDepartmentName = settings.MainDepartmentName;
        var subDepartmentsCount = settings.SubDepartmentsCount;
        string content = File.ReadAllText(file, Encoding.Default);
        _contentList = GetNumeratedRows(content);
        var mainDepartmentIndexes = GetMainDepartmentIndexes(mainDepartmentName);
        _needDepartmentIndexes = new();
        foreach (var uvdIndex in mainDepartmentIndexes)
        {
            GetNeedDepartmentIndexes(uvdIndex, subDepartmentsCount);
        }
    }

    private static Dictionary<int, string> GetNumeratedRows(string contentString)
    {
        var resultArr = Regex.Split(contentString, @"[\r\n]");
        var resultList = GetNotEmptyRows(resultArr);
        var resultDic = new Dictionary<int, string>();
        for (int i = 0; i < resultList.Count; i++)
        {
            resultDic.Add(i, resultList[i]);
        }
        return resultDic;
    }

    private List<int> GetMainDepartmentIndexes(string mainDep)
    {
        var result = new List<int>();
        foreach (var pair in _contentList)
        {
            if (pair.Value.StartsWith(mainDep))
            {
                result.Add(pair.Key);
            }
        }
        return result;
    }

    private void GetNeedDepartmentIndexes(int firstTrueIndex, int nextRowsCount)
    {
        for (var i = 0; i < nextRowsCount + 1; i++)
        {
            _needDepartmentIndexes.Add(firstTrueIndex);
            firstTrueIndex++;
        }
    }

    public Parser(string file)
    {
        var content = File.ReadAllText(file, Encoding.Default);
        _contentList = GetNumeratedRows(content);
    }

    public List<string> ParseDepartments(string mainDepartment, int subDepartmentsCount)
    {
        var uvdIndex = GetMainDepartmentIndexes(mainDepartment).First();
        _needDepartmentIndexes = new();
        GetNeedDepartmentIndexes(uvdIndex, subDepartmentsCount);
        var lines = new List<string>();
        for(var i = 0; i < _contentList.Count; i++)
        {
            if (_needDepartmentIndexes.Contains(i))
            {
                lines.Add(_contentList[i]);
            }
        }
        var result = ParseDepartmentsNames(lines);
        return result;
    }

    public KeyValuePair<int,string> ParseMainDepartment(string input)
    {
        var result = _contentList.Where(x => x.Value.ToLower().Contains(input.ToLower())).FirstOrDefault();
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

    public string Parse(string[] patterns)
    {
        var parsedList = _contentList
            .Where(pair => Conditions(pair, patterns))
            .Select(pair => pair.Value)
            .ToList();
        var result = string
            .Join("\r\n", parsedList)
            .Replace("", "")
            .Replace("", "");
        return result;
    }

    private bool Conditions(KeyValuePair<int,string> row, string[] patterns)
    {
        if (HasTrueIndex(row.Key))
        {
            return true;
        }
        return HasTargetPattern(row, patterns);
    }

    private bool HasTargetPattern(KeyValuePair<int, string> row, string[] patterns)
    {
        foreach (var pattern in patterns)
        {
            if (Regex.IsMatch(row.Value, pattern))
            {
                return true;
            }
        }
        return false;
    }

    private bool IsTableBorderIndex(string row)
    {
        var result = Regex.IsMatch(row, @"^\W(-)+");
        return result;
    }

    private bool HasTrueIndex(int index)
    {
        return _needDepartmentIndexes.Contains(index);
    }

    private static List<string> GetNotEmptyRows(string[] resultArr)
    {
        var resultList = new List<string>();
        for (int i = 0; i < resultArr.Length; i++)
        {
            if (!string.IsNullOrEmpty(resultArr[i]))
            {
                resultList.Add(resultArr[i]);
            }
        }
        return resultList;
    }
}
