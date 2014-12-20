using PissHotel.Localization;
using PissHotel.Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace PissHotel.Controllers
{
    public partial class BaseController : Controller
    {
        public BaseController()
        {
        }

        protected UnitOfWork unitOfWork = new UnitOfWork();

        protected override void ExecuteCore()
        {
            SetLocalizationCulture();

            base.ExecuteCore();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            SetLocalizationCulture();

            base.OnActionExecuting(filterContext);
        }

        protected void SetLocalizationCulture()
        {
            var language = LocalizationLanguage.bg.ToString();

            if (RouteData.Values["lang"] != null && !string.IsNullOrWhiteSpace(RouteData.Values["lang"].ToString()))
            {
                language = RouteData.Values["lang"].ToString();
            }

            var ci = new CultureInfo(language);
            Thread.CurrentThread.CurrentUICulture = ci;
            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
        }

    }
}