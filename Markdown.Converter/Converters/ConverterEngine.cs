using Markdown.Converter.Converters;
using System.Collections.Generic;
using System.Linq;

namespace Markdown.Converter
{
    public class ConverterEngine
    {
        public List<string> ConvertToHtml(IEnumerable<string> markdown)
        {
            List <MarkdownModel> markdownList = new List<MarkdownModel>();

            // loop and determine what kind of conversion should happen for each string
            foreach (var line in markdown)
            {
                var currentModel = DetermineConversionType(line);
                MarkdownModel prevModel = markdownList.LastOrDefault();
                if(prevModel != null)
                {
                    bool prevModelIsParagraph = prevModel.ConversionToPerform == ConversionType.Paragraph;
                    if (prevModelIsParagraph && (currentModel.ConversionToPerform == ConversionType.Paragraph))
                    {
                        markdownList.Last().Markdown += currentModel.Markdown;
                    }
                    else
                    {
                        markdownList.Add(currentModel);
                    }
                } else
                {
                    markdownList.Add(currentModel);
                }
            }

            var htmlArray = new List<string>();
            foreach (var model in markdownList)
            {
                //var factory = new ConverterFactory(model);
                //var markdown = factory.Convert(model);
                //htmlArray.Add(markdown);
            }

            return htmlArray;
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
