using System.Text;
using Cropper;

namespace Cropper.Tests;

public class Tests
{
    string _dataDir;

    [SetUp]
    public void Setup()
    {
        _dataDir = Path.GetFullPath(Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..\data\"));

    }

    [Test]
    [TestCase(":НЕЗ.ОБОР.НАРК.ОБЩЕУГ", "-")]
    [TestCase(":В С Е Г О", "")]
    [TestCase(":  ОСОБО ТЯЖКИЕ", "+")]
    public void GetHighLightRulesTest(string key, string expectedValue)
    {
        var rulesFile = _dataDir + "highlightRulesTest.txt";
        if (!File.Exists(rulesFile))
        {
            throw new FileNotFoundException(rulesFile);
        }
        var rules = DataManager.GetHighlightRules(rulesFile);
        Assert.That(rules[key], Is.EqualTo(expectedValue));
    }

    [Test]
    [TestCase("S32_42_1.TXT", 1)]
    [TestCase("S32_42_2.TXT", 2)]
    [TestCase("S32_42_3.TXT", 3)]
    public void GetHighlightLinesTest(string formFileName, int expectedLinesCount)
    {
        var formFile = _dataDir + formFileName;
        var rulesFile = _dataDir + "highlightRulesTest.txt";
        var rules = DataManager.GetHighlightRules(rulesFile);
        var lines = File.ReadAllLines(formFile, Encoding.Default);
        var result = DataManager.GetHighLightLines(lines, rules);
        Assert.That(result.Count, Is.EqualTo(expectedLinesCount));
    }
}