namespace Cropper;

public class Settings
{
    private static readonly string SettingsFile = Path.Combine(Environment.CurrentDirectory, "settings.json");
    public string MainDepartment { get; set; }
    public int SubDepartmentsCount { get; set; }
    public IEnumerable<string> Departments { get; set; }

    public Settings()
    {

    }

    public Settings(string mainDepartment, int subDepartmentsCount, IEnumerable<string> comboBoxItems)
    {
        MainDepartment = mainDepartment;
        SubDepartmentsCount = subDepartmentsCount;
        Departments = comboBoxItems;
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
        MainDepartment = settings.MainDepartment;
        SubDepartmentsCount = settings.SubDepartmentsCount;
        Departments = settings.Departments;
    }

    public void CheckSettings()
    {
        if (MainDepartment == null || Departments == null)
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
