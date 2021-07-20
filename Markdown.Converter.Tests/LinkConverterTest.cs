using NUnit.Framework;

namespace Markdown.Converter.Tests
{
    public class LinkConverterTest
    {
        private LinkConverter _linkConverter;

        [SetUp]
        public void Setup()
        {
            _linkConverter = new LinkConverter();
        }

        [TestCase("[Link text](https://www.example.com)", @"<a href=""https://example.com"">Link text</a>")]
        [TestCase("[Another Test Link](https://www.test.com)", @"<a href=""https://test.com"">Another Test Link</a>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _linkConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}