using AppForTestTask.Data;
using AppForTestTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.IO;

namespace AppForTestTask.Controllers
{
    public class FolderController : Controller
    {
        private readonly DbForTestTaskContext _context;

        public FolderController(DbForTestTaskContext context)
        {
            _context = context;
        }


        public async Task<IActionResult> Folders()
        {
            var folders = await _context.Folders.ToListAsync();
            return View(folders);
        }

        // GET: /Folder
        public async Task<IActionResult> Index(string path)
        {
            var rootFolders = await _context.Folders
                .Where(f => f.Path.Equals("/"))
                .ToListAsync();

            return View(rootFolders);
        }

        // GET: /Folder/Details/
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var folder = await _context.Folders
                .FirstOrDefaultAsync(f => f.FolderId == id);

            if (folder == null)
            {
                return NotFound();
            }

            var subfolders = _context.Folders
               .AsEnumerable()
               .Where(f => f.Path.StartsWith(folder.Path) && f.Path != folder.Path
                   && f.Path.Count(c => c == '/') == folder.Path.Count(c => c == '/') + 1)
               .ToList();

            ViewData["CurrentFolder"] = folder.Name;
            return View(subfolders);
        }
    }
}
