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
    public class SearchVM
    {
        [Display(Name = "Местоположение")]
        public string Location { get; set; }
        [Display(Name = "Брой звезди")]
        public string Stars { get; set; }
        [Display(Name = "Подредба")]
        public string Order { get; set; }

        public List<SelectListItem> LocationItems
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Value = "1", Text = "Банско"},
                    new SelectListItem(){Value = "2", Text = "Белмекен"},
                    new SelectListItem(){Value = "3", Text = "Боровец"},
                    new SelectListItem(){Value = "4", Text = "Витоша"},
                    new SelectListItem(){Value = "5", Text = "Добринище"},
                    new SelectListItem(){Value = "6", Text = "Пампорово"},
                    new SelectListItem(){Value = "7", Text = "Рибарица"},
                    new SelectListItem(){Value = "8", Text = "Цигов чарк"},
                    new SelectListItem(){Value = "9", Text = "Чепеларе"}
                };
            }
        }

        public List<SelectListItem> StarsItems
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Value = "1", Text = "1"},
                    new SelectListItem(){Value = "2", Text = "2"},
                    new SelectListItem(){Value = "3", Text = "3"},
                    new SelectListItem(){Value = "4", Text = "4"},
                    new SelectListItem(){Value = "5", Text = "5"}
                };
            }
        }

        public List<SelectListItem> OrderItems
        {
            get
            {
                return new List<SelectListItem>()
                {
                    new SelectListItem(){Value = "1", Text = "Име"},
                    new SelectListItem(){Value = "2", Text = "Цена"},
                    new SelectListItem(){Value = "3", Text = "Звезди"}
                };
            }
        }

        public List<SearchResult> Results { get; set; }
    }

    public class SearchResult
    {
        public string name { get; set; }
        public string location { get; set; }
        public string stars { get; set; }
        public string price { get; set; }
    }
}
