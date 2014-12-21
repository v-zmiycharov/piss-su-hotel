using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PissHotel.Areas.Admin.Models
{
    public class AlbumVM
    {
        public int AlbumId { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Име (BG)")]
        public string TitleBG { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [Display(Name = "Име (EN)")]
        public string TitleEN { get; set; }

        public List<string> Pictures { get; set; }
    }
}