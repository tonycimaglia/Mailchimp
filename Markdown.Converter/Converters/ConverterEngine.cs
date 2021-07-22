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
            // combine sequential lines of unformatted text
            // use converter factory to instantiate correct converter
            // convert and add to html string array
            return new List<string>();
        }
    }
}
