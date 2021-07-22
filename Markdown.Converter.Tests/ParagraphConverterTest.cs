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
        [TestCase("This is some other text without formatting", "<p>This is some other text without formatting</p>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _paragraphConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}