using System;
using System.Collections.Generic;

namespace Markdown.Converter
{
    public class HeadingWithLinkConverter : IConverter
    {
        private HeadingConverter _headingConverter;
        private LinkConverter _linkConverter;

        public HeadingWithLinkConverter()
        {
            _headingConverter = new HeadingConverter();
            _linkConverter = new LinkConverter();
        }

        public string Convert(string markdown)
        {
            string htmlHeading = _headingConverter.Convert(markdown);
            string headingWithLink = ConvertLinkWithinHtmlContent(htmlHeading);
            return headingWithLink;
        }

        // pull this duplicate method into either the converter interface or seperate class
        public string ConvertLinkWithinHtmlContent(string markdown)
        {
            //this will fail if a <p> or <h> has other [ or ) in the content in certain positions
            int startingPosition = markdown.IndexOf("[");
            int endingPostion = markdown.LastIndexOf(")") + 1;
            int lengthOfLink = endingPostion - startingPosition;
            string markdownLink = markdown.Substring(startingPosition, lengthOfLink);
            string htmlHref = _linkConverter.Convert(markdownLink);

            string headingWithLink = markdown.Remove(startingPosition, lengthOfLink).Insert(startingPosition, htmlHref);

            return headingWithLink;
        }
    }
}
