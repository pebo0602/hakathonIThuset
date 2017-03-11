using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace hackathon_ithuset.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: Book
        public ActionResult Book(string id)
        {
            string html = string.Empty;
            string url = "https://api.libris.kb.se/relrec/related?isbn=0-262-22029-6&format=json";

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.AutomaticDecompression = DecompressionMethods.GZip;

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
            {
                html = reader.ReadToEnd();
            }

            JObject o = JObject.Parse(html);
            JArray related = (JArray)o["relatedrecords"]["related"];

            List<string> isbns = new List<string>();
            foreach (JObject item in related)
            {
                isbns.Add((string)item["isbn"]);
            }
            
            return View((object)isbns);
        }
    }
}