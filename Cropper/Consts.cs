using System.Runtime.Serialization;

namespace Cropper;

internal class Consts
{
    public const string DROP_FILES_HERE = "Скопируйте формы в текстовые файлы (.txt) и перетащите их сюда";
    public const string INPUT_FILE_EXTENTION = ".txt";
    public const string WRONG_EXTENTION = "Недопустимое расширение файла";
    public const string NO_SETTINGS_FILE = "Отсутствует файл настроек";
    public const string FINISH = "Готово!";
    public const string HIGHLIGHT = "Выделить";
    public const string FIRST_TABLE_BODY_ROW = ":АГАПОВКА";
    public const string LAST_TABLE_BODY_ROW = ":ОБЛАСТЬ";
    public const string ENCODING_DEFAULT = "по умолчанию";
    public const string ENCODING_1251 = "windows-1251";
    public const string ENCODING = "Кодировка";


    public const string SETTINGS_FILE = "filterLines.txt";
    public const string ENCODING_FILE = "encoding.txt";
    public const string FORMS_TO_HIGHLIGHT_FILE = "formsToHighlight.txt";
    public const string HIGHLIGHT_RULES_FILE = "highlightRules.txt";

    public static string[] Encodings = new string[]
    {
        ENCODING_DEFAULT,
        ENCODING_1251
    };
}
