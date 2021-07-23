using System;
using System.Collections.Generic;

namespace Markdown.Converter
{
    public class ParagraphWithLinkConverter: IConverter
    {
        private ParagraphConverter _paragraphConverter;
        private LinkConverter _linkConverter;

        public ParagraphWithLinkConverter()
        {
            _paragraphConverter = new ParagraphConverter();
            _linkConverter = new LinkConverter();
        }

        public string Convert(string markdown)
        {
            string htmlParagraph = _paragraphConverter.Convert(markdown);
            string paragraphWithLink = ConvertLinkWithinHtmlContent(htmlParagraph);
            return paragraphWithLink;
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

            string paragraphWithLink = markdown.Remove(startingPosition, lengthOfLink).Insert(startingPosition, htmlHref);

            return paragraphWithLink;
        }
    }
}
