namespace Cropper;

class WebManager
{
    static readonly HttpClient client = new HttpClient();

    public static async Task<string> DownloadTextFile(string url, string savePath)
    {
        HttpResponseMessage response = await client.GetAsync(url);
        response.EnsureSuccessStatusCode();
        string text = await response.Content.ReadAsStringAsync();
        await File.WriteAllTextAsync(savePath, text.Replace("\r\n", "\r"));
        return savePath;
    }

    public static async Task DownloadFile(string fileUrl, string dirPath)
    {
        try
        {
            string transFileName = Path.GetFileName(fileUrl);
            string fileName = Path.Combine(dirPath, transFileName);

            using (HttpResponseMessage response = await client.GetAsync(fileUrl, HttpCompletionOption.ResponseHeadersRead))
            {
                response.EnsureSuccessStatusCode();

                using (var fileStream = new FileStream(fileName, FileMode.Create, FileAccess.Write, FileShare.None))
                {
                    using (var contentStream = await response.Content.ReadAsStreamAsync())
                    {
                        await contentStream.CopyToAsync(fileStream);
                    }
                }
            }

            Console.WriteLine($"Файл {fileName} успешно загружен.");
        }
        catch (HttpRequestException httpErr)
        {
            Console.WriteLine($"HTTP ошибка: {httpErr.Message}");
        }
        catch (Exception err)
        {
            Console.WriteLine($"Другая ошибка: {err.Message}");
        }
    }

    public static async Task<List<string>> GetLinks(string url)
    {
        try
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
        catch (HttpRequestException httpErr)
        {
            Console.WriteLine($"HTTP ошибка: {httpErr.Message}");
        }
        catch (Exception err)
        {
            Console.WriteLine($"Другая ошибка: {err.Message}");
        }
        return new List<string>();
    }
}
