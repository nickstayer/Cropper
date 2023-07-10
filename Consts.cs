using System.Runtime.Serialization;

namespace Cropper;

internal class Consts
{
    public const string DROP_FILES_HERE = "Скопируйте формы в текстовые файлы (.txt) и перетащите их сюда";
    public const string DROP_SAMPLE_HERE = "Сохраните настройки, перетащив сюда любую форму ИЦ(.txt)";
    public const string INPUT_FILE_EXTENTION = ".txt";
    public const string WRONG_EXTENTION = "Недопустимое расширение файла";
    public const string FINISH = "Готово!";
    public const string NO_SETTINGS_FILE = "Отсутствует файл настроек. В папке приложения создайте файл settings.json и перезапустите программу";
    public const string NO_SETTINGS = "Перейдите во вкладку 'Настройки' и заполните все поля";
    public const string SETTINGS_SAVED = "Настройки сохранены";
    public const string WRONG_STING_FORMAT = "Неверный формат строки";
    public const string NO_SAMPLE_FILE = "Не указан образец формы";
    public const string FILL_REQUIRED_FIELDS = "Заполните обязательные поля";
    public static readonly string[] Patterns =     
    {
        @"^(:\s{3})",   //начинается с: двоеточие, три пробела
        @"^\s",         //пробел
        @"^(:-)",       //двоеточие, дефис
        @"^(:ОБЛАСТЬ)",
        @"^\w",         //любая буква
    };
    // TODO: вынести из кода переменные

    public static readonly string[] ComboBoxItems = new string[]
    {
        "ОП ЛЕНИНСКИЙ",
        "ОП МЕТАЛЛУРГИЧ",
        "ОП СОВЕТСКИЙ",
        "ОП ТРАКТОРОЗАВ",
        "ОП ЦЕНТРАЛЬНЫЙ",
        "ОП КАЛИНИНСКИЙ",
        "ОП КУРЧАТОВСКИЙ",
        "ОП СЕВЕРО-ЗАПАД.",
    };
}
