using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text;
using System.Web;
using System.Web.Mvc;
using webAppCroosSS.Data;
using webAppCroosSS.Models;
using ActionResult = Microsoft.AspNetCore.Mvc.ActionResult;
using Controller = Microsoft.AspNetCore.Mvc.Controller;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

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
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        public ActionResult CreateComment(Comments comment1)
        {
            StringBuilder sBuilder = new StringBuilder();
            sBuilder.Append(HttpUtility.HtmlEncode(comment1.Comment));
            sBuilder.Replace("&lt;b&gt;","<b>");
            sBuilder.Replace("&lt;/b&gt;", "</b>");
            sBuilder.Replace("&lt;u&gt;", "</b>");
            sBuilder.Replace("&lt;/u&gt;", "</b>");
            comment1.Comment = sBuilder.ToString();
            string strEncodedName = HttpUtility.HtmlEncode(comment1.Name);
            comment1.Name = strEncodedName;

            if (ModelState.IsValid)
            {
                _commentBDContext.Add(comment1);
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