using System;
using System.Collections.Generic;

namespace Markdown.Converter
{
    public class ParagraphConverter
    {
        public string Convert(string markdown)
        {
            // combine consecutive unformatted lines before passing to paragraph converter
            // this will eliminate need for method that converts multiple lines.
            var htmlParagraph = $"<p>{markdown}</p>";
            return htmlParagraph;
        }
    }
}
