using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;
using PissHotel.Filters;
using PissHotel.Areas.Admin.Models;

namespace PissHotel.Areas.Admin.Controllers
{
    [InitializeSimpleMembership]
    public partial class AccountController : Controller
    {
        public virtual ActionResult Login()
        {
            if (Request.IsAuthenticated)
            {
                return RedirectToAction(MVC.Admin.Room.ActionNames.List, MVC.Admin.Room.Name, new { area = MVC.Admin.Name });
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual ActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid && WebSecurity.Login(model.UserName, model.Password, persistCookie: false))
            {
                return RedirectToAction(MVC.Admin.Room.ActionNames.List, MVC.Admin.Room.Name, new { area = MVC.Admin.Name });
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Невалидно потребителско име или парола");
            return View(model);
        }

        [Authorize]
        public virtual ActionResult LogOff()
        {
            WebSecurity.Logout();

            return RedirectToAction(ActionNames.Login, new { area = MVC.Admin.Name });
        }

        [Authorize]
        public virtual ActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public virtual ActionResult ChangePassword(ChangePasswordVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (WebSecurity.ChangePassword("admin", model.OldPassword, model.NewPassword))
            {
                WebSecurity.Logout();

                return RedirectToAction(ActionNames.Login, new { area = MVC.Admin.Name });
            }

            // If we got this far, something failed, redisplay form
            ModelState.AddModelError("", "Невалидна парола");
            return View(model);
        }
    }
}
