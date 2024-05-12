using System.IO;
using Grpc.Core;
using Microsoft.AspNetCore.Mvc;
using RSS_FEED.Models;

namespace RSS_FEED.Controllers
{
    public class WinimaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
    
}
