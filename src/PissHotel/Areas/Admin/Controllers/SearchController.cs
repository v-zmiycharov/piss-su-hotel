using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using PissHotel.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PissHotel.Areas.Admin.Controllers
{
    public partial class SearchController : Controller
    {
        public virtual ActionResult Search()
        {
            return View(new SearchVM());
        }

        [HttpPost]
        public virtual ActionResult Search(SearchVM vm)
        {
            string url = string.Format(
                    @"{0}
                    ?location={1}
                    &starsNum={2}
                    &order={3}",
                    "http://localhost:8080/hotel-search-0/api/hotels/search"
                    , vm.Location, vm.Stars, vm.Order)
                    .Replace(Environment.NewLine, "").Replace(" ", "");

            vm.Results = MakeRequest(url).ToObject<List<SearchResult>>();

            return View(vm);
        }

        private JObject MakeRequest(string url)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(url);
            request.Method = "GET";
            request.AllowAutoRedirect = false;
            request.Accept = "application/json, text/plain, */*";
            request.ContentType = "application/application/json; charset=UTF-8";

            JObject jO;

            using (var response = request.GetResponse())
            using (var responseStream = response.GetResponseStream())
            using (var reader = new StreamReader(responseStream))
            {
                var responseFromServer = reader.ReadToEnd();
                jO = JsonConvert.DeserializeObject<JObject>(responseFromServer);
            }

            return jO;
        }
    }
}