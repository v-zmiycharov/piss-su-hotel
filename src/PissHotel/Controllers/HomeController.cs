using PissHotel.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
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
            var rooms = unitOfWork.RoomRepository.Get().ToList();

            for (int i = 0; i < rooms.Count; i++)
            {
                rooms[i].Pictures = Directory.GetFiles(Server.MapPath(Constants.RoomsImagesDir + rooms[i].RoomId + "/")).Select(Path.GetFileName).ToList();
            }

            return View(rooms);
        }

        public virtual ActionResult Contact()
        {
            return View();
        }

        public virtual ActionResult Gallery()
        {
            var albums = unitOfWork.AlbumRepository.Get().ToList();

            for (int i = 0; i < albums.Count; i++)
            {
                albums[i].Pictures = Directory.GetFiles(Server.MapPath(Constants.AlbumsImagesDir + albums[i].AlbumId + "/")).Select(Path.GetFileName).ToList();
            }

            return View(albums);
        }

        public virtual ActionResult Locality()
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