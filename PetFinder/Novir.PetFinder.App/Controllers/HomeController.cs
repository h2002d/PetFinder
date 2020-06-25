using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Novir.PetFinder.App.Models;

namespace Novir.PetFinder.App.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(null);
        }

        public IActionResult About()
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


        public IActionResult ChangeLanguage(string lang)
        {
            var cultureInfo = new CultureInfo(lang);
            cultureInfo.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy hh:mm:ss";
            cultureInfo.DateTimeFormat.DateSeparator = "-";
            Thread.CurrentThread.CurrentUICulture = cultureInfo;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
            CookieOptions option = new CookieOptions();
            option.Expires = DateTime.Now.AddYears(10);
            Response.Cookies.Append("culture", lang, option);

            return RedirectToAction("Index");
        }
    }
}
