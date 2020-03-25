using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UploadFile.Database;
using UploadFile.Models;
using UploadFile.ViewModel;

namespace UploadFile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context _context;

        public HomeController(ILogger<HomeController> logger, Context context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        [HttpPost("Upload")]
        public async Task<IActionResult> Upload([FromForm]FileUploadViewModel model)
        {
            try
            {
                using (var memoryStream = new MemoryStream())
                {
                    await model.FormFile.CopyToAsync(memoryStream);

                    var file = new AppFile()
                    {
                        Content = memoryStream.ToArray(),
                        Name = model.FormFile.FileName
                    };

                    _context.File.Add(file);

                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction(nameof(Error));
            }
        }
    }
}
