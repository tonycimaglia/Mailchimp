using Markdown.Converter.Converters;
using NUnit.Framework;
using System.Linq;
using System.Reflection;

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
            var seperator = System.IO.Path.DirectorySeparatorChar;
            var markDown = System.IO.File.ReadAllLines($"{directoryPath}{seperator}TestFiles{seperator}{markdownFile}");
            var expectedHtml = System.IO.File.ReadAllLines($"{directoryPath}{seperator}TestFiles{seperator}{htmlFile}").Where(x => !string.IsNullOrWhiteSpace(x));

            var convertedHtml = _converterEngine.ConvertToHtml(markDown);

            Assert.That(convertedHtml, Is.EquivalentTo(expectedHtml));
        }


        [TestCase("", ConversionType.BlankLine)]
        [TestCase("## This is a header [with a link](http://yahoo.com)", ConversionType.HeadingWithLink)]
        [TestCase("This is sample markdown for the[Mailchimp] (https://www.mailchimp.com) homework assignment.", ConversionType.ParagraphWithLink)]
        [TestCase("[Link text](https://www.example.com)", ConversionType.Link)]
        [TestCase("# Heading 1", ConversionType.Heading)]
        [TestCase("Unformatted text", ConversionType.Paragraph)]
        public void ValidateConversionType(string markdown, ConversionType expectedType)
        {
            var model = _converterEngine.DetermineConversionType(markdown);
            var type = model.ConversionToPerform;

            Assert.That(type == expectedType);
        }
    }
}
