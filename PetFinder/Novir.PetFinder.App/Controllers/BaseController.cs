using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Novir.PetFinder.App.Controllers
{
    public class BaseController : Controller
    {
        public async override void OnActionExecuted(ActionExecutedContext context)
        {
            string lang = null;
            var langCookie = Request.Cookies["c"];
            if (langCookie != null)
            {
                lang = langCookie;
            }
            else
            {
                lang = SiteLanguages.GetDefaultLanguage();
            }
            //SetLanguage(lang);
            await SetCultureActionFilter(lang);
            base.OnActionExecuted(context);
        }

        static async Task SetCultureActionFilter(string lang)
        {
            await Task.Yield();
            CultureInfo.CurrentCulture = new CultureInfo("am-AM");

            //Console.WriteLine(CultureInfo.CurrentCulture);
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