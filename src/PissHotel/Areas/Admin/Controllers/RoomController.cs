﻿using PissHotel.Areas.Admin.Models;
using PissHotel.Helpers;
using PissHotel.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PissHotel.Areas.Admin.Controllers
{
    public partial class RoomController : AdminBaseController
    {
        public virtual ActionResult List()
        {
            var rooms = unitOfWork.RoomRepository.Get();

            return View(rooms.ToList());
        }

        public virtual ActionResult Delete(int id)
        {
            var room = unitOfWork.RoomRepository.GetByID(id);

            if (room != null)
            {
                Directory.Delete(Server.MapPath(Constants.RoomsImagesDir + room.RoomId + "/"), true);
                unitOfWork.RoomRepository.Delete(room);
                unitOfWork.Save();

                string url = string.Format(
                    @"{0}
                    ?external_id={1}",
                    "http://127.0.0.1:3000/rooms/delete", room.RoomId)
                    .RemoveWhiteSpaces();
                MakeRequest(url);
            }

            return RedirectToAction(ActionNames.List);
        }

        #region Create

        public virtual ActionResult Create()
        {
            var vm = new RoomVM();

            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Create(RoomVM vm)
        {
            if (!ModelState.IsValid)
            {
                return View(vm);
            }

            Room room = new Room();
            room.TitleEN = vm.TitleEN;
            room.TitleBG = vm.TitleBG;
            room.Price = vm.Price;

            unitOfWork.RoomRepository.Insert(room);
            unitOfWork.Save();

            Directory.CreateDirectory(Server.MapPath(Constants.RoomsImagesDir + room.RoomId + "/"));

            string url = string.Format(
                    @"{0}
                    ?external_id={1}
                    &name_bg={2}
                    &name_en={3}
                    &price={4}",
                    "http://127.0.0.1:3000/rooms/update", room.RoomId, room.TitleBG, room.TitleEN, room.Price)
                    .RemoveWhiteSpaces();
            MakeRequest(url);

            return RedirectToAction(ActionNames.List);
        }

        #endregion

        #region Edit

        public virtual ActionResult Edit(int id)
        {
            var room = unitOfWork.RoomRepository.GetByID(id);
            if (room == null)
                return RedirectToAction(ActionNames.List);

            var vm = new RoomVM();
            vm.RoomId = room.RoomId;
            vm.TitleBG = room.TitleBG;
            vm.TitleEN = room.TitleEN;
            vm.Price = room.Price;
            vm.Pictures = Directory.GetFiles(Server.MapPath(Constants.RoomsImagesDir + vm.RoomId + "/")).Select(Path.GetFileName).ToList();

            return View(vm);
        }

        [HttpPost]
        public virtual ActionResult Edit(RoomVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Pictures = Directory.GetFiles(Server.MapPath(Constants.RoomsImagesDir + vm.RoomId + "/")).Select(Path.GetFileName).ToList();
                return View(vm);
            }

            Room room = unitOfWork.RoomRepository.GetByID(vm.RoomId);
            if (room == null)
                return RedirectToAction(ActionNames.List);

            room.TitleEN = vm.TitleEN;
            room.TitleBG = vm.TitleBG;
            room.Price = vm.Price;

            unitOfWork.RoomRepository.Update(room);
            unitOfWork.Save();

            string url = string.Format(
                    @"{0}
                    ?external_id={1}
                    &name_bg={2}
                    &name_en={3}
                    &price={4}",
                    "http://127.0.0.1:3000/rooms/update", room.RoomId, room.TitleBG, room.TitleEN, room.Price)
                    .RemoveWhiteSpaces();
            MakeRequest(url);

            return RedirectToAction(ActionNames.List);
        }

        #endregion

        #region Images

        public virtual ActionResult DeleteFile(int roomId, string fileName)
        {
            string path = Server.MapPath(Constants.RoomsImagesDir + roomId + "/" + fileName);
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }

            return RedirectToAction(ActionNames.Edit, new { id = roomId });
        }

        [HttpPost]
        public virtual ActionResult AddFile(int roomId)
        {
            var room = unitOfWork.RoomRepository.GetByID(roomId);
            if (room == null)
                return RedirectToAction(ActionNames.List);

            string folder = Server.MapPath(Constants.RoomsImagesDir + roomId + "/");

            HttpPostedFileBase file = Request.Files["file"];

            bool isInvalidImage = file == null || file.ContentLength == 0 || String.IsNullOrWhiteSpace(file.ContentType) || !file.ContentType.StartsWith("image/");
            if (isInvalidImage)
                return RedirectToAction(ActionNames.Edit, new { id = roomId });

            string fileName = file.FileName;
            string path = Path.Combine(folder, fileName);

            while (System.IO.File.Exists(path))
            {
                fileName = "_" + fileName;
                path = Path.Combine(folder, fileName);
            }

            file.SaveAs(path);

            return RedirectToAction(ActionNames.Edit, new { id = roomId });
        }

        #endregion

        private void MakeRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            var response = request.GetResponse();
        }
    }
}