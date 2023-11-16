using AppForTestTask.Models;
using Newtonsoft.Json;

namespace AppForTestTask.Data
{
    public class FileInitializer
    {
        public static void GenerateFile()
        {
            var folders = new Folder[]
                {
                    new Folder { Name = "New folders for test", Path = "/"},
                    new Folder { Name = "Resources", Path = "/1/"},
                    new Folder { Name = "Primary Sources", Path = "/1/1/"},
                    new Folder { Name = "Secondary Sources", Path = "/1/2/"},
                    new Folder { Name = "Third Sources", Path = "/1/3/"},
                    new Folder { Name = "Evidence", Path = "/2/"},
                    new Folder { Name = "Record", Path = "/2/1"},
                    new Folder { Name = "Montage", Path = "/3/" },
                    new Folder { Name = "Process", Path = "/3/1/" },
                    new Folder { Name = "References", Path = "/3/2/" },
                    new Folder { Name = "Final Product", Path = "/3/3/" },
                };
            var json = JsonConvert.SerializeObject(folders, Formatting.Indented);
            File.WriteAllText("fileForImport.json", json);
        }
    }
}
