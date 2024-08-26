using System.Runtime.Serialization;

namespace Cropper;

internal class Consts
{
    public const string DROP_FILES_HERE = "Перетащите сюда формы ИЦ (.txt)";
    public const string INPUT_FILE_EXTENTION = ".txt";
    public const string WRONG_EXTENTION = "Недопустимое расширение файла";
    public const string NO_SETTINGS_FILE = "Отсутствует файл настроек";
    public const string FINISH = "Готово!";
    public const string MARK = "Выделить";
    public const string FIRST_TABLE_BODY_ROW = ":АГАПОВКА";
    public const string LAST_TABLE_BODY_ROW = ":ОБЛАСТЬ";
    public const string ENCODING_DEFAULT = "по умолчанию";
    public const string ENCODING_1251 = "windows-1251";
    public const string ENCODING = "Кодировка";


    public const string FILTER_FILE = "filter.txt";
    public const string ENCODING_FILE = "encoding.txt";
    public const string MARKER_RULES_FILE = "marker.txt";
    public const string FORMS_TO_DOWNLOAD_FILE = "download_forms.txt";
    public const string URL_FILE = "download_url.txt";

    public static string[] Encodings = new string[]
    {
        ENCODING_DEFAULT,
        ENCODING_1251
    };
}
