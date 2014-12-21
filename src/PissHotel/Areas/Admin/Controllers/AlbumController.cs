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
    public partial class AlbumController : AdminBaseController
    {
        public virtual ActionResult List()
        {
            var albums = unitOfWork.AlbumRepository.Get();

            return View(albums.ToList());
        }

        public virtual ActionResult Delete(int id)
        {
            var album = unitOfWork.AlbumRepository.GetByID(id);

            if (album != null)
            {
                Directory.Delete(Server.MapPath(Constants.AlbumsImagesDir + album.AlbumId + "/"), true);
                unitOfWork.AlbumRepository.Delete(album);
                unitOfWork.Save();
            }

            return RedirectToAction(ActionNames.List);
        }

        #region Create

        public virtual ActionResult Create()
        {
            var vm = new AlbumVM();

            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Create(AlbumVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Album album = new Album();
            album.TitleEN = vm.TitleEN;
            album.TitleBG = vm.TitleBG;

            unitOfWork.AlbumRepository.Insert(album);
            unitOfWork.Save();

            Directory.CreateDirectory(Server.MapPath(Constants.AlbumsImagesDir + album.AlbumId + "/"));

            return RedirectToAction(ActionNames.List);
        }

        #endregion

        #region Edit

        public virtual ActionResult Edit(int id)
        {
            var album = unitOfWork.AlbumRepository.GetByID(id);
            if (album == null)
                return RedirectToAction(ActionNames.List);

            var vm = new AlbumVM();
            vm.AlbumId = album.AlbumId;
            vm.TitleBG = album.TitleBG;
            vm.TitleEN = album.TitleEN;
            vm.Pictures = Directory.GetFiles(Server.MapPath(Constants.AlbumsImagesDir + vm.AlbumId + "/")).Select(Path.GetFileName).ToList();

            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Edit(AlbumVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Pictures = Directory.GetFiles(Server.MapPath(Constants.AlbumsImagesDir + vm.AlbumId + "/")).Select(Path.GetFileName).ToList();
                return View(vm);
            }

            Album album = unitOfWork.AlbumRepository.GetByID(vm.AlbumId);
            if (album == null)
                return RedirectToAction(ActionNames.List);

            album.TitleEN = vm.TitleEN;
            album.TitleBG = vm.TitleBG;

            unitOfWork.AlbumRepository.Update(album);
            unitOfWork.Save();

            return RedirectToAction(ActionNames.List);
        }

        #endregion

        #region Images

        public virtual ActionResult DeleteFile(int albumId, string fileName)
        {
            string path = Server.MapPath(Constants.AlbumsImagesDir + albumId + "/" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction(ActionNames.Edit, new { id = albumId });
        }

        [HttpPost]
        public virtual ActionResult AddFile(int albumId)
        {
            var album = unitOfWork.AlbumRepository.GetByID(albumId);
            if (album == null)
                return RedirectToAction(ActionNames.List);

            string folder = Server.MapPath(Constants.AlbumsImagesDir + albumId + "/");

            HttpPostedFileBase file = Request.Files["file"];

            bool isInvalidImage = file == null || file.ContentLength == 0 || String.IsNullOrWhiteSpace(file.ContentType) || !file.ContentType.StartsWith("image/");
            if (isInvalidImage)
                return RedirectToAction(ActionNames.Edit, new { id = albumId });

            string fileName = file.FileName;
            string path = Path.Combine(folder, fileName);

            while (System.IO.File.Exists(path))
            {
                fileName = "_" + fileName;
                path = Path.Combine(folder, fileName);
            }

            file.SaveAs(path);

            return RedirectToAction(ActionNames.Edit, new { id = albumId });
        }

        #endregion
    }
}