using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Novir.PetFinder.App.Controllers
{
    public class BaseController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            string lang = null;
            var langCookie = Request.Cookies["culture"];
            if (langCookie != null)
            {
                lang = langCookie;
            }
            else
            {
                lang = SiteLanguages.GetDefaultLanguage();
            }
            SetLanguage(lang);
            base.OnActionExecuted(context);
        }

        public void SetLanguage(string lang)
        {
            try
            {
                var cultureInfo = new CultureInfo(lang);
                cultureInfo.DateTimeFormat.ShortDatePattern = "dd-MM-yyyy hh:mm:ss";
                cultureInfo.DateTimeFormat.DateSeparator = "-";
                Thread.CurrentThread.CurrentUICulture = cultureInfo;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(cultureInfo.Name);
                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddYears(10);
            }
            catch (Exception ex)
            {

            }
        }
    }
}