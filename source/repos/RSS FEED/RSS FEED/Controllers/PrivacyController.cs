using Microsoft.AspNetCore.Mvc;

namespace RSS_FEED.Controllers
{
    public class PrivacyController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
