using AppForTestTask.Data;
using AppForTestTask.Models;
using AppForTestTask.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace AppForTestTask.Controllers
{
    public class ImportExportController : Controller
    {
        DbForTestTaskContext _context;
        FolderImportExportService _service;

        public ImportExportController(DbForTestTaskContext context, FolderImportExportService service)
        {
            _context = context;
            _service = service;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Import()
        {
            bool result = await _service.ImportFoldersFromFilePath("fileForImport.json");
            if (result)
            {
                return RedirectToAction("Index", "Folder");
            }
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
