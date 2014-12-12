using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissHotel.Controllers
{
    public partial class HomeController : BaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }

        public virtual ActionResult Rooms()
        {
            return View();
        }

        public virtual ActionResult Contact()
        {
            return View();
        }

        public virtual ActionResult Gallery()
        {
            return View();
        }

        public virtual ActionResult Traditions()
        {
            return View();
        }

        public virtual ActionResult Holidays()
        {
            return View();
        }

        public virtual ActionResult Reservations()
        {
            return View();
        }
    }
}