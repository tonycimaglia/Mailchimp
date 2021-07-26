namespace Markdown.Converter
{
    internal class ConverterFactory
    {
        public IConverter Create(MarkdownModel model)
        {
            switch (model.ConversionToPerform)
            {
                case Converters.ConversionType.Heading:
                    return new HeadingConverter();
                case Converters.ConversionType.Link:
                    return new LinkConverter();
                case Converters.ConversionType.Paragraph:
                    return new ParagraphConverter();
                case Converters.ConversionType.HeadingWithLink:
                    return new HeadingWithLinkConverter();
                case Converters.ConversionType.ParagraphWithLink:
                    return new ParagraphWithLinkConverter();
                default:
                    // cannot be reached at his time. 
                    return new UnkownMarkdownConverter();
            }
        }
    }
}