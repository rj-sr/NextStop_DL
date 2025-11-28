using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NextStop_Website.Models;

namespace NextStop_Website.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _env;


        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment env)
        {
            _logger = logger;
            _env = env;
        }

        [HttpGet]
        public IActionResult DownloadApk()
        {
            // Build the full physical path to the APK file
            string filePath = Path.Combine(_env.WebRootPath, "Files", "com.bgcbus.nextstop.apk");
            string fileName = "NextStop.apk";

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound("APK file not found.");
            }

            byte[] fileBytes = System.IO.File.ReadAllBytes(filePath);
            return File(fileBytes, "application/vnd.android.package-archive", fileName);
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
    }
}
