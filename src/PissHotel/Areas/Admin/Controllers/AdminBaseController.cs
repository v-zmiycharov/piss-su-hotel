using PissHotel.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace PissHotel.Areas.Admin.Controllers
{
    [Authorize]
    public partial class AdminBaseController : Controller
    {
        protected UnitOfWork unitOfWork;

        public AdminBaseController()
        {
            unitOfWork = new UnitOfWork();
        }

    }
}
