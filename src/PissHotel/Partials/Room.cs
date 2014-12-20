using PissHotel.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissHotel.Models
{
    public partial class Room
    {
        public List<string> Pictures { get; set; }

        public string Title
        {
            get
            {
                if (SystemLocalization.GetCurrentLanguage() == LocalizationLanguage.en)
                    return this.TitleEN;
                else
                    return this.TitleBG;
            }
        }
    }
}