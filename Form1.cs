namespace Cropper;

public partial class Form1 : Form
{
    private string[] _departments;
    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            SetDefaultText();
            GetSettings();
            FillForm();
        }
        catch (Exception ex)
        {
            textBoxDropable.Text = ex.Message;
        }
    }

    private void SetDefaultText()
    {
        labelStatus.Text = string.Empty;
        comboBoxDeps.Text = Consts.HIGHLIGHT;
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }

    private void GetSettings()
    {
        if(File.Exists(Consts.SETTINGS_FILE))
        {
            _departments = File.ReadAllLines(Consts.SETTINGS_FILE, Encoding.Default);
        }
        else
        {
            textBoxDropable.Enabled = false;
            throw new Exception($"{Consts.NO_SETTINGS_FILE}: {Consts.SETTINGS_FILE}");
        }
    }

    private void FillForm()
    {
        comboBoxDeps.Items.Clear();
        foreach (var dep in _departments)
        {
            comboBoxDeps.Items.Add(dep.Trim());
        }
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
        if (comboBoxDeps.Text != Consts.HIGHLIGHT)
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

    private void OutputTextboxDropable(string message)
    {
        textBoxDropable.Text += message + "\r\n";
    }
}