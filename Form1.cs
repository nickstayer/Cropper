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

    private void buttonSave_Click(object sender, EventArgs e)
    {
        if(_settings != null)
        {
            _settings.MainDepartment = ParseMainDep(textBoxMainDepartment.Text);
            _settings.SubDepartmentsCount = ParseSubDepsCount(textBoxSubDepartmentsCount.Text);
        }
    }

    private int ParseSubDepsCount(string text)
    {
        throw new NotImplementedException();
    }

    private string ParseMainDep(string text)
    {
        throw new NotImplementedException();
    }
}