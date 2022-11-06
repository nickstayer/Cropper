namespace Cropper;

public partial class Form1 : Form
{
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

    private void ButtonSave_Click(object sender, EventArgs e)
    {
        var mainDep = ParseMainDep(textBoxMainDepartment.Text);
        var subDepsCount = ParseSubDepsCount(textBoxSubDepartmentsCount.Text);
        var comboboxItems = GetComboboxItemsFromSampleFile(textBoxFileSample.Text);
        if (_settings == null)
        {
            _settings = new Settings(mainDep, subDepsCount, comboboxItems);
        }
        else
        {
            _settings.MainDepartment = mainDep;
            _settings.SubDepartmentsCount = subDepsCount;
            _settings.ComboBoxItems = comboboxItems;
        }
        _settings.WriteSettings();
    }

    private static string[] GetComboboxItemsFromSampleFile(string text)
    {
        return Consts.ComboBoxItems;
    }

    private static int ParseSubDepsCount(string text)
    {
        _ = int.TryParse(text, out int depsCount);
        return depsCount;
    }

    private string ParseMainDep(string text)
    {
        if(!Regex.IsMatch(text, @"^(:\w)"))
        {
            throw new Exception($"{labelMainDepartment.Text}: {Consts.WRONG_STING_FORMAT}");
        }
        return text;
    }
}