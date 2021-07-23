using System;
using System.Collections.Generic;

namespace Markdown.Converter
{
    public class ParagraphConverter
    {
        public string Convert(string markdown)
        {
            var htmlParagraph = $"<p>{markdown}</p>";
            return htmlParagraph;
        }
    }
}
