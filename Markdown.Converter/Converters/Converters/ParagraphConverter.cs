
namespace Markdown.Converter
{
    public class ParagraphConverter : IConverter
    {
        public string Convert(string markdown)
        {
            var htmlParagraph = $"<p>{markdown}</p>";
            return htmlParagraph;
        }
    }
}
