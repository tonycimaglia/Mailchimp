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

        [TestCase("[Link text](https://www.example.com)", @"<a href=""https://www.example.com"">Link text</a>")]
        [TestCase("[Another Test Link](https://www.test.com)", @"<a href=""https://www.test.com"">Another Test Link</a>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _linkConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }

        [TestCase("[Link text](https://www.example.com)", "(", ")", "https://www.example.com")]
        [TestCase("[Link text](https://www.example.com)", "[", "]", "Link text")]
        public void ValidateFindTextBetween(string markdown, string char1, string char2, string actual)
        {
            var textBetween = _linkConverter.FindTextBetween(markdown, char1, char2);
            Assert.That(textBetween, Is.EqualTo(actual));
        }
    }
}