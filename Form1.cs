namespace Cropper;

public partial class Form1 : Form
{
    private string[] _departments;
    private string[] _encodings;
    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            SetDefaultText();
            _departments = GetSettings(Consts.SETTINGS_FILE);
            _encodings = GetSettings(Consts.ENCODING_FILE);
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
        cbDepartments.Text = Consts.HIGHLIGHT;
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
        cbEncodings.Text = Properties.Settings.Default.Encoding;
    }

    private string[] GetSettings(string file)
    {
        if(File.Exists(file))
        {
            return File.ReadAllLines(file, Encoding.Default);
        }
        else
        {
            textBoxDropable.Enabled = false;
            throw new Exception($"{Consts.NO_SETTINGS_FILE}: {file}");
        }
    }

    private void FillForm()
    {
        cbDepartments.Items.Clear();
        foreach (var dep in _departments)
        {
            cbDepartments.Items.Add(dep.Trim());
        }
        cbEncodings.Items.Clear();
        foreach (var dep in _encodings)
        {
            cbEncodings.Items.Add(dep.Trim());
        }
    }

    private void SaveToWord(FileInfo fileInfo, string content)
    {
        var file = fileInfo.FullName.Replace("txt", "docx");
        var app = new WordApp();
        app.CreateDoc();
        app.AddContentToBegin(content);
        app.FormattDoc();
        HighlightSelectedItemInDocument(app);
        app.SaveDocAs(file);
        app.CloseDoc();
        app.Quit();
    }

    private void HighlightSelectedItemInDocument(WordApp app)
    {
        if (cbDepartments.Text != Consts.HIGHLIGHT)
        {
            app.HighLightRowsWithText(cbDepartments.SelectedItem.ToString());
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