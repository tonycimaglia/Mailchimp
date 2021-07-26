using NUnit.Framework;

namespace Markdown.Converter.Tests
{
    public class HeadingWithLinkConverterTest
    {
        private HeadingWithLinkConverter _headingWithLinkConverter;

        [SetUp]
        public void Setup()
        {
            _headingWithLinkConverter = new HeadingWithLinkConverter();
        }

        [TestCase("## This is a header [with a link](http://yahoo.com)", @"<h2>This is a header <a href=""http://yahoo.com"">with a link</a></h2>")]
        //[TestCase("## Header with [] and [with a link](http://yahoo.com)", @"<h2>Header with [] and <a href=""http://yahoo.com"">with a link</a></h2>")]
        //[TestCase("## Header with () and [with a link](http://yahoo.com)", @"<h2>Header with [] and <a href=""http://yahoo.com"">with a link</a></h2>")]
        public void ValidateConversion(string markdown, string html)
        {
            var convertedHtml = _headingWithLinkConverter.Convert(markdown);
            Assert.That(convertedHtml, Is.EqualTo(html));
        }
    }
}