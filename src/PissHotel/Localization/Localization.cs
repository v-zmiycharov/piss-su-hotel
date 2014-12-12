using System;
using System.Collections.Generic;
using System.Threading;
using System.Web.Routing;

namespace PissHotel.Localization
{
    public enum LocalizationLanguage
    {
        bg,
        en
    }

    public class SystemLocalization
    {
        public static System.Globalization.CultureInfo Culture { get; set; }
        
        public static LocalizationLanguage GetCurrentLanguage()
        {
            var currentCulture = String.Empty;
            if (Thread.CurrentThread.CurrentUICulture != null)
            {
                currentCulture = Thread.CurrentThread.CurrentUICulture.Name.ToLower().Substring(0, 2);
            }

            switch (currentCulture)
            {
                case "bg":
                    return LocalizationLanguage.bg;
                case "en":
                    return LocalizationLanguage.en;
                default:
                    return LocalizationLanguage.bg;
            }
        }
    }
}