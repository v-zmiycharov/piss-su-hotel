using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissHotel.Areas.Admin.Models
{
    public class RoomVM
    {
        public int RoomId { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Име (BG)")]
        public string TitleBG { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Име (EN)")]
        public string TitleEN { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name="Цена (лв.)")]
        public int Price { get; set; }

        public List<string> Pictures { get; set; }
    }
}