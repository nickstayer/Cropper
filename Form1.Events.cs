namespace Cropper;

public partial class Form1
{

    public Form1()
    {
        InitializeComponent();
    }

    #region textBoxDropable
    private void textBoxDropable_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data == null)
        {
            throw new NullReferenceException();
        }
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            e.Effect = DragDropEffects.All;
    }

    private void textBoxDropable_DragOver(object sender, DragEventArgs e)
    {
        textBoxDropable.Clear();
    }

    private void textBoxDropable_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            var inputFiles = GetFilesInfo(e);
            foreach (var fileInfo in inputFiles)
            {
                labelStatus.Text = fileInfo.Name;
                var docxFilePath = fileInfo.FullName.Replace(".txt", ".docx").Replace(".TXT", ".docx");
                var encoding = GetEncoding();
                if (_highlightList.Contains(fileInfo.Name))
                {
                    // TODO:
                    var content = DataManager.EnumarableToString(File.ReadAllLines(fileInfo.FullName, encoding));
                    SaveToWordWithFormatting(docxFilePath, content);
                }

                else
                {
                    var filter = new DataManager(fileInfo.FullName, _departments, encoding);
                    var filtredContent = filter.Filter();
                    SaveToWordWithFormatting(docxFilePath, filtredContent);
                    if (cbDepartments.Text != Consts.HIGHLIGHT)
                    {
                        var text = cbDepartments.SelectedItem.ToString();
                        HighLightParagraphsWithText(docxFilePath, new string[] { text! });
                    }

                }
            }
            OutputTextboxDropable(Consts.DROP_FILES_HERE);
            labelStatus.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            OutputTextboxDropable(ex.Message);
        }
    }

    private void SaveToWordWithFormatting(string docxFilePath, string content)
    {
        var word = new WordApp();
        word.CreateDoc();
        word.AddContentToBegin(content);
        word.FormattDoc();
        word.SaveDocAs(docxFilePath);
        word.CloseDoc();
        word.Quit();
    }

    private void HighLightParagraphsWithText(string wordFile, string[] lines)
    {
        var word = new WordApp();
        word.OpenDoc(wordFile);
        foreach (var line in lines)
        {
            word.HighLightRowsWithText(line);
        }
        word.SaveDoc();
        word.Quit();
    }

    private HashSet<string> GetHighLightList()
    {
        return File.ReadAllLines(Consts.HIGHLIGHT_LIST_FILE, GetEncoding()).ToHashSet();
    }

    private Dictionary<string, string> GetHighLightRules()
    {
        // TODO:
        return new Dictionary<string, string>();
    }

    private Encoding GetEncoding()
    {
        Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        if (cbEncodings.Text == Consts.ENCODING_1251)
            return Encoding.GetEncoding(Consts.ENCODING_1251);
        else return Encoding.Default;
    }

    private void textBoxDropable_DragLeave(object sender, EventArgs e)
    {
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }
    #endregion

    private void cbEncodings_SelectedIndexChanged(object sender, EventArgs e)
    {
        Properties.Settings.Default.Encoding = cbEncodings.Text;
        Properties.Settings.Default.Save();
    }
}
