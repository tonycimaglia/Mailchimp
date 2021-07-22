
using System.Text;

namespace Markdown.Converter
{
    public class LinkConverter : IConverter
    {
        public string Convert(string markdown)
        {
            string linkText = FindTextBetween(markdown, "[", "]");
            string url = FindTextBetween(markdown, "(", ")");
            var htmlHref = $"<a href=\"{url}\">{linkText}</a>";
            return htmlHref;
        }

        public string FindTextBetween (string markdownLink, string char1, string char2)
        {
            int startingPosition = markdownLink.IndexOf(char1) + char1.Length;
            int endingPostion = markdownLink.LastIndexOf(char2);
            int lengthOfTextBetween = endingPostion - startingPosition;

            string textBetween = markdownLink.Substring(startingPosition, lengthOfTextBetween);
            return textBetween;
        }
    }
}
