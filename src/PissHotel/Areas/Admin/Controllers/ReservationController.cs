using PissHotel.Areas.Admin.Models;
using PissHotel.Helpers;
using PissHotel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PissHotel.Areas.Admin.Controllers
{
    public partial class ReservationController : AdminBaseController
    {
        public virtual ActionResult Index()
        {
            return View();
        }
    }
}