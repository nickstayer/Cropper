namespace Cropper;

public partial class Form1 : Form
{
    private string[]? _departments;
    private string[]? _encodings;
    private HashSet<string>? _formsToHighlight;
    private Dictionary<string, string>? _highlightRules;

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            SetDefaultText();
            _departments = DataManager.GetSettings(Consts.SETTINGS_FILE);
            _encodings = DataManager.GetSettings(Consts.ENCODING_FILE);
            _formsToHighlight = DataManager.GetFormsToHighlight(Consts.FORMS_TO_HIGHLIGHT_FILE);
            _highlightRules = DataManager.GetHighlightRules(Consts.HIGHLIGHT_RULES_FILE);
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

    private void FillForm()
    {
        cbDepartments.Items.Clear();
        foreach (var dep in _departments!)
        {
            cbDepartments.Items.Add(dep.Trim());
        }
        cbEncodings.Items.Clear();
        foreach (var dep in _encodings!)
        {
            cbEncodings.Items.Add(dep.Trim());
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
            if (fileInfo.Extension.ToLower() != Consts.INPUT_FILE_EXTENTION)
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