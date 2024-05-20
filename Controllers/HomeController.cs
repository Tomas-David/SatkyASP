using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using web_satky.Models;

namespace web_satky.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
 


        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult eShop()
        {
            return View();
        }

        public IActionResult Contact()
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
