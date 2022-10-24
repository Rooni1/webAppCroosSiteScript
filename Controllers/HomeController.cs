using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using webAppCroosSS.Data;
using webAppCroosSS.Models;

namespace webAppCroosSS.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly CommentBDContext _commentBDContext;

        public HomeController(ILogger<HomeController> logger, CommentBDContext commentBDContext)
        {
            _logger = logger;
            this._commentBDContext = commentBDContext;
        }

        public IActionResult Index()
        {
            return View();
        }
     
        [HttpPost]
        public IActionResult CreateComment(Comments comment)
        {
            if (ModelState.IsValid)
            {
                _commentBDContext.Add(comment);
                _commentBDContext.SaveChanges();
                return RedirectToAction("Index");

            }
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