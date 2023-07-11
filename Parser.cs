namespace Cropper;

public class Parser
{
    private Dictionary<int,string> _contentList { get; set; }
    private HashSet<int> _departments { get; set; }
    private Dictionary<int, TableBorder> _borders { get; set; }

    public Parser(string file, Settings settings)
    {
        string content = File.ReadAllText(file, Encoding.Default);
        _contentList = GetNumeratedRows(content);
        _departments = new();
        _borders = new();
        GetNeedIndexes(settings.MainDepartmentName, settings.SubDepartmentsCount);//_needDepartmentIndexes,_borders 
    }

    private static Dictionary<int, string> GetNumeratedRows(string contentString)
    {
        var resultArr = Regex.Split(contentString, @"[\r\n]");
        var resultList = GetNotEmptyRows(resultArr);
        var resultDic = new Dictionary<int, string>();//List<Row>
        for (int i = 0; i < resultList.Count; i++)
        {
            resultDic.Add(i, resultList[i]);
        }
        return resultDic;
    }

    private void GetNeedIndexes(string mainDep, int subDepCount)
    {
        int counter = 0;
        subDepCount++;
        int borderCounter = 3;
        for (var i = 0; i < _contentList.Count; i++)
        {
            if (_contentList[i].StartsWith(mainDep))
            {
                _departments.Add(i);
                counter = subDepCount;
            }
            if (counter > 0 && counter < subDepCount)
            {
                _departments.Add(i);
            }
            if (IsTableBorder(_contentList[i]))
            {
                if(borderCounter == 3)
                {
                    _borders.Add(i,TableBorder.Up);
                }
                if (borderCounter == 1)
                {
                    _borders.Add(i, TableBorder.Down);
                }
                borderCounter--;
                if (borderCounter == 0)
                {
                    borderCounter = 3;
                }
            }
            counter--;
        }
    }

    private List<int> GetMainDepartmentIndexes(string mainDep)
    {
        var mainDepartments = new List<int>();
        foreach (var pair in _contentList)
        {
            if (pair.Value.StartsWith(mainDep))
            {
                mainDepartments.Add(pair.Key);
            }
        }
        return mainDepartments;
    }

    private void GetNeedDepartmentIndexes(int firstTrueIndex, int nextRowsCount)
    {
        for (var i = 0; i < nextRowsCount + 1; i++)
        {
            _departments.Add(firstTrueIndex);
            firstTrueIndex++;
        }
    }

    //parse settings
    public Parser(string file)
    {
        var content = File.ReadAllText(file, Encoding.Default);
        _contentList = GetNumeratedRows(content);
    }

    public List<string> ParseDepartments(string mainDepartment, int subDepartmentsCount)
    {
        var uvdIndex = GetMainDepartmentIndexes(mainDepartment).First();
        _departments = new();
        GetNeedDepartmentIndexes(uvdIndex, subDepartmentsCount);
        var lines = new List<string>();
        for(var i = 0; i < _contentList.Count; i++)
        {
            if (_departments.Contains(i))
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

    private Row GetRow(KeyValuePair<int, string> row)
    {
        Row r = new Row();
        r.Index = row.Key;
        r.Content = row.Value;
        //r.RowType = RowType.OutTable;
        return r;
    }

    private bool IsTableBorder(string row)
    {
        var result = Regex.IsMatch(row, @"^\W+(-)+");
        return result;
    }

    private bool HasTrueIndex(int index)
    {
        return _departments.Contains(index);
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
