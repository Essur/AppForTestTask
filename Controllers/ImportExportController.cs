using System.Diagnostics;
using AppForTestTask.Models;
using AppForTestTask.Services;
using Microsoft.AspNetCore.Mvc;


namespace AppForTestTask.Controllers
{
    public class ImportExportController : Controller
    {
        FolderImportExportService _service;

        public ImportExportController(FolderImportExportService service)
        {
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
