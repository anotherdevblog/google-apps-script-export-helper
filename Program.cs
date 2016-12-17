using System;
using System.IO;

namespace anotherdevblog
{
    public class Program
    {
        public static void Main(string[] args)
        {
            try
            {
                Run(args);
            }
            catch (Exception e)
            {
                Console.Error.WriteLine(e.Message);
            }
        }

        private static void Run(string[] args)
        {
            if (args.Length < 1 || args.Length > 2)
            {
                throw new ArgumentException("Usage: dotnet run {source file} {output directory (optional)}");
            }
            new GoogleAppsScriptExtractor().Extract(new GoogleAppsScriptExtractionOptions
            {
                SourceFilePath = args[0],
                OutputDirectoryPath = args.Length == 2 ? args[1] : Path.Combine(Path.GetDirectoryName(args[0]), Path.GetFileNameWithoutExtension(args[0]))
            });
        }
    }
}
