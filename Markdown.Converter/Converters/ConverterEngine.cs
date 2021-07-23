using Markdown.Converter.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Markdown.Converter
{
    public class ConverterEngine
    {
        public IEnumerable<string> ConvertToHtml(IEnumerable<string> markdown)
        {
            // loop and determine what kind of conversion should happen for each string
            // DetermineConversionType()
            // combine sequential lines of unformatted text
            // use converter factory to instantiate correct converter
            // convert and add to html string array
            return new List<string>();
        }

        public MarkdownModel DetermineConversionType(string markdown)
        {
            MarkdownModel result = new MarkdownModel();
            result.Markdown = markdown;

            if (string.IsNullOrWhiteSpace(markdown))
            {
                result.ConversionToPerform = ConversionType.BlankLine;
                return result;
            }

            var markDownNoWhiteSpace = markdown.Trim();
            var linkCharacters = new[] { "[", "]", "(", ")" };
            bool containsLink = linkCharacters.All(markdown.Contains);
            if (containsLink)
            {
                if (markdown.Contains("#"))
                {
                    result.ConversionToPerform = ConversionType.HeadingWithLink;
                    return result;
                }

                bool hasTextBeforeLink = markDownNoWhiteSpace.IndexOf("[") > 0;
                bool hasTextAfterLink = markDownNoWhiteSpace.IndexOf(")") < (markDownNoWhiteSpace.Length - 1);
                if (hasTextBeforeLink || hasTextAfterLink)
                {
                    result.ConversionToPerform = ConversionType.ParagraphWithLink;
                    return result;
                }
                else
                {
                    result.ConversionToPerform = ConversionType.Link;
                    return result;
                }
            }

            if (markDownNoWhiteSpace.StartsWith('#'))
            {
                result.ConversionToPerform = ConversionType.Heading;
                return result;
            }
            else
            {
                result.ConversionToPerform = ConversionType.Paragraph;
                return result;
            }
        }
    }
}
