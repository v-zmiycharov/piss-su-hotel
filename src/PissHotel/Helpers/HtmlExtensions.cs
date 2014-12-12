using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace PissHotel.Helpers
{
    public static class HtmlExtensions
    {
        public static string LocalizationUrl(this HtmlHelper helper, string cultureName)
        {
            var routeValues = new RouteValueDictionary(helper.ViewContext.RouteData.Values);

            var queryString = helper.ViewContext.HttpContext.Request.QueryString;

            foreach (string key in queryString)
            {
                if (queryString[key] != null && !string.IsNullOrWhiteSpace(key))
                {
                    if (routeValues.ContainsKey(key))
                    {
                        routeValues[key] = queryString[key];
                    }
                    else
                    {
                        routeValues.Add(key, queryString[key]);
                    }
                }
            }

            routeValues[Constants.LanguageRouteName] = cultureName;

            var urlHelper = new UrlHelper(helper.ViewContext.RequestContext);
            string url = urlHelper.RouteUrl(routeValues);

            return url;
        }
    }
}