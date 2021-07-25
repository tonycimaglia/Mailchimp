using System;
using System.Reflection;

namespace Markdown.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            var seperator = System.IO.Path.DirectorySeparatorChar;
            string[] files = System.IO.Directory.GetFiles($"{directoryPath}{seperator}SampleInputs", "*.md");

            foreach (var file in files)
            {
                var fileName = System.IO.Path.GetFileName(file);
                Console.WriteLine($"Generating html for: {fileName}\n");

                var converter = new ConverterEngine();
                var markDown = System.IO.File.ReadAllLines(file);
                var html = converter.ConvertToHtml(markDown);
                foreach(var line in html)
                {
                    Console.WriteLine($"{line}\n");
                }
            }
        }
    }
}
