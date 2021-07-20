using NUnit.Framework;

namespace Markdown.Converter.Tests
{
    public class HeadingConverterTest
    {
        private HeadingConverter _headingConverter;

        [SetUp]
        public void Setup()
        {
            _headingConverter = new HeadingConverter();
        }

        [TestCase("# Heading 1", "<h1>Heading 1</h1>")]
        [TestCase("# Heading 2", "<h2>Heading 2</h2>")]
        [TestCase("# Heading 3", "<h3>Heading 3</h3>")]
        [TestCase("# Heading 4", "<h4>Heading 4</h4>")]
        [TestCase("# Heading 5", "<h3>Heading 5</h5>")]
        [TestCase("# Heading 6", "<h3>Heading 6</h6>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _headingConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}