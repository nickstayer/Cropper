namespace Cropper;

internal class Settings
{
    private static string SettingsFile
    {
        get
        {
            var file = Path.Combine(Environment.CurrentDirectory, "settings.json");
            if (File.Exists(file)) 
            { 
                return file; 
            }
            throw new Exception(Consts.NO_SETTINGS_FILE);
        } 
    }
    public string MainDepartment { get; set; }
    public int SubDepartmentsCount { get; set; }
    public string[] ComboBoxItems { get; set; }

    public Settings()
    {

    }

    public Settings(string mainDepartment, int subDepartmentsCount, string[] comboBoxItems)
    {
        MainDepartment = mainDepartment;
        SubDepartmentsCount = subDepartmentsCount;
        ComboBoxItems = comboBoxItems;
    }

    public void WriteSettings()
    {
        File.WriteAllText(SettingsFile, JsonConvert.SerializeObject(this));
    }

    public void ReadSettings()
    {
        var fileContent = File.ReadAllText(SettingsFile);
        var settings = JsonConvert.DeserializeObject<Settings>(fileContent);
        MainDepartment = settings.MainDepartment;
        SubDepartmentsCount = settings.SubDepartmentsCount;
        ComboBoxItems = settings.ComboBoxItems;
    }
}
