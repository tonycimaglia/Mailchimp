
namespace Markdown.Converter
{
    class UnkownMarkdownConverter : IConverter
    {
        public string Convert(string markdown)
        {
            return "This version of Markdown.Converter is unable to convert this markdown syntax.";
        }
    }
}
