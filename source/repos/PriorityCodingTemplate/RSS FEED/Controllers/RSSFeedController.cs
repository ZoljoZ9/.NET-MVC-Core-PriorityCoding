using Microsoft.AspNetCore.Mvc;
using RSS_FEED.Models;
using System.Linq;
using System.Net;
using System.Xml.Linq;
using System;
using System.Collections.Generic;
using System.Web;


namespace ReadRSSFeed.Controllers
{
    public class RSSFeedController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(string RSSURL)
        {
            WebClient wclient = new WebClient();
            string RSSData = wclient.DownloadString(RSSURL);

            XDocument xml = XDocument.Parse(RSSData);
            var RSSFeedData = (from x in xml.Descendants("item")
                               select new RSSFeed
                               {
                                   Title = ((string)x.Element("title")),
                                   Link = ((string)x.Element("link")),
                                   Description = ((string)x.Element("description")),
                                   PubDate = ((string)x.Element("pubDate"))
                               });
            ViewBag.RSSFeed = RSSFeedData;
            ViewBag.URL = RSSURL;
            return View();
        }
    }
}