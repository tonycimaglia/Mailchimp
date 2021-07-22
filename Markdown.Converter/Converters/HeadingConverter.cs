
using System.Linq;

namespace Markdown.Converter
{
    public class HeadingConverter : IConverter
    {
        public string Convert(string markdown)
        {
            var markdownNoWhiteSpace = markdown.TrimStart();
            var headingSize = markdownNoWhiteSpace.TakeWhile(c => c == '#').Count();
            var htmlContentStartPosition = headingSize++;
            var htmlContent = markdownNoWhiteSpace.Substring(htmlContentStartPosition);
            var htmlHeading = $"<h{headingSize}>{htmlContent}</h{headingSize}>";

            return htmlHeading;
        }
    }
}
