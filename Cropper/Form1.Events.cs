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
                var wordFilePath = fileInfo.FullName.Replace(".txt", ".docx").Replace(".TXT", ".docx");
                var encoding = GetEncoding();
                if (_formsToHighlight!.Contains(fileInfo.Name))
                {
                    var lines = File.ReadAllLines(fileInfo.FullName, encoding);
                    var highlightLines = DataManager.GetHighLightLines(lines, _highlightRules!);
                    var content = DataManager.EnumarableToString(lines);
                    DataManager.SaveToWordWithFormatting(wordFilePath, content);
                    DataManager.HighLightParagraphsWithText(wordFilePath, highlightLines);
                }

                else
                {
                    var filter = new DataManager(fileInfo.FullName, _departments!, encoding);
                    var filtredContent = filter.Filter();
                    DataManager.SaveToWordWithFormatting(wordFilePath, filtredContent);
                    if (cbDepartments.Text != Consts.HIGHLIGHT)
                    {
                        var text = cbDepartments.SelectedItem.ToString();
                        DataManager.HighLightParagraphsWithText(wordFilePath, new string[] { text! });
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

    private Encoding GetEncoding()
    {
        return DataManager.GetEncoding(cbEncodings.Text);
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
