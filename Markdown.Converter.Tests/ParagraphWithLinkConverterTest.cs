using NUnit.Framework;

namespace Markdown.Converter.Tests
{
    public class ParagraphWithLinkConverterTest
    {
        private ParagraphWithLinkConverter _paragraphWithLinkConverter;

        [SetUp]
        public void Setup()
        {
            _paragraphWithLinkConverter = new ParagraphWithLinkConverter();
        }

        [TestCase("Test Paragraph with converted [link](https://www.test.com)", @"<p>Test Paragraph with converted <a href=""https://www.test.com"">link</a></p>")]
        [TestCase("Paragraph with () before [link](https://www.test.com)", @"<p>Paragraph with () before <a href=""https://www.test.com"">link</a></p>")]
        [TestCase("Paragraph with [link](https://www.test.com) () after link", @"<p>Paragraph with () before <a href=""https://www.test.com"">link</a> () after link</p>")]
        [TestCase("Paragraph with [] before [link](https://www.test.com)", @"<p>Paragraph with [] before <a href=""https://www.test.com"">link</a></p>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _paragraphWithLinkConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}