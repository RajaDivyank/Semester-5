using _21010101152_215___Folio__.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _21010101152_215___Folio__.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
        public IActionResult Portfolio()
        {
            return View();
        }
        public IActionResult Blogs()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        /*[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]*/
    }
}