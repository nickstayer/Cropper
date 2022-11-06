using System.Runtime.Serialization;

namespace Cropper;

internal class Consts
{
    public const string DROP_FILES_HERE = "Скопируйте формы в текстовые файлы (.txt) и перетащите их сюда";
    public const string DROP_SAMPLE_HERE = "Перетащите сюда образец формы (.txt)";
    public const string INPUT_FILE_EXTENTION = ".txt";
    public const string WRONG_EXTENTION = "Недопустимое расширение файла";
    public const string FINISH = "Готово!";
    public const string NO_SETTINGS_FILE = "Отсутствует файл настроек";
    public const string NO_SETTINGS = "Требуется произвести настройку";
    public static readonly string[] Patterns =     
    {
        @"^(:\s{3})",   //начинается с: двоеточие, три пробела
        @"^\s",         //пробел
        @"^(:-)",       //двоеточие, дефис
        @"^(:ОБЛАСТЬ)",
        @"^\w",         //любая буква
    };
    // TODO: вынести из кода переменные
    public const string MAIN_DEPARTMENT = @":ЧЕЛЯБИНСК";
    public const int SUB_DEPARTMENTS_COUNT = 8;

    public static readonly string[] Items = new string[]
    {
        "ОП МЕТАЛЛУРГИЧ",
    };
}
