using AppForTestTask.Data;
using AppForTestTask.Models;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace AppForTestTask.Services
{
    public class FolderImportExportService
    {
        private readonly DbForTestTaskContext _context;

        public FolderImportExportService(DbForTestTaskContext context)
        {
            _context = context;
        }

        public async Task<bool> ImportFoldersFromFilePath(string filePath)
        {
            if (File.Exists(filePath))
            {
                var json = File.ReadAllText(filePath);
                var folders = JsonConvert.DeserializeObject<List<Folder>>(json);

                if (_context.Folders != null)
                {
                    var oldFolders = await _context.Folders.ToListAsync();
                    _context.Folders.RemoveRange(oldFolders);
                    await _context.SaveChangesAsync();
                    ExportOldValuesFromTable(oldFolders);

                    if (folders != null)
                    {
                        _context.Folders.AddRange(folders);
                    }
                }
                
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        private void ExportOldValuesFromTable(List<Folder> oldFolders)
        {
            var oldToJson = JsonConvert.SerializeObject(oldFolders, Formatting.Indented);
            File.WriteAllText("oldData.json", oldToJson);
        }
    }
}
