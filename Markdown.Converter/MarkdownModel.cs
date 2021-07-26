using Markdown.Converter.Converters;

namespace Markdown.Converter
{
    public class MarkdownModel
    {
        public ConversionType ConversionToPerform { get; set; }
        public string Markdown { get; set; }
    }
}