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
                var parser = new Parser(fileInfo.FullName);
                var content = parser.Parse();
                SaveToWord(fileInfo, content);
            }
            OutputTextboxDropable(Consts.DROP_FILES_HERE);
            labelStatus.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            OutputTextboxDropable(ex.Message);
        }
    }

    private void textBoxDropable_DragLeave(object sender, EventArgs e)
    {
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }
    #endregion
}
