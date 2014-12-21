using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

namespace PissHotel.Areas.Admin.Models
{
    public class ChangePasswordVM
    {
        [Required(ErrorMessage = "Полето {0} е задължително")]
        [DataType(DataType.Password)]
        [Display(Name = "Текуща парола")]
        public string OldPassword { get; set; }

        [Required(ErrorMessage = "Полето {0} е задължително")]
        [StringLength(100, ErrorMessage = "Полето {0} трябва да съдържа поне {2} символа.", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Нова парола")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Повтори нова парола")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "Нова парола и Повтори нова парола не съвпадат.")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginVM
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
