namespace Cropper;

public partial class Form1 : Form
{
    private Settings _settings;

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            UpdateEncodings();
            SetDefaultText();
            GetSettings();
            FillFormFromSettings();
        }
        catch (Exception ex)
        {
            textBoxDropable.Text = ex.Message;
        }
    }

    private void UpdateEncodings()
    {
        comboBoxFileEncoding.Items.Add("windows-1251");
        comboBoxFileEncoding.Items.Add("utf-8");
    }

    private void SetDefaultText()
    {
        labelStatus.Text = "";
        textBoxFileSample.Text = Consts.DROP_SAMPLE_HERE;
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }

    private void GetSettings()
    {
        Settings.CheckSettingsFile();
        _settings = new Settings();
        _settings.ReadSettings();
        _settings.CheckSettings();
    }

    private void FillFormFromSettings()
    {
        comboBoxDeps.Items.Clear();
        foreach (var item in _settings.DepartmentsNames)
        {
            comboBoxDeps.Items.Add(item);
        }
        textBoxMainDepartment.Text = _settings.MainDepartmentName;
        textBoxSubDepartmentsCount.Text = _settings.SubDepartmentsCount.ToString();
        comboBoxFileEncoding.Text = _settings.DefaultFileEncoding;
    }

    private void SaveToWord(FileInfo fileInfo, string content)
    {
        var file = fileInfo.FullName.Replace("txt", "docx");
        var app = new WordApp();
        app.CreateDoc();
        app.AddContent(content);
        app.FormattDoc();
        HighlightSelectedItemInDocument(app);
        app.SaveDocAs(file);
        app.CloseDoc();
        app.Quit();
    }

    private void HighlightSelectedItemInDocument(WordApp app)
    {
        if (comboBoxDeps.SelectedItem != null)
        {
            app.HighLightRowsWithText(comboBoxDeps.SelectedItem.ToString());
        }
    }

    private static List<FileInfo> GetFilesInfo(DragEventArgs e)
    {
        if (e.Data == null)
        {
            throw new NullReferenceException();
        }
        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
        List<FileInfo> result = new List<FileInfo>();
        foreach (var file in files)
        {
            var fileInfo = new FileInfo(file);
            if (fileInfo.Extension != Consts.INPUT_FILE_EXTENTION)
            {
                throw new FileFormatException(Consts.WRONG_EXTENTION);
            }
            result.Add(fileInfo);
        }
        return result;
    }

    private void SetSettings()
    {
        var settings = ParseSettings();
        if (_settings == null)
        {
            _settings = new Settings(settings.Item1, settings.Item2, settings.Item3, settings.Item4);
        }
        else
        {
            _settings.MainDepartmentName = settings.Item1;
            _settings.SubDepartmentsCount = settings.Item2;
            _settings.DepartmentsNames = settings.Item3;
            _settings.DefaultFileEncoding = settings.Item4;
        }
        _settings.WriteSettings();
    }

    (string, int, IEnumerable<string>, string) ParseSettings()
    {
        var parser = new Parser(textBoxFileSample.Text);
        var mainDep = ParseMainDep(parser, textBoxMainDepartment.Text);
        var subDepsCount = ParseSubDepsCount(textBoxSubDepartmentsCount.Text);
        var comboboxItems = ParseDeparments(parser, textBoxFileSample.Text, mainDep.Value, subDepsCount);
        var defaultEncoding = ParseEncoding(comboBoxFileEncoding.Text);
        return (mainDep.Value, subDepsCount, comboboxItems, defaultEncoding);
    }

    private string ParseEncoding(string text)
    {
        
        if (string.IsNullOrEmpty(text))
        {
            return comboBoxFileEncoding.Items[0].ToString();
        }
        return text;
    }

    private IEnumerable<string> ParseDeparments(Parser parser, string sampleFile, string mainDep, int subDepsCount)
    {
        if(sampleFile == null)
        {
            throw new Exception($"{labelFileSample.Text}: {Consts.NO_SAMPLE_FILE}");
        }
        var result = parser.ParseDepartments(mainDep, subDepsCount);
        return result;
    }

    private static int ParseSubDepsCount(string text)
    {
        _ = int.TryParse(text, out int depsCount);
        return depsCount;
    }

    private KeyValuePair<int,string> ParseMainDep(Parser parser, string text)
    {
        var result = parser.ParseMainDepartment(text);
        return result;
    }

    private void OutputTextboxDropable(string message)
    {
        textBoxDropable.Text += message + "\r\n";
    }
}