using NUnit.Framework;
using System.Collections.Generic;

namespace Markdown.Converter.Tests
{
    public class ParagraphConverterTest
    {
        private ParagraphConverter _paragraphConverter;

        [SetUp]
        public void Setup()
        {
            _paragraphConverter = new ParagraphConverter();
        }

        [TestCase("Unformatted text", "<p>Unformatted text</p>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _paragraphConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }

        [Test]
        public void ValidateMultiLineConversion()
        {
            List<string> sequentialUnformattedText = new List<string>() { "How are you? ", "What's going on?" };
            var html = "<p/>How are you? What's going on?</p>";

            var convertedHtml = _paragraphConverter.Convert(sequentialUnformattedText);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}