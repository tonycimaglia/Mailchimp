using System;
using System.Reflection;

namespace Markdown.Converter
{
    class Program
    {
        static void Main(string[] args)
        {
            var directoryPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
            string[] files = System.IO.Directory.GetFiles($"{directoryPath}\\SampleInputs", "*.md");
            foreach (var file in files)
            {
                var converter = new ConverterEngine();
                var markDown = System.IO.File.ReadAllLines(file);
                var html = converter.ConvertToHtml(markDown);
                foreach(var line in html)
                {
                    Console.WriteLine($"{line}\n");
                }
            }
            Console.WriteLine("Hello World!");
        }
    }
}
