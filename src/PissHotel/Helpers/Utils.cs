using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PissHotel.Helpers
{
    public static class Utils
    {
        public static string RemoveWhiteSpaces(this string value)
        {
            String result = String.Empty;

            if (!String.IsNullOrWhiteSpace(value))
            {
                // Trim each line
                result = String.Join(Environment.NewLine,
                    value.Split(new[] { Environment.NewLine }, StringSplitOptions.None)
                         .Select(l => l.Trim()));

                // Remove new lines
                result = result.Replace(Environment.NewLine, String.Empty).Trim();
            }

            return result;
        }
    }
}