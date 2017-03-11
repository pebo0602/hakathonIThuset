using hackathon_ithuset.Models;
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
        public ActionResult Book(string id = "0262220296")
        {
            string html = string.Empty;
            string url = string.Format("https://api.libris.kb.se/relrec/related?isbn={0}&format=json", id);

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

            BookViewModel model = new BookViewModel();

            model.isbn = id;
            model.relatedisbns = new List<string>();
            foreach (JObject item in related)
            {
                model.relatedisbns.Add((string)item["isbn"]);
            }
            
            return View(model);
        }
    }
}