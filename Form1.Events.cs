namespace Cropper;

public partial class Form1
{
    public Form1()
    {
        InitializeComponent();
    }

    private Settings _settings;

    private void Form1_Load(object sender, EventArgs e)
    {
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
        textBoxFileSample.Text = Consts.DROP_SAMPLE_HERE;
        labelFileName.Text = "";
        foreach (var item in Consts.ComboBoxItems)
        {
            comboBoxDeps.Items.Add(item);
        }
        try
        {
            _settings = new Settings();
            _settings.ReadSettings();
            textBoxMainDepartment.Text = _settings.MainDepartment;
            textBoxSubDepartmentsCount.Text = _settings.SubDepartmentsCount.ToString();
        }
        catch (Exception ex)
        {
            textBoxDropable.Text = ex.Message + "\r\n";
        }
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
            var inputFiles = GetFilesInfo(e);
            foreach (var fileInfo in inputFiles)
            {
                labelFileName.Text = fileInfo.Name;
                var content = new Parser(fileInfo.FullName, Consts.MAIN_DEPARTMENT, Consts.SUB_DEPARTMENTS_COUNT, Consts.Patterns).Parse();
                SaveToWord(fileInfo, content);
            }
            textBoxDropable.Text = Consts.DROP_FILES_HERE;
            labelFileName.Text = Consts.FINISH;
        }
        catch (Exception ex)
        {
            textBoxDropable.Text += ex.Message + "\r\n";
            textBoxDropable.Text += Consts.DROP_FILES_HERE;
        }
    }

    private void textBoxDropable_DragLeave(object sender, EventArgs e)
    {
        textBoxDropable.Text = Consts.DROP_FILES_HERE;
    }
    #endregion

    #region textBoxFileSamle
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
            var inputFiles = GetFilesInfo(e);
            textBoxFileSample.Text = inputFiles.First().Name;
        }
        catch (Exception ex)
        {
            textBoxFileSample.Text = $"{ex.Message}. {Consts.DROP_SAMPLE_HERE}";
        }
    }

    private void textBoxFileSample_DragLeave(object sender, EventArgs e)
    {
        textBoxFileSample.Text = Consts.DROP_SAMPLE_HERE;
    } 
    #endregion
}
