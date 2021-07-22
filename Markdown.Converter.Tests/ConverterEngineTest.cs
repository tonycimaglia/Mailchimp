using NUnit.Framework;
using System.Reflection;
using System.Text;

namespace Markdown.Converter.Tests
{
    public class ConverterEngineTest
    {
        private ConverterEngine _converterEngine;

        [SetUp]
        public void Setup()
        {
            _converterEngine = new ConverterEngine();
        }

        [TestCase("InputTest.md", "ActualTest.html")]
        [TestCase("InputTest2.md", "ActualTest2.html")]
        public void ValidateConversion(string markdownFile, string htmlFile)
        {
            var directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var markDown = System.IO.File.ReadAllLines($"{directoryPath}\\TestFiles\\{markdownFile}");
            var expectedHtml = System.IO.File.ReadAllLines($"{directoryPath}\\TestFiles\\{htmlFile}");

            var convertedHtml = _converterEngine.ConvertToHtml(markDown);

            Assert.That(convertedHtml, Is.EquivalentTo(expectedHtml));
        }
    }
}
