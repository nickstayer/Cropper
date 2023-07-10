namespace Cropper;

public class Settings
{
    private static readonly string SettingsFile = Path.Combine(Environment.CurrentDirectory, "settings.json");
    public string MainDepartmentName { get; set; }
    public int SubDepartmentsCount { get; set; }
    public IEnumerable<string> DepartmentsNames { get; set; }
    public string DefaultFileEncoding { get; set; }

    public Settings()
    {

    }

    public Settings(string mainDepartment, int subDepartmentsCount, IEnumerable<string> comboBoxItems, string defaultEncoding)
    {
        MainDepartmentName = mainDepartment;
        SubDepartmentsCount = subDepartmentsCount;
        DepartmentsNames = comboBoxItems;
        DefaultFileEncoding = defaultEncoding;
    }

    public void WriteSettings()
    {
        File.WriteAllText(SettingsFile, JsonConvert.SerializeObject(this));
    }

    public void ReadSettings()
    {
        var fileContent = File.ReadAllText(SettingsFile);
        var settings = JsonConvert.DeserializeObject<Settings>(fileContent);
        if (settings == null)
        {
            throw new Exception(Consts.NO_SETTINGS);
        }
        MainDepartmentName = settings.MainDepartmentName;
        SubDepartmentsCount = settings.SubDepartmentsCount;
        DepartmentsNames = settings.DepartmentsNames;
        DefaultFileEncoding = settings.DefaultFileEncoding;
    }

    public void CheckSettings()
    {
        if (MainDepartmentName == null || DepartmentsNames == null)
        {
            throw new Exception(Consts.NO_SETTINGS);
        }
    }

    public static void CheckSettingsFile()
    {
        if (!File.Exists(Path.Combine(Environment.CurrentDirectory, "settings.json")))
        {
            throw new Exception(Consts.NO_SETTINGS_FILE);
        }
    }
}
