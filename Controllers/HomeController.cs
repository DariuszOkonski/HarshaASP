using Microsoft.AspNetCore.Mvc;

namespace HarshaASP.Controllers
{
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}

    [Controller]
    public class HomeController
    {
        [Route("home")]
        [Route("/")]
        public ContentResult Index()
        {
            return new ContentResult()
            {
                Content = "Hello from Index",
                ContentType = "application/text"
            };
        }

        [Route("about")]
        public string About()
        {
            return "Hello from About";
        }

        [Route("contact-us/{mobile:regex(^\\d{{10}}$)}")]
        public string Contact()
        {
            return "Hello from Contact";
        }
    }
}
