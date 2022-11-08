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
        textBoxDropable.Text = "";
    }

    private void textBoxDropable_DragDrop(object sender, DragEventArgs e)
    {
        try
        {
            Settings.CheckSettingsFile();
            _settings.CheckSettings();
            var inputFiles = GetFilesInfo(e);
            foreach (var fileInfo in inputFiles)
            {
                labelStatus.Text = fileInfo.Name;
                var content = new Parser(fileInfo.FullName, _settings, Consts.Patterns).Parse();
                SaveToWord(fileInfo, content);
            }
            textBoxDropable.Text = Consts.DROP_FILES_HERE;
            labelStatus.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            textBoxDropable.Text = ex.Message + "\r\n";
        }
    }

    private void textBoxDropable_DragLeave(object sender, EventArgs e)
    {
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }
    #endregion

    #region textBoxFileSample
    private void textBoxFileSample_DragEnter(object sender, DragEventArgs e)
    {
        if (e.Data == null)
        {
            throw new NullReferenceException();
        }
        if (e.Data.GetDataPresent(DataFormats.FileDrop, false) == true)
            e.Effect = DragDropEffects.All;
    }

    private void textBoxFileSample_DragOver(object sender, DragEventArgs e)
    {
        textBoxFileSample.Text = "";
    }

    private void textBoxFileSample_DragDrop(object sender, DragEventArgs e)
    {

        try
        {
            Settings.CheckSettingsFile();
            CheckRequiredFields();
            var inputFiles = GetFilesInfo(e);
            textBoxFileSample.Text = inputFiles.First().FullName;
            SetSettings();
            GetSettings();
            PrepareForm();
            FillFormFromSettings();
            labelStatus.Text = Consts.SETTINGS_SAVED;
        }
        catch (Exception ex)
        {
            textBoxFileSample.Text = $"{ex.Message}";
        }
    }

    private void CheckRequiredFields()
    {
        if (string.IsNullOrWhiteSpace(textBoxMainDepartment.Text))
        {
            throw new Exception(Consts.FILL_REQUIRED_FIELDS);
        }
    }

    private void textBoxFileSample_DragLeave(object sender, EventArgs e)
    {
        textBoxFileSample.Text = Consts.DROP_SAMPLE_HERE;
    } 
    #endregion
}
