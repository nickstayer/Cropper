using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;

namespace Cropper;

public class Word
{
    public static void SaveToWordWithFormatting(string docxFilePath, string content)
    {
        using WordprocessingDocument wordDocument = WordprocessingDocument.Create(docxFilePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document);
        MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
        mainPart.Document = new Document();
        Body body = mainPart.Document.AppendChild(new Body());
        AddContentToBegin(body, content);
        FormatDoc(wordDocument);
        mainPart.Document.Save();
    }

    private static void AddContentToBegin(Body body, string content)
    {
        Paragraph para = body.AppendChild(new Paragraph());
        Run run = para.AppendChild(new Run());
        run.AppendChild(new Text(content));
    }

    private static void FormatDoc(WordprocessingDocument wordDocument)
    {
        var paragraphs = wordDocument.MainDocumentPart?.Document?.Body?.Elements<Paragraph>();

        foreach (var paragraph in paragraphs!)
        {
            // Настройка шрифта
            var runProperties = new RunProperties();
            runProperties.FontSize = new FontSize() { Val = "16" }; // 8 * 2 = 16 (OpenXML использует половинные пункты)
            runProperties.FontSizeComplexScript = new FontSizeComplexScript() { Val = "16" };
            runProperties.RunFonts = new RunFonts() { Ascii = "Courier New", HighAnsi = "Courier New" };
            
            // Применение настроек к каждому run
            foreach (var run in paragraph.Elements<Run>())
            {
                run.PrependChild(runProperties.CloneNode(true));
            }
        }

        // Настройка отступов
        var sectionProperties = new SectionProperties();
        var pageMargin = new PageMargin()
        {
            Top = 1440, // 1 inch = 1440 twips
            Bottom = 1440,
            Left = 1440,
            Right = 1440
        };
        sectionProperties.Append(pageMargin);
        wordDocument?.MainDocumentPart?.Document?.Body?.Append(sectionProperties);

        // Настройка межстрочного интервала и интервала после параграфов
        foreach (var paragraph in paragraphs)
        {
            ParagraphProperties paragraphProperties = new ParagraphProperties();
            paragraphProperties.SpacingBetweenLines = new SpacingBetweenLines() { Line = "240", After = "0" }; // 12pt = 240 twips
            paragraph.ParagraphProperties = paragraphProperties;
        }
    }
}