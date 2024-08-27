namespace Cropper;

public class WebManager
{
    static readonly HttpClient client = new HttpClient();

    public static async Task<string> DownloadTextFile(string url, string filePath, Encoding? encoding = null)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string text;
        if(encoding is null)
            text = await response.Content.ReadAsStringAsync();
        else
        {
            var bytes = await response.Content.ReadAsByteArrayAsync();
            text = encoding.GetString(bytes);
        }
        await File.WriteAllTextAsync(filePath, text.Replace("\r\n", "\r"));
        return filePath;
    }

    public static async Task DownloadFile(string fileUrl, string dirPath)
    {
        string transFileName = Path.GetFileName(fileUrl);
        string fileName = Path.Combine(dirPath, transFileName);

        using HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead);
        response.EnsureSuccessStatusCode();

        using var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None);
        using var contentStream = await response.Content.ReadAsStreamAsync();
        await contentStream.CopyToAsync(fileStream);
    }

    public static async Task<List<string>> GetLinks(string url)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string src = await response.Content.ReadAsStringAsync();

        var doc = new HtmlAgilityPack.HtmlDocument();
        doc.LoadHtml(src);

        List<string> fileLinks = new List<string>();
        foreach (var link in doc.DocumentNode.SelectNodes("//a[@href]"))
        {
            string href = link.Attributes["href"].Value;
            fileLinks.Add(href);
        }
        return fileLinks;
    }
}
