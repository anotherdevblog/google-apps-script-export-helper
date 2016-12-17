using System;
using System.IO;
using Newtonsoft.Json;

namespace anotherdevblog
{
    public class GoogleAppsScriptExtractor
    {
        public void Extract(GoogleAppsScriptExtractionOptions options)
        {
            Console.WriteLine($"Starting extraction of {options.SourceFilePath}");
            var fileExport = Parse(options.SourceFilePath);
            if (!Directory.Exists(options.OutputDirectoryPath))
            {
                Directory.CreateDirectory(options.OutputDirectoryPath);
            }
            foreach (var file in fileExport.files)
            {
                var exportPath = Path.Combine(options.OutputDirectoryPath, file.name + ".gs");
                Console.WriteLine($"Extracting {exportPath}");
                File.WriteAllText(exportPath, file.source);
            }
            Console.WriteLine("All files extracted");
        }

        private GoogleAppsScriptProjectExport Parse(string filePath)
        {
            using (var fileReader = File.OpenText(filePath))
            {
                return new JsonSerializer().Deserialize(fileReader, typeof(GoogleAppsScriptProjectExport)) as GoogleAppsScriptProjectExport;
            }
        }
    }
}