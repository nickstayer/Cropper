using static System.Windows.Forms.LinkLabel;
using System.Diagnostics.Metrics;
using System.Security.Policy;

namespace Cropper;

public partial class Form1 : Form
{
    private string[]? _departments;
    private string[]? _encodings;
    private Dictionary<string, string>? _highlightRules;

    public Form1()
    {
        InitializeComponent();
    }

    private void Form1_Load(object sender, EventArgs e)
    {
        try
        {
            SetDefaultText();
            _departments = DataManager.GetSettings(Consts.FILTER_FILE);
            _encodings = DataManager.GetSettings(Consts.ENCODING_FILE);
            _highlightRules = DataManager.GetHighlightRules(Consts.MARKER_RULES_FILE);
            FillForm();
        }
        catch (Exception ex)
        {
            textBoxDropableFilter.Text = ex.Message;
        }
    }

    private void SetDefaultText()
    {
        labelStatus.Text = string.Empty;
        cbDepartments.Text = Consts.MARK;
        textBoxDropableFilter.Text = Consts.DROP_FILES_HERE;
        textBoxDropableMarker.Text = Consts.DROP_FILES_HERE;
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

    private void ShowMessage(string message)
    {
        textBoxDropableFilter.Text += message + "\r\n";
        textBoxDropableMarker.Text += message + "\r\n";
    }

    private Encoding GetEncoding()
    {
        return DataManager.GetEncoding(cbEncodings.Text);
    }

    private void CbEncodings_SelectedIndexChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.Encoding = cbEncodings.Text;
        Properties.Settings.Default.Save();
    }

    private async Task DownloadForms(object sender, EventArgs e)
    {
        var downloadsDir = Path.Combine(Directory.GetCurrentDirectory(), "forms");
        if(!Directory.Exists(downloadsDir)) { Directory.CreateDirectory(downloadsDir); }
        try
        {
            string url = File.ReadAllText(Consts.URL_FILE).Trim();
            var needFormsNames = File.ReadAllLines(Consts.FORMS_TO_DOWNLOAD_FILE)
                                     .Where(line => !string.IsNullOrWhiteSpace(line))
                                     .Select(line => line.Trim())
                                     .ToList();

            string baseUrl = GetBaseUrl(url);
            var fileLinks = await WebManager.GetLinks(url);

            int counter = 0;

            foreach (var link in fileLinks)
            {
                string fullUrl = link.StartsWith("http") ? link : baseUrl + link;

                if (needFormsNames.Contains(Path.GetFileName(fullUrl)))
                {
                    var fileName = Path.GetFileName(fullUrl);
                    var savePath = Path.Combine(downloadsDir, fileName);
                    await WebManager.DownloadTextFile(fullUrl, savePath);
                    counter++;
                }
            }

            labelStatus.Text = $"Скачано форм: {counter}";
        }
        catch (Exception ex)
        {
            labelStatus.Text = ex.Message;
        }
    }

    public string GetBaseUrl(string url)
    {
        var urlComponents = url.Split('/');
        string baseUrl = urlComponents[0] + "//" + urlComponents[2];
        return baseUrl;
    }

}