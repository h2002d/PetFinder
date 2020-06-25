using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Novir.PetFinder.App
{
    public class SiteLanguages
    {
        public static List<Languages> AvailableLanguages = new List<Languages>
                    {
                            new Languages{ LangFullName = "AM", LangCultureName = "am"},
                            new Languages{ LangFullName = "EN", LangCultureName = "en"},
                            new Languages{ LangFullName = "RU", LangCultureName = "ru"}
                    };

        public static bool IsLanguageAvailable(string lang)
        {
            return AvailableLanguages.Where(a => a.LangCultureName.Equals(lang)).FirstOrDefault() != null ? true : false;
        }

        public static string GetDefaultLanguage()
        {
            return AvailableLanguages[0].LangCultureName;
        }

    }

    public class Languages
    {
        public string LangFullName { get; set; }
        public string LangCultureName { get; set; }
    }
}

