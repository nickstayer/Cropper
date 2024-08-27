namespace Cropper;

public partial class Form1
{
    #region textBoxDropableFilter
    private void TextBoxDropable_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data == null)
        {
            throw new NullReferenceException();
        }
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            e.Effect = DragDropEffects.All;
    }

    private void TextBoxDropable_DragOver(object sender, DragEventArgs e)
    {
        textBoxDropableFilter.Clear();
        textBoxDropableMarker.Clear();
    }

    private void TextBoxDropableFilter_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            var inputFiles = GetFilesInfo(e);
            foreach (var fileInfo in inputFiles)
            {
                labelStatus.Text = fileInfo.Name;
                var wordFilePath = fileInfo.FullName.Replace(".txt", ".docx").Replace(".TXT", ".docx");
                var encoding = GetEncoding();
                var filter = new DataManager(fileInfo.FullName, _departments!, encoding);
                var filtredContent = filter.Filter();
                DataManager.SaveToWordWithFormatting(wordFilePath, filtredContent);
                if (cbDepartments.Text != Consts.MARK)
                {
                    var text = cbDepartments.SelectedItem!.ToString();
                    DataManager.HighLightParagraphsWithText(wordFilePath, new string[] { text! });
                }
            }
            ShowMessage(Consts.DROP_FILES_HERE);
            labelStatus.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void TextBoxDropableMarker_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            var inputFiles = GetFilesInfo(e);
            foreach (var fileInfo in inputFiles)
            {
                labelStatus.Text = fileInfo.Name;
                var wordFilePath = fileInfo.FullName.Replace(".txt", ".docx").Replace(".TXT", ".docx");
                var encoding = GetEncoding();
                var lines = File.ReadAllLines(fileInfo.FullName, encoding);
                var highlightLines = DataManager.GetHighLightLines(lines, _highlightRules!);
                var content = DataManager.EnumarableToString(lines);
                DataManager.SaveToWordWithFormatting(wordFilePath, content);
                DataManager.HighLightParagraphsWithText(wordFilePath, highlightLines);
            }
            ShowMessage(Consts.DROP_FILES_HERE);
            labelStatus.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            ShowMessage(ex.Message);
        }
    }

    private void TextBoxDropable_DragLeave(object sender, EventArgs e)
    {
        textBoxDropableFilter.Text = Consts.DROP_FILES_HERE;
        textBoxDropableMarker.Text = Consts.DROP_FILES_HERE;
    }
    #endregion
}
